using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    internal class Sistema
    {
        // Lista de publicaciones
        private List<Publicacion> _publicaciones = new List<Publicacion>();

        // Getter y Setter para la lista de publicaciones
        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
            set { _publicaciones = value; }
        }

        // Lista de usuarios
        private List<Usuario> _usuarios = new List<Usuario>();

        // Getter y Setter para la lista de usuarios
        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }

    }

    // Definición de clases básicas para Usuario y Publicacion
    public class Usuario
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Constructor
        public Usuario(int userId, string name, string email)
        {
            UserId = userId;
            Name = name;
            Email = email;
        }
    }

    public class Publicacion
    {
        public int IdP { get; set; }
        public string Name { get; set; }

        // Constructor
        public Publicacion(int idP, string name)
        {
            IdP = idP;
            Name = name;
        }
    }
}
w