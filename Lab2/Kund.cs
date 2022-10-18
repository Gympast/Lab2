namespace Lab2;

public class Kund
{
	private string _person;

	public string Person
	{
		get { return _person; }
		set { _person = value.ToLower(); }
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
        int total = 0;
        int MjölkCount = 0;
        int MjödCount = 0;
        int MjölCOunt = 0;

        //contains
        foreach (var produkter in Cart)
        {
            if (produkter.Produkt == "Mjölk")
            {
                MjölkCount++;
            }

            if (produkter.Produkt == "Mjöd")
            {
                MjödCount++;
            }

            if (produkter.Produkt == "Mjöl")
            {
                MjölkCount++;
            }
            
            total += produkter.Pris;
        }

        Console.WriteLine($"Antal Mjölk: {MjölkCount}");
        Console.WriteLine($"Antal Mjöd: {MjödCount}");
        Console.WriteLine($"Antal Mjöl: {MjölCOunt}");

        Console.WriteLine($"Total summa: {total}");
    }

}