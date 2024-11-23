using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Models;
using Obligatorio2.Services;
using System;
using System.Collections.Generic;

namespace Obligatorio2.Controllers
{
    public class LoginController : Controller
    {
        private List<Usuario> usuarios = TestDataService.Usuarios;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            Usuario usuario = null;

            // Búsqueda manual del usuario
            foreach (var u in TestDataService.Usuarios)
            {
                if (u.Email == email && u.Password == password)
                {
                    usuario = u;
                    break;
                }
            }

            if (usuario == null)
            {
                ViewBag.Error = "Credenciales incorrectas.";
                return View("Index");
            }

            // Guardar datos del usuario en la sesión
            HttpContext.Session.SetInt32("UserId", usuario.UserId);
            HttpContext.Session.SetString("UserName", usuario.Name);

            if (usuario is Cliente cliente)
            {
                HttpContext.Session.SetString("UserType", "Cliente");
                HttpContext.Session.SetString("UserBalance", cliente.SaldoDisponible.ToString()); // Convertir decimal a string

                // Redirigir a publicaciones para clientes
                return RedirectToAction("VerPublicaciones", "Publicaciones");
            }
            else if (usuario is Administrador)
            {
                HttpContext.Session.SetString("UserType", "Administrador");

                // Redirigir a la vista de subastas para administradores
                return RedirectToAction("VerSubastas", "Administrador");
            }

            return View("Index");
        }



        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpiar sesión
            return RedirectToAction("Index");
        }
    }
}
