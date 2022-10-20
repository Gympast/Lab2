namespace Lab2;

public class Kund
{
	private string _person;

	public string Person
	{
		get { return _person; }
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

        return false;
    }

    public void ToString()
    {
        Console.WriteLine($"Användare: {Person}");
        Console.WriteLine();
        Console.WriteLine($"Lösenord: {Password}");
        Console.WriteLine();
        var total = 0;
        var MjölkCount = 0;
        var MjödCount = 0;
        var MjölCount = 0;
        var NotEmpty = false;

        
        foreach (var produkter in Cart)
        {
            if (produkter.Produkt == "Mjölk")
            {
                MjölkCount++;
                NotEmpty = true;
            }

            if (produkter.Produkt == "Mjöd")
            {
                MjödCount++;
                NotEmpty = true;
            }

            if (produkter.Produkt == "Mjöl")
            {
                MjölCount++;
                NotEmpty = true;
            }
            
            total += produkter.Pris;
        }

        if (MjölCount > 0)
        {
            Console.WriteLine($"Antal Mjöl: {MjölCount}");
        }

        if (MjödCount > 0)
        {
            Console.WriteLine($"Antal Mjöd: {MjödCount}");
        }

        if (MjölkCount > 0)
        {
            Console.WriteLine($"Antal Mjölk: {MjölkCount}");
        }
        
        if (NotEmpty)
        {
            Console.WriteLine();
            Console.WriteLine($"Antal artiklar: {Cart.Count}\nTotal summa: {total}:-");
        }
        else
        {
            Console.WriteLine("Kundvagnen är tom");
        }
    }

}