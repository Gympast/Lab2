using System.Threading.Channels;
using Lab2;

var KundLista = new List<Kund>();
var ProdLista = new List<Produkter>();

KundLista.Add(new Kund{Password = "123", Person = "Knatte"});
KundLista.Add(new Kund{Password = "321", Person = "Fnatte"});
KundLista.Add(new Kund{Password = "213", Person = "Tjatte"});

ProdLista.Add(new Produkter{Produkt = "Mjöd", Pris = 25});
ProdLista.Add(new Produkter{Produkt = "Mjöl", Pris = 20});
ProdLista.Add(new Produkter{Produkt = "Mjölk", Pris = 15});

Console.WriteLine("lägg till användare");

LäggTillAnvändare();

Login();

void Login()
{
    Console.Write("Skriv in ditt namn: ");
    var använd = Console.ReadLine();
    Console.WriteLine("Skriv in ditt lösenord");
    var pass = Console.ReadLine();

    foreach (var kund in KundLista)
    {
        if (kund.Person == använd)
        {
            if (kund.KollaLösenord(pass))
            {
                Console.WriteLine("true");
            }
        }
    }
}

void VisaProdukter()
{
    Console.WriteLine("Vilken produkt önskas köpa? Välj med siffror");
    int i = 1;
    foreach (var produkter in ProdLista)
    {
        Console.WriteLine($"{i}. {produkter.Produkt} pris: {produkter.Pris}:-");
        i++;
    }
}

void LäggTillAnvändare()
{
    Console.Write("Skriv in ditt namn: ");
    string namn = Console.ReadLine();
    Console.Write("välj ett lösenord: ");
    string pass = Console.ReadLine();

    KundLista.Add(new Kund{Password = pass, Person = namn});
}