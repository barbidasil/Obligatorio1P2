using Obligatorio2.Models;
using System;
using System.Collections.Generic;

namespace Obligatorio2.Services
{
    public static class TestDataService
    {
        // Listas para datos precargados
        public static List<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public static List<Publicacion> Publicaciones { get; private set; } = new List<Publicacion>();

        // Inicialización de datos
        static TestDataService()
        {
            GenerarDatos();
        }

        private static void GenerarDatos()
        {
            // Crear usuarios (Clientes y Administradores)
            Usuarios.Add(new Cliente(1, "Juan", "Pérez", "juan.perez@ejemplo.com", "password123", 1000));
            Usuarios.Add(new Cliente(2, "María", "González", "maria.gonzalez@ejemplo.com", "password123", 2000));
            Usuarios.Add(new Cliente(3, "Carlos", "López", "carlos.lopez@ejemplo.com", "password123", 1500));
            Usuarios.Add(new Cliente(4, "Ana", "Martínez", "ana.martinez@ejemplo.com", "password123", 800));
            Usuarios.Add(new Cliente(5, "Luis", "Ramírez", "luis.ramirez@ejemplo.com", "password123", 500));
            Usuarios.Add(new Administrador(6, "Sofia", "Admin", "sofia.admin@ejemplo.com", "adminpass"));
            Usuarios.Add(new Administrador(7, "Pedro", "Admin", "pedro.admin@ejemplo.com", "adminpass"));

            // Crear artículos
            var articulos = new List<Article>
            {
                new Article { Id = 1, Name = "Balde", SellPrice = 200 },
                new Article { Id = 2, Name = "Sombrilla", SellPrice = 1500 },
                new Article { Id = 3, Name = "Protector Solar", SellPrice = 750 },
                new Article { Id = 4, Name = "Salvavidas", SellPrice = 1200 },
                new Article { Id = 5, Name = "Bicicleta de Carrera", SellPrice = 25000 },
                new Article { Id = 6, Name = "Malla de Ciclismo", SellPrice = 5000 },
                new Article { Id = 7, Name = "Zapatillas de Ciclismo", SellPrice = 8000 },
                new Article { Id = 8, Name = "Juego de Ollas", SellPrice = 3000 },
                new Article { Id = 9, Name = "Antigüedad de Porcelana", SellPrice = 10000 },
                new Article { Id = 10, Name = "Sillón de Cuero", SellPrice = 15000 }
            };

            // Crear publicaciones de tipo Venta
            Publicaciones.Add(new Sales
            {
                IdP = 1,
                Name = "Verano en la Playa",
                PublishDate = DateTime.Now.AddDays(-7),
                Status = "Abierta",
                Articles = new List<Article> { articulos[0], articulos[1], articulos[2], articulos[3] },
                FlashOffer = true // Aplica descuento del 20%
            });

            Publicaciones.Add(new Sales
            {
                IdP = 2,
                Name = "Cocina Premium",
                PublishDate = DateTime.Now.AddDays(-10),
                Status = "Abierta",
                Articles = new List<Article> { articulos[7], articulos[9] },
                FlashOffer = false // No aplica descuento
            });

            // Crear publicaciones de tipo Subasta
            Publicaciones.Add(new Auction
            {
                IdP = 3,
                Name = "Vuelta Ciclista",
                PublishDate = DateTime.Now.AddDays(-15),
                Status = "Abierta",
                Articles = new List<Article> { articulos[4], articulos[5], articulos[6] },
                Offers = new List<Offer>
                {
                    new Offer { OfferId = 1, Client = Usuarios[0] as Cliente, Amount = 32000, Date = DateTime.Now.AddDays(-10) },
                    new Offer { OfferId = 2, Client = Usuarios[1] as Cliente, Amount = 34000, Date = DateTime.Now.AddDays(-5) }
                }
            });

            Publicaciones.Add(new Auction
            {
                IdP = 4,
                Name = "Colección Antigüedades",
                PublishDate = DateTime.Now.AddDays(-20),
                Status = "Abierta",
                Articles = new List<Article> { articulos[8], articulos[9] },
                Offers = new List<Offer>
                {
                    new Offer { OfferId = 1, Client = Usuarios[2] as Cliente, Amount = 20000, Date = DateTime.Now.AddDays(-12) },
                    new Offer { OfferId = 2, Client = Usuarios[3] as Cliente, Amount = 22000, Date = DateTime.Now.AddDays(-8) }
                }
            });
        }
    }
}
