
public class Usuario
{
    
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

    public Usuario(int userId, string name, string lastname, string email, string password)
    {
        _userId = userId;
        _name = name;
        _lastname = lastname;
        _email = email;
        _password = password;
    }
}

public class Cliente : Usuario
{
    
    private decimal _saldoDisponible;

    public decimal SaldoDisponible
    {
        get { return _saldoDisponible; }
        set { _saldoDisponible = value; }
    }

    // Constructor
    public Cliente(int userId, string name, string lastname, string email, string password, decimal saldoDisponible)
        : base(userId, name, lastname, email, password) // Llama al constructor de Usuario
    {
        _saldoDisponible = saldoDisponible;
    }
}

// Clase Administrador que hereda de Usuario
public class Administrador : Usuario
{
    // Constructor
    public Administrador(int userId, string name, string lastname, string email, string password)
        : base(userId, name, lastname, email, password) 
    {
       
    }
}
