using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Models;
using Obligatorio2.Services;
using System.Collections.Generic;

namespace Obligatorio2.Controllers
{
    public class ClienteController : Controller
    {
        private List<Usuario> usuarios = TestDataService.Usuarios;

        [HttpGet]
        public IActionResult CargarSaldo()
        {
            if (!HttpContext.Session.Keys.Contains("UserId"))
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult ComprarVenta(int publicacionId)
        {
            // Verifica que el usuario esté autenticado
            if (!HttpContext.Session.Keys.Contains("UserId"))
            {
                return RedirectToAction("Index", "Login");
            }

            int? userId = HttpContext.Session.GetInt32("UserId");
            Usuario usuario = null;

            // Buscar al usuario en la lista de usuarios
            foreach (Usuario u in TestDataService.Usuarios)
            {
                if (u.UserId == userId)
                {
                    usuario = u;
                    break;
                }
            }

            if (usuario == null || !(usuario is Cliente cliente))
            {
                return BadRequest("Usuario no válido.");
            }

            // Buscar la publicación correspondiente
            Publicacion publicacion = null;
            foreach (Publicacion  p in TestDataService.Publicaciones)
            {
                if (p.IdP == publicacionId && p is Sales)
                {
                    publicacion = p;
                    break;
                }
            }

            if (publicacion == null || !publicacion.IsOpen())
            {
                TempData["Error"] = "Publicación no válida para compra.";
                return RedirectToAction("VerPublicaciones", "Publicaciones");
            }

            Sales venta = publicacion as Sales;
            decimal precioVenta = venta.GetPrice();

            // Verifica si el cliente tiene saldo
            if (cliente.SaldoDisponible < precioVenta)
            {
                TempData["Error"] = "Saldo insuficiente para realizar la compra.";
                return RedirectToAction("VerPublicaciones", "Publicaciones");
            }

            // Restar el saldo del cliente
            cliente.SaldoDisponible -= precioVenta;

            // Finalizar la publicación
            venta.Close(cliente, DateTime.Now);

            // Actualizar el saldo en la sesión
            HttpContext.Session.SetString("UserBalance", cliente.SaldoDisponible.ToString("F2"));

            TempData["Success"] = $"Compra realizada con éxito por {precioVenta:C}.";
            return RedirectToAction("VerPublicaciones", "Publicaciones");
        }



        [HttpPost]
        public IActionResult OfertarSubasta(int publicacionId, decimal monto)
        {
            if (!HttpContext.Session.Keys.Contains("UserId"))
            {
                return RedirectToAction("Index", "Login");
            }

            int? userId = HttpContext.Session.GetInt32("UserId");
            Usuario usuario = null;

            // Buscar al usuario actual
            foreach (Usuario u in TestDataService.Usuarios)
            {
                if (u.UserId == userId)
                {
                    usuario = u;
                    break;
                }
            }

            if (usuario == null || !(usuario is Cliente cliente))
            {
                return BadRequest("Usuario no válido.");
            }

            // Buscar la publicación correspondiente
            Publicacion publicacion = null;
            foreach (Publicacion p in TestDataService.Publicaciones)
            {
                if (p.IdP == publicacionId && p is Auction)
                {
                    publicacion = p;
                    break;
                }
            }

            if (publicacion == null || !publicacion.IsOpen())
            {
                return BadRequest("Publicación no válida para ofertar.");
            }

            Auction subasta = publicacion as Auction;

            // Verificar la oferta más alta
            decimal mejorOferta = 0;
            foreach (Offer oferta in subasta.Offers)
            {
                if (oferta.Amount > mejorOferta)
                {
                    mejorOferta = oferta.Amount;
                }
            }

            if (monto <= mejorOferta)
            {
                TempData["Error"] = "La oferta debe ser superior a la oferta más alta actual.";
                return RedirectToAction("VerPublicaciones", "Publicaciones");
            }

            // Registrar la nueva oferta
            subasta.Offers.Add(new Offer
            {
                OfferId = subasta.Offers.Count + 1,
                Client = cliente,
                Amount = monto,
                Date = DateTime.Now
            });

            TempData["Success"] = "Oferta registrada con éxito.";
            return RedirectToAction("VerPublicaciones", "Publicaciones");
        }


        [HttpPost]
        public IActionResult CargarSaldo(decimal monto)
        {
            if (!HttpContext.Session.Keys.Contains("UserId"))
            {
                return RedirectToAction("Index", "Login");
            }

            if (monto <= 0)
            {
                ViewBag.Error = "El monto debe ser mayor que 0.";
                return View();
            }

            int? userId = HttpContext.Session.GetInt32("UserId");
            Usuario cliente = null;

            // Búsqueda manual del cliente
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.UserId == userId && usuario is Cliente)
                {
                    cliente = usuario;
                    break;
                }
            }

            if (cliente is Cliente clienteReal)
            {
                clienteReal.SaldoDisponible += monto;

                // Convertir el saldo a string para almacenarlo en la sesión
                HttpContext.Session.SetString("UserBalance", clienteReal.SaldoDisponible.ToString());

                ViewBag.Message = "Saldo cargado exitosamente.";
            }
            else
            {
                ViewBag.Error = "Usuario no válido.";
            }

            return View();
        }
    }
}
