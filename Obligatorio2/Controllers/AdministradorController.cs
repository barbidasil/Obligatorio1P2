using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Models;
using Obligatorio2.Services;


namespace Obligatorio2.Controllers
{
    public class AdministradorController : Controller
    {
        private List<Publicacion> publicaciones = TestDataService.Publicaciones;



        [HttpGet]
        public IActionResult VerSubastas()
        {
            // Crear una lista de subastas para la vista
            List<SubastaViewModel> subastasOrdenadas = new List<SubastaViewModel>();
            foreach (Publicacion publicacion in publicaciones)
            {
                if (publicacion is Auction subasta)
                {
                    // Calcular la mejor oferta manualmente
                    decimal mejorOferta = 0;
                    foreach (Offer oferta in subasta.Offers)
                    {
                        if (oferta.Amount > mejorOferta)
                        {
                            mejorOferta = oferta.Amount;
                        }
                    }

                    subastasOrdenadas.Add(new SubastaViewModel
                    {
                        Id = subasta.IdP,
                        Name = subasta.Name,
                        PublishDate = subasta.PublishDate,
                        Status = subasta.Status,
                        MejorOferta = mejorOferta > 0 ? mejorOferta.ToString("C") : "Sin ofertas",
                        EsAbierta = subasta.IsOpen()
                    });
                }
            }

            // Ordenar por fecha de publicación
            subastasOrdenadas.Sort((x, y) => x.PublishDate.CompareTo(y.PublishDate));

            return View(subastasOrdenadas);
        }



        [HttpPost]
        public IActionResult CerrarSubasta(int subastaId)
        {
           
            Auction subasta = null;
            foreach (Publicacion publicacion in TestDataService.Publicaciones)
            {
                if (publicacion.IdP == subastaId && publicacion is Auction)
                {
                    subasta = (Auction)publicacion;
                    break;
                }
            }

            if (subasta == null || !subasta.IsOpen())
            {
                TempData["Error"] = "Subasta no válida o ya cerrada.";
                return RedirectToAction("VerSubastas");
            }

            // Determinar la mejor oferta
            Offer mejorOferta = null;
            foreach (Offer oferta in subasta.Offers)
            {
                if (mejorOferta == null || oferta.Amount > mejorOferta.Amount)
                {
                    mejorOferta = oferta;
                }
            }

            if (mejorOferta == null)
            {
                TempData["Error"] = "La subasta no tiene ofertas.";
                return RedirectToAction("VerSubastas");
            }

            // Verificar si el mejor ofertante tiene saldo 
            var mejorOfertante = mejorOferta.Client as Cliente;
            if (mejorOfertante == null || mejorOfertante.SaldoDisponible < mejorOferta.Amount)
            {
                TempData["Error"] = "El mejor ofertante no tiene saldo suficiente para completar la compra.";
                return RedirectToAction("VerSubastas");
            }

            // Finalizar la subasta
            mejorOfertante.SaldoDisponible -= mejorOferta.Amount;
            subasta.Close(mejorOfertante, DateTime.Now);

            TempData["Success"] = $"La subasta ha sido adjudicada a {mejorOfertante.Name} por {mejorOferta.Amount:C}.";
            return RedirectToAction("VerSubastas");
        }



        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpiar sesión
            return RedirectToAction("Index", "Login");
        }
    }
}
