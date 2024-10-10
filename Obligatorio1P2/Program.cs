
using System.Security.Cryptography;
using LogicaNegocio;

namespace Gestion

{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Instanciamos al sistema
            Sistema sistema = Sistema.Instancia;

            string seleccion = "";
            while(seleccion != "0")
            {
                Console.Clear();
                MostrarMenu();
                seleccion = Console.ReadLine();
                switch (seleccion)
                {
                    case "0":
                        Console.WriteLine("Adios");
                        Console.WriteLine("Presione Enter para seguir");
                        Console.ReadLine();
                        break;
                    case "1":
                        ListarClientes();
                        break;
                    case "2":
                        Console.WriteLine("Ingresa una Categoria: ");
                        string nombreCategoria = Console.ReadLine();
                        Category categoria = CatPorName(nombreCategoria);

                        if (categoria != null)
                        {
                            List<Article> articulos = sistema.ListarArticulosPorCat(categoria); 

                            if (articulos.Count > 0)
                            {
                                Console.WriteLine($"Articulos dentro de la categoria '{nombreCategoria}': ");
                                foreach (Article articulo in articulos)
                                {
                                    Console.WriteLine($" - Nombre: {articulo.Name}, Categoría: {nombreCategoria}, Precio: ${articulo.SellPrice}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Lo siento, no existen articulos disponibles en la categoria '{nombreCategoria}'");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"La categoria '{nombreCategoria}' no existe! ");
                        }
                        Console.WriteLine("Presione Enter Para continuar");
                        Console.ReadLine();

                        break;
                    case "3":
                        bool ingreso = false;
                        while (!ingreso)
                        {
                            try
                            {
                                Article articulo = new Article();
                                Console.WriteLine("Ingrese el nombre del articulo: ");
                                string name = Console.ReadLine();
                                articulo.Name = name;

                                Console.WriteLine("Ingrese la categoria: ");
                                string categoryName = Console.ReadLine();
                                Category categoriaSeleccionada = FindByCat(categoryName, sistema.ObtenerCategorias());

                                if (categoriaSeleccionada != null)
                                {

                                    if (articulo.Category == null)
                                    {
                                        articulo.Category = new List<Category>();

                                    }

                                    articulo.Category.Add(categoriaSeleccionada);

                                    Console.WriteLine($"Articulo '{articulo.Name}' ha sido asignado a la categoria '{categoriaSeleccionada.Name}'");
                                }
                                else
                                {
                                    Console.WriteLine($"La categoria '{categoryName}' no existe.");
                                }

                                //Ingresar precio articulo

                                Console.WriteLine("Ingresar el precio del articulo: ");
                                string precioInput = Console.ReadLine();
                                decimal sellPrice;

                                while (!decimal.TryParse(precioInput, out sellPrice) || sellPrice <= 0)
                                {
                                    Console.WriteLine("Precio invalido, por favor ingresa un valor numerico valido");
                                    precioInput = Console.ReadLine();   

                                }

                                articulo.SellPrice = sellPrice;
                               

                                //Llamamos al metodo para agregar el articulo al sistema

                                sistema.AgregarArticulo(articulo.Name, articulo.Category, articulo.SellPrice);
                                ingreso = true;
                                Console.WriteLine($"Se creo el articulo '{articulo.Name}' correctamente");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine (ex.Message);
                            }
                        }
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadLine();
                    break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Ingrese la fecha de inicio (formato: yyyy-mm-dd): ");
                            string fechaInicioInput = Console.ReadLine();
                            DateTime fechaInicio;

                            while (!DateTime.TryParse(fechaInicioInput, out fechaInicio))
                            {
                                Console.WriteLine("Fecha invalida, ingrese una fecha valida");
                                fechaInicioInput = Console.ReadLine();

                            }
                            Console.WriteLine("Ingrese la fecha de fin (formato: yyyy-mm-dd): ");
                            string fechaFinInput = Console.ReadLine();
                            DateTime fechaFin;

                            while (!DateTime.TryParse(fechaFinInput, out fechaFin) || fechaFin < fechaInicio)
                            {
                                Console.WriteLine("Fecha invalida, ingrese una fecha valida");
                                fechaFinInput = Console.ReadLine();
                            }
                
                            List<Publicacion> publicacionesFiltered = sistema.ListarPublicacionesEntreFechas(fechaInicio, fechaFin);

                            if (publicacionesFiltered.Count > 0)
                            {
                                Console.WriteLine("Publicaciones encontradas en ese rango de fechas");
                                foreach (Publicacion publicacion in publicacionesFiltered)
                                {
                                    Console.WriteLine($"ID: {publicacion.IdP}, Nombre: {publicacion.Name}, Estado: {publicacion.Status}, Fecha de Publicación: {publicacion.PublishDate.ToShortDateString()}");
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine("Presione Enter Para Continuar");
                        Console.ReadLine();
                    break;
                    default:
                    Console.WriteLine("Opcion invalida");
                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    break;
                }
            }
        }



        public static void ListarClientes()
        {
            Sistema sistema = Sistema.Instancia;
            List<Usuario> usuarios = sistema.ObtenerUsuarios();
            List<Cliente> clientes = new List<Cliente>();

            foreach (Usuario usuario in usuarios)
            {
                if(usuario is Cliente cliente)
                {
                    clientes.Add(cliente);
                }
            }

            if(clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes disponibles.");
            }
            else
            {
                foreach(Cliente cliente in clientes)
                {
                    Console.WriteLine($"Nombre: {cliente.Name}, Apellido: {cliente.Lastname}, Email: {cliente.Email}, Saldo Disponible: {cliente.SaldoDisponible:C}");
                }
            }
            Console.WriteLine("Presione Enter para continuar");
            Console.ReadLine();
        }

        public static Category CatPorName(string nombreCategoria)
        {
            Sistema sistema = Sistema.Instancia;
            List<Category> categorias = sistema.ObtenerCategorias();

            foreach(Category categoria in categorias)
            {
                if (categoria.Name == nombreCategoria)
                {
                    return categoria;
                }
            }

            return null;

            

        }

        public static Category FindByCat(string nombreCategoria, List<Category> categorias)
        {
            foreach(Category categoria in categorias){
               if(categoria.Name == nombreCategoria) { return categoria; }
            }
            return null;
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Obligatorio 1 P2");
            Console.WriteLine("1 - Listar Clientes");
            Console.WriteLine("2 - Listado de articulos por categoria");
            Console.WriteLine("3 - Crear Articulo");
            Console.WriteLine("4 - Filtrar publicaciones por fecha");
            Console.WriteLine("0 - Salir");
        }
    }
}
