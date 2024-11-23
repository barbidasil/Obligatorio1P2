using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Models;
using Obligatorio2.Services;
using System.Collections.Generic;

namespace Obligatorio2.Controllers
{
    public class UsuarioController : Controller
    {
        private static List<Usuario> usuarios = TestDataService.Usuarios; // Base de datos simulada

        [HttpGet]
        public IActionResult Registrar()
        {
            return View(); // Busca la vista /Views/Usuario/Registrar.cshtml
        }

        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Validar si el email ya existe
                foreach (var u in usuarios)
                {
                    if (u.Email == usuario.Email)
                    {
                        ViewBag.Error = "El email ya está registrado.";
                        return View();
                    }
                }

                // Crear un nuevo Cliente con saldo inicial
                Cliente nuevoCliente = new Cliente
                {
                    UserId = usuarios.Count + 1,
                    Name = usuario.Name,
                    Lastname = usuario.Lastname,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    SaldoDisponible = 0 // Saldo inicial
                };

                usuarios.Add(nuevoCliente); // Agregar al listado de usuarios
                ViewBag.Message = "Usuario registrado con éxito.";

                // Redirigir al Login
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Error = "Hubo un problema con el registro. Por favor verifica los datos.";
            return View();
        }
    }
}
