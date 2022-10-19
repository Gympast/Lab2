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
        Console.WriteLine();
        Console.WriteLine($"Lösenord; {Password}");
        Console.WriteLine();
        var total = 0;
        var MjölkCount = 0;
        var MjödCount = 0;
        var MjölCount = 0;

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
                MjölCount++;
            }
            
            total += produkter.Pris;
        }

        if (MjölCount > 0)
        {
            Console.WriteLine($"Antal Mjöl: {MjölCount}");
        }

        if (MjödCount < 0)
        {
            Console.WriteLine($"Antal Mjöd: {MjödCount}");
        }

        if (MjölkCount < 0)
        {
            Console.WriteLine($"Antal Möjlk: {MjölkCount}");
        }
        Console.WriteLine();
        Console.WriteLine($"Total summa: {total}");
    }

}