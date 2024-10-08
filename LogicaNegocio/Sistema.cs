
namespace LogicaNegocio
{
    public class Sistema
    {
        private static Sistema _instancia;
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Category> _categorias = new List<Category>(); 

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

        public List<Publicacion> Publicacion { get { return _publicaciones; } }
        public List<Usuario> Usuario { get { return _usuarios; } }

        public List<Category> Categoria { get { return _categorias; } }


        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }
        
        public List<Category> ObtenerCategorias()
        {
            return _categorias;
        }

        public List<Article> ListarArticulosPorCat(Category categoria)
        {
            List<Article> articulosPorCat = new List<Article>();

            foreach(Publicacion publicacion in Publicacion)
            {
                foreach( Article articulo in publicacion.Articles)
                {
                    foreach(Category cat in articulo.Category)
                    {
                        if(cat.Id == categoria.Id)
                        {
                            articulosPorCat.Add(articulo);
                            break;
                        }
                    }
                }
            }
            return articulosPorCat;
        }

        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();

        
        }

    }

    

    
}
