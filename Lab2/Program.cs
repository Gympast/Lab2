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




void Login()
{
    bool password = false;
    bool FelAnvändare = true;

    Console.Write("Skriv in ditt namn: ");
    var använd = Console.ReadLine();
    
    foreach (var kund in kundLista)
    {
        if (kund.Person == använd.ToLower())
        {
            Console.Write("Skriv in ditt lösenord: ");
            

            int Försök = 0;

            while (Försök < 3 ) 
            {
                var pass = Console.ReadLine();
                if (kund.KollaLösenord(pass))
                {
                    aktivanvändare = kund;
                    startMeny = false;
                    InloggadMeny();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Felaktigt lösenord. Prova igen");
                    Försök++;
                }
            }
            if (Försök == 3)
            {
                Console.Clear();
                Console.WriteLine("Förmånga felaktiga försök");
                Console.WriteLine("Återgår till huvudmeny...");
                Thread.Sleep(1500);
                Console.Clear();
                startMeny = true;
                HuvudMeny();
                break;
            }
        }

        startMeny = true;
    }
    Console.Clear();
    Console.WriteLine("Användaren finns ej. Önskas lägga till en ny användare?");

    
    while (FelAnvändare)
    {
        Console.WriteLine("1. Ny användare");
        Console.WriteLine("2. Återgå till huvudmeny");
        string val = Console.ReadLine();
        switch (val)
        {
            case "1":
                Console.Clear();
                LäggTillAnvändare();
                FelAnvändare = false;
                break;

            case "2":
                Console.Clear();
                FelAnvändare = false;
                break;

            default:
                Console.Clear();
                Console.WriteLine("Välj alternativ 1 eller 2");
                break;
        }
    }

}

void VisaProdukter()
{
    Console.WriteLine("Vilken produkt önskas köpa?");
    foreach (var produkter in prodLista)
    {
        Console.WriteLine($"{produkter.Produkt} pris: {produkter.Pris}:-");
    }
}

void LäggTillAnvändare()
{
    bool ejUpptaget = true;
    Console.Write("Skriv in ditt namn: ");
    string namn = Console.ReadLine();
    if (namn == "e")
    {
        Console.Clear();
        HuvudMeny();
        
    }

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
        Console.Clear();

    }
    else
    {
        Console.Clear();
        Console.WriteLine("Namnet är redan taget, vänligen försök igen");
        
    }
}

void Shop()
{
    bool FinnsEJ = true;
    Console.WriteLine("Skriv in vilken vara som önskas läggas till");
    var inputProd = Console.ReadLine();
    foreach (var produkt in prodLista)
    {
        if (produkt.Produkt.ToLower() == inputProd.ToLower())
        {
            aktivanvändare.Cart.Add(produkt);
            Console.Clear();
            Console.WriteLine($"La till {inputProd} i kundvagnen");
            Console.WriteLine();
            FinnsEJ = false;
            break;
        }

    }

    if (FinnsEJ)
    {
        Console.Clear();
        Console.WriteLine("Produkten finns ej i sortimentet");
        Console.WriteLine();
    }

}

void HuvudMeny()
{

    Console.WriteLine("Välkommen! Hur kan jag hjälpa dig idag?");

    while (startMeny)
    {
        
        Console.WriteLine("1. Lägg till användare.");
        Console.WriteLine("2. Logga in.");
        Console.WriteLine("3. Avsluta program.");

        var val1 = Console.ReadLine();
        

        switch (val1)
        {
            case "1":
                Console.Clear();
                LäggTillAnvändare();
                break;

            case "2":
                Console.Clear();
                startMeny = false;
                Login();
                break;

            case "3":
                Console.Clear();
                Environment.Exit(0);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Vänligen välj 1, 2 eller 3.");
                break;
        }
    }
}

//void SeKundvagn()
//{
//    Console.Clear();
//    int total = 0;
//    foreach (var prod in aktivanvändare.Cart)
//    {
//        Console.WriteLine($"{prod.Produkt} Pris: {prod.Pris}:-");
//        total += prod.Pris;
//    }

//    if (total == 0)
//    {
//        Console.WriteLine("Varukorgen är tom");
//    }
//    else
//    {
//        Console.WriteLine($"Total Kostnad: {total}:-");
//    }
//}

void InloggadMeny()
{
    Console.Clear();
    bool shopping = true;

    Console.WriteLine($"Hej {aktivanvändare.Person}! Vad önskas?");

    while (shopping){
    
        Console.WriteLine("1. Lägg till varor");
        Console.WriteLine("2. Se kundkorg");
        Console.WriteLine("3. Töm kundkorg");
        Console.WriteLine("4. Se info angående aktiv användare");
        Console.WriteLine("5. Logga ut");

        string Val = Console.ReadLine();

        switch (Val)
        {
            case "1":
                Console.Clear();
                VisaProdukter();
                Shop();
                break;

            case "2":
                Console.Clear();
                //SeKundvagn();
                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tangent för att komma vidare");
                Console.ReadKey();
                Console.Clear();
                break;

            case "3":
                string Vagn = "Tömmer Kundvagn.";
                Console.Clear();
                for (int mil = 1000; mil < 1003; mil++)
                {
                    Console.WriteLine(Vagn);
                    Thread.Sleep(mil);
                    Vagn += ".";
                    Console.Clear();
                }
                aktivanvändare.Cart.Clear();
                Console.Clear();
                break;

            case "4":
                Console.Clear();
                aktivanvändare.ToString();
                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tangent för att komma vidare");
                Console.ReadKey();
                Console.Clear();
                break;

            case "5":
                aktivanvändare = null;
                shopping = false;
                Console.Clear();
                startMeny = true;
                HuvudMeny();
                break;
            

            default:
                Console.Clear();
                Console.WriteLine("Vändligen välj något av nedanstående");
                break;
    }
}
}