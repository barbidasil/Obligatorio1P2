using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Publicacion
    {
        //Console.WriteLine("Prueba Git");

        private static int s_ultimoId = 0;

        private int _idP;
        private string _name;
        private DateTime _publishDate;
        private Status _status;
        private List<Article> _articles = new List<Article> ();
        private Usuario _buyingUser;
        private Usuario _userFinish;
        private DateTime _publicationEnd;


        public int IdP
        {
            get { return _idP; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
                
         }

        public Status Status
        {
            get { return _status;}
            set { _status = value; }
        }

        public List<Article> Articles
        {
            get { return _articles; }        
        }

        private required Usuario _buyingUser
        {
            get { return _buyingUser; }
            set { _buyingUser = value; }
        }

        private required Usuario _userFinish
        {
            get { return _userFinish; }
            set { _userFinish = value; }
        }

        private DateTime PublicationEnd

        {
            get { return _publicationEnd; }
            set { _publicationEnd = value; }
        }

        public Publicacion()
        {
            Publicacion.s_ultimoId++;
            this._idP = Publicacion.s_ultimoId;
        }

        public required Publicacion(int idP, string name, DateTime publishDate, Status status, Usuario buyingUser, Usuario userFinish, DateTime publicationEnd)
        {
            if (buyingUser == null || userFinish == null)
            {
                throw new ArgumentNullException(buyingUser == null ? nameof(buyingUser) : nameof(userFinish));
            }

            Publicacion.s_ultimoId++;
            this._idP = Publicacion.s_ultimoId;
            this._name = name;
            this._publishDate = publishDate;
            this._status = status;
            this._buyingUser = buyingUser;
            this._userFinish = userFinish;
            this._publicationEnd = publicationEnd;
        }

        public override string ToString()
        {
            return this._name;
        }

    }
}
