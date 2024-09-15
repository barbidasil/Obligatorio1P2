namespace Obligatorio1P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO INSTANCIAR SISTEMA

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
                        //MostrarClientes();
                        break;
                    case "2":
                        //MostrarPorCategoria();
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
