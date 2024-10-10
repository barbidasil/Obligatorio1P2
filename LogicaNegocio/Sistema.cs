﻿namespace LogicaNegocio
{
    public class Sistema
    {
        private static Sistema _instancia;
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Category> _categorias = new List<Category>();
        private List<Article> _articles = new List<Article>();
        private static int _nxid = 1;

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        public List<Publicacion> Publicaciones { get { return _publicaciones; } }
        public List<Usuario> Usuarios { get { return _usuarios; } }

        public List<Category> Categorias { get { return _categorias; } }

        public List<Article> Articles { get { return _articles; } }


        //////////////////////DATOS PRECARGADOS CON CHATGPT////////////////////////////////
        private Sistema()
        {
            this.Precargar();
        }

        public void Precargar()
        {
            this.PrecargarUsuarios();
            this.PrecargarCategorias();
            this.PrecargarArticulos();
            this.PrecargarPublicaciones();
        }

        private void PrecargarUsuarios()
        {
            _usuarios.Add(new Cliente(1, "Juan", "Pérez", "juan.perez@ejemplo.com", "password", 1000));
            _usuarios.Add(new Cliente(2, "María", "González", "maria.gonzalez@ejemplo.com", "password", 1500));
            _usuarios.Add(new Cliente(3, "Carlos", "López", "carlos.lopez@ejemplo.com", "password", 800));
            _usuarios.Add(new Cliente(4, "Ana", "Martínez", "ana.martinez@ejemplo.com", "password", 1200));
            _usuarios.Add(new Cliente(5, "Luis", "Ramírez", "luis.ramirez@ejemplo.com", "password", 950));
            _usuarios.Add(new Administrador(6, "Admin", "Principal", "admin@ejemplo.com", "password"));
        }

        private void PrecargarCategorias()
        {
            _categorias.Add(new Category(1, "Electrónica"));
            _categorias.Add(new Category(2, "Hogar y Jardín"));
            _categorias.Add(new Category(3, "Ropa y Accesorios"));
            _categorias.Add(new Category(4, "Salud y Belleza"));
            _categorias.Add(new Category(5, "Deportes"));
            _categorias.Add(new Category(6, "Juguetes"));
            _categorias.Add(new Category(7, "Libros"));
            _categorias.Add(new Category(8, "Alimentos"));
            _categorias.Add(new Category(9, "Automóviles"));
            _categorias.Add(new Category(10, "Oficina"));
        }

        private void PrecargarArticulos()
        {
            _articles.Add(new Article(1, "Televisor 4K", new List<Category> { _categorias[0] }, 120099));
            _articles.Add(new Article(2, "Sofá de 3 plazas", new List<Category> { _categorias[1] }, 60050));
            _articles.Add(new Article(3, "Camisa de algodón", new List<Category> { _categorias[2] }, 2999));
            _articles.Add(new Article(4, "Crema hidratante", new List<Category> { _categorias[3] }, 1975));
            _articles.Add(new Article(5, "Bicicleta de montaña", new List<Category> { _categorias[4] }, 35000));
            _articles.Add(new Article(6, "Peluche de dinosaurio", new List<Category> { _categorias[5] }, 1500));
            _articles.Add(new Article(7, "Libro de cocina", new List<Category> { _categorias[6] }, 2500));
            _articles.Add(new Article(8, "Chocolate en polvo", new List<Category> { _categorias[7] }, 550));
            _articles.Add(new Article(9, "Aceite de motor", new List<Category> { _categorias[8] }, 2000));
            _articles.Add(new Article(10, "Papel de oficina", new List<Category> { _categorias[9] }, 1099));
        }

        private void PrecargarPublicaciones()
        {
            var usuarioComprador1 = _usuarios[0];
            var usuarioAdmin = _usuarios[1];

            // Publicación cerrada en el pasado
            _publicaciones.Add(new Publicacion("Lote de Electrónicos", new DateTime(2024, 7, 15), Status.CERRADA, usuarioComprador1, usuarioAdmin, new DateTime(2024, 8, 15)));

            // Publicaciones abiertas, algunas en el pasado, algunas en el futuro
            _publicaciones.Add(new Publicacion("Venta1", new DateTime(2024, 7, 22), Status.ABIERTA, _usuarios[0], usuarioAdmin, new DateTime(2024, 8, 22)));
            _publicaciones.Add(new Publicacion("Venta2", new DateTime(2024, 7, 25), Status.ABIERTA, _usuarios[1], usuarioAdmin, new DateTime(2024, 8, 25)));
            _publicaciones.Add(new Publicacion("Venta3", new DateTime(2024, 8, 1), Status.ABIERTA, _usuarios[0], usuarioAdmin, new DateTime(2024, 8, 28)));
            _publicaciones.Add(new Publicacion("Venta4", new DateTime(2024, 8, 10), Status.ABIERTA, _usuarios[1], usuarioAdmin, new DateTime(2024, 8, 30)));
            _publicaciones.Add(new Publicacion("Venta5", new DateTime(2024, 9, 1), Status.ABIERTA, _usuarios[0], usuarioAdmin, new DateTime(2024, 9, 15)));

            // Subastas
            for (int i = 1; i <= 5; i++)
            {
                var subasta = new Auction($"Subasta{i}", new DateTime(2024, 8, 5), Status.ABIERTA, _usuarios[i % _usuarios.Count], usuarioAdmin, new DateTime(2024, 8, 20));
                _publicaciones.Add(subasta);
            }
        }
        ////////////////////////////////////////////////////

        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

        public List<Category> ObtenerCategorias()
        {
            return _categorias;
        }

        public List<Publicacion> ObtenerPublicaciones()
        {
            return _publicaciones;
        }

        public List<Publicacion> ListarPublicacionesEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Publicacion> publicacionesOk = new List<Publicacion>();

            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.PublishDate >= fechaInicio && publicacion.PublishDate <= fechaFin)
                {
                    publicacionesOk.Add(publicacion);
                }
            }
            return publicacionesOk;
        }

        public List<Article> ListarArticulosPorCat(Category categoria)
        {
            List<Article> articulosPorCat = new List<Article>();

            foreach (Article articulo in _articles)
            {
                foreach (Category cat in articulo.Category)
                {
                    if (cat.Id == categoria.Id)
                    {
                        articulosPorCat.Add(articulo);
                        break; 
                    }
                }
            }
            return articulosPorCat;
        }


        public void AgregarArticulo(string name, List<Category> categories, decimal sellPrice)
        {
            Article nuevoArticulo = new Article
            {
                Id = _nxid++,
                Name = name,
                SellPrice = sellPrice,
                Category = categories,
            };

            _articles.Add(nuevoArticulo);
      
        }

        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();
        }
    }

}
