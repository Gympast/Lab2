namespace Lab2;

public class Kund
{
	private string _person;

	public string Person
	{
		get { return _person.ToLower(); }
		set { _person = value; }
	}

	private string _password;

	public string Password
	{
		get { return _password; }
		set { _password = value; }
	}

    private List<Produkter> _cart = new List<Produkter>();

    public List<Produkter> Cart
    {
        get { return _cart;}
        set { Cart = value; }
    }

	public bool KollaLösenord(string pass)
	{
        if (pass == _password)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Fel lösenord");
            return false;
        }

    }

    public void ToString()
    {
        Console.WriteLine($"Användare: {Person}");
        Console.WriteLine($"Lösenord; {Password}");
    }

}