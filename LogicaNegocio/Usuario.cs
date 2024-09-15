using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal class Usuario
    {
        private static int s_ultimoId = 0;

        private int _userId;
        private string _name;
        private string _lastname;
        private string _email;
        private string _password;


        public int UserId
        {
            get { return _userId; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Usuario()
        {
            Usuario.s_ultimoId++;
            this._userId = Usuario.s_ultimoId;
        }

        public Usuario(string name, string lastname, string email, string password)
        {
            Usuario.s_ultimoId++;
            this._userId = Usuario.s_ultimoId;
            this._name = name;
            this._lastname = lastname;
            this._email = email;
            this._password = password;
        }

        public override string ToString()
        {
            return this._name;
        }

    }
}
