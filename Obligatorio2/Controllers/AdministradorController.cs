using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Models;
using Obligatorio2.Services;
using System.Collections.Generic;

namespace Obligatorio2.Controllers
{
    public class AdministradorController : Controller
    {
        private List<Publicacion> publicaciones = TestDataService.Publicaciones;

        // Endpoint 10: Ver todas las subastas
        [HttpGet]
        [HttpGet]
        public IActionResult VerSubastas()
        {
            // Crear una lista de subastas para la vista
            var subastasOrdenadas = new List<SubastaViewModel>();
            foreach (var publicacion in publicaciones)
            {
                if (publicacion is Auction subasta)
                {
                    // Calcular la mejor oferta manualmente
                    decimal mejorOferta = 0;
                    foreach (var oferta in subasta.Offers)
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



        // Endpoint 11: Cerrar una subasta
        [HttpPost]
        [HttpPost]
        public IActionResult CerrarSubasta(int subastaId)
        {
            // Buscar la subasta
            Auction subasta = null;
            foreach (var publicacion in TestDataService.Publicaciones)
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
            foreach (var oferta in subasta.Offers)
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

            // Verificar si el mejor oferente tiene saldo suficiente
            var mejorOferente = mejorOferta.Client as Cliente;
            if (mejorOferente == null || mejorOferente.SaldoDisponible < mejorOferta.Amount)
            {
                TempData["Error"] = "El mejor oferente no tiene saldo suficiente para completar la compra.";
                return RedirectToAction("VerSubastas");
            }

            // Finalizar la subasta
            mejorOferente.SaldoDisponible -= mejorOferta.Amount;
            subasta.Close(mejorOferente, DateTime.Now);

            TempData["Success"] = $"La subasta ha sido adjudicada a {mejorOferente.Name} por {mejorOferta.Amount:C}.";
            return RedirectToAction("VerSubastas");
        }





        // Endpoint 12: Logout
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpiar sesión
            return RedirectToAction("Index", "Login");
        }
    }
}
