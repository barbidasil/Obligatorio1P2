using LogicaNegocio;

namespace Libreria
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                                    Console.WriteLine("$ - {articulo.Name}");
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
                        //CrearArticulo();
                    break;
                    case "4":
                        //FiltrarPorFecha();
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
                    Console.WriteLine($"Cliente: {cliente.Name}");
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
