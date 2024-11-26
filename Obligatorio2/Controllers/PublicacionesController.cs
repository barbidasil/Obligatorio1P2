using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Models;
using Obligatorio2.Services;
using System.Collections.Generic;

namespace Obligatorio2.Controllers
{
    public class PublicacionesController : Controller
    {
        private List<Publicacion> publicaciones = TestDataService.Publicaciones;

        [HttpGet]
        public IActionResult VerPublicaciones()
        {
            List<object> resultado = new List<object>();
            foreach (Publicacion publicacion in publicaciones)
            {
                decimal precio = publicacion is Sales venta
                    ? venta.GetPrice()
                    : (publicacion is Auction subasta ? subasta.GetPrice() : 0);

                resultado.Add(new
                {
                    Id = publicacion.IdP,
                    Nombre = publicacion.Name,
                    Estado = publicacion.Status,
                    Precio = precio,
                    EsAbierta = publicacion.IsOpen(),
                    Tipo = publicacion is Sales ? "Venta" : "Subasta"
                });
            }

            return View(resultado);
        }
    }
}
