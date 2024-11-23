namespace Obligatorio2.Models
{
    // Clase base Usuario
    public class Usuario
    {
        // Propiedades comunes a todos los usuarios
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        // La contraseña debe ser privada y manejada de forma segura (se podría usar hashing en un sistema más avanzado)
        public string Password { get; set; }

        // Constructor por defecto
        public Usuario() { }

        // Constructor con parámetros
        public Usuario(int userId, string name, string lastname, string email, string password)
        {
            UserId = userId;
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
        }
    }

    // Clase Cliente que hereda de Usuario
    public class Cliente : Usuario
    {
        // Propiedad específica de Cliente
        public decimal SaldoDisponible { get; set; }

        // Constructor por defecto
        public Cliente() { }

        // Constructor con parámetros
        public Cliente(int userId, string name, string lastname, string email, string password, decimal saldoDisponible)
            : base(userId, name, lastname, email, password) // Llama al constructor de la clase base
        {
            SaldoDisponible = saldoDisponible;
        }
    }

    // Clase Administrador que hereda de Usuario
    public class Administrador : Usuario
    {
        // Constructor por defecto
        public Administrador() { }

        // Constructor con parámetros
        public Administrador(int userId, string name, string lastname, string email, string password)
            : base(userId, name, lastname, email, password) // Llama al constructor de la clase base
        {
        }
    }
}
