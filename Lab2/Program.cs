using System.Threading.Channels;
using Lab2;

var kundLista = new List<Kund>();
var prodLista = new List<Produkter>();

kundLista.Add(new Kund { Password = "123", Person = "Knatte" });
kundLista.Add(new Kund { Password = "321", Person = "Fnatte" });
kundLista.Add(new Kund { Password = "213", Person = "Tjatte" });

prodLista.Add(new Produkter { Produkt = "Mjöd", Pris = 25 });
prodLista.Add(new Produkter { Produkt = "Mjöl", Pris = 20 });
prodLista.Add(new Produkter { Produkt = "Mjölk", Pris = 15 });

Kund? aktivanvändare = null;



bool startMeny = true;

HuvudMeny();

VisaProdukter();

Shop();

SeInfo();

void Login()
{
    bool password = false;

    Console.Write("Skriv in ditt namn: ");
    var använd = Console.ReadLine();
    foreach (var kund in kundLista)
    {
        if (kund.Person == använd.ToLower())
        {
            Console.Write("Skriv in ditt lösenord: ");
            var pass = Console.ReadLine();

            if (kund.KollaLösenord(pass))
            {
                password = true;
                aktivanvändare = kund;
                startMeny = false;
                break;
            }
        }

        if (password)
        {
            break;
        }
        startMeny = true;
    }

    if (password)
    {
        Console.WriteLine("true");

    }
    else if(aktivanvändare is null)
    {
        
    }

}

void VisaProdukter()
{
    Console.WriteLine("Vilken produkt önskas köpa?");
    int i = 1;
    foreach (var produkter in prodLista)
    {
        Console.WriteLine($"{i}. {produkter.Produkt} pris: {produkter.Pris}:-");
        i++;
    }
}

void LäggTillAnvändare()
{
    bool ejUpptaget = true;
    Console.Write("Skriv in ditt namn: ");
    string namn = Console.ReadLine();

    foreach (var kund in kundLista)
    {
        if (kund.Person == namn)
        {
            ejUpptaget = false;
        }
    }

    if (ejUpptaget)
    {
        Console.Write("välj ett lösenord: ");
        string pass = Console.ReadLine();

        kundLista.Add(new Kund { Password = pass, Person = namn });

    }
    else
    {
        Console.Clear();
        Console.WriteLine("Namnet är redan taget, vänligen välj ett annat");
    }
}

void Shop()
{
    var inputProd = Console.ReadLine();
    foreach (var produkt in prodLista)
    {
        if (produkt.Produkt.ToLower() == inputProd.ToLower())
        {
            aktivanvändare.Cart.Add(produkt);
        }
    }
}

void HuvudMeny()
{
    Console.WriteLine("Välkommen! Hur kan jag hjälpa dig idag?");

    while (startMeny)
    {
        Console.WriteLine("1. Lägg till användare.");
        Console.WriteLine("2. Logga in.");

        int val1 = int.Parse(Console.ReadLine());

        switch (val1)
        {
            case 1:
                LäggTillAnvändare();
                break;

            case 2:
                startMeny = false;
                Login();
                break;

            default:
                Console.WriteLine("Vänligen välj 1 eller 2.");
                break;
        }
    }
}

void SeInfo()
{
    aktivanvändare.ToString();
    foreach (var prod in aktivanvändare.Cart)
    {
        Console.WriteLine($"{prod.Produkt} Pris: {prod.Pris}");
    }
}