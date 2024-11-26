namespace Obligatorio2.Models
{
    // Clase base Usuario
    public class Usuario
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public Usuario() { }

     
        public Usuario(int userId, string name, string lastname, string email, string password)
        {
            UserId = userId;
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
        }
    }

 
    public class Cliente : Usuario
    {
       
        public decimal SaldoDisponible { get; set; }

        
        public Cliente() { }

        public Cliente(int userId, string name, string lastname, string email, string password, decimal saldoDisponible)
            : base(userId, name, lastname, email, password)
        {
            SaldoDisponible = saldoDisponible;
        }
    }


    public class Administrador : Usuario
    {

        public Administrador() { }

        public Administrador(int userId, string name, string lastname, string email, string password)
            : base(userId, name, lastname, email, password) 
        {
        }
    }
}
