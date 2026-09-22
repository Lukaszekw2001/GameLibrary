using System.Linq;

class Gra 
{ 
    public string Tytul { get; set; }
    public string Gatunek { get; set; }
    public int RokWydania { get; set; }
}

class Program 
{
    static void DodajGre(List<Gra> gry)
    {
        Console.WriteLine("Proszę podać nazwę gry.");
        string tytul = Console.ReadLine();

        Console.WriteLine("Proszę podać gatunek gry.");
        string gatunek = Console.ReadLine();

        Console.WriteLine("Proszę podać rok wydania gry.");
        string rokWydania = Console.ReadLine();

        if (int.TryParse(rokWydania, out int rok))
        {
            Gra gra = new Gra();

            gra.Tytul = tytul;
            gra.Gatunek = gatunek;
            gra.RokWydania = rok;

            gry.Add(gra);

            Console.WriteLine("Gra została dodana.");
        }
        else
        {
            Console.WriteLine("Nieprawidłowy rok wydania. Gra nie została dodana.");
        }
    }

    static void WyswietlGry(List<Gra> gry) 
    {
        foreach (Gra gra in gry)
        { 
            Console.WriteLine(gra.Tytul + " / " + gra.Gatunek + " / " + gra.RokWydania); 
        } 
    } 
    
    static void WyszukajGre(List<Gra> gry) 
    { 
        Console.WriteLine("Wpisz tutaj tytuł gry której szukasz: "); 
        string szukaj = Console.ReadLine(); 
        bool istnieje = gry.Any(gra => gra.Tytul == szukaj); 
        if (istnieje) 
        { 
            Console.WriteLine("Gra została znaleziona."); 
        } 
        else 
        { 
            Console.WriteLine("Nie znaleziono takiej gry."); 
        } 
    } 

    static void ZapiszGry(List<Gra> gry)
    {
        List<string> linie = new List<string>();
        foreach (Gra gra in gry)
        {
            string linia = $"{gra.Tytul};{gra.Gatunek};{gra.RokWydania}";
            linie.Add(linia);
        }

        File.WriteAllLines("gry.txt", linie);
        Console.WriteLine("Gry zostały zapisane.");
    }

    static void WczytajGry(List<Gra> gry)
    {
        try
        {
            string[] linie = File.ReadAllLines("gry.txt");

            gry.Clear();

            foreach (string linia in linie)
            {
                string[] czesci = linia.Split(';');

                if (czesci.Length == 3)
                {
                    if (int.TryParse(czesci[2], out int rok))
                    {
                        Gra gra = new Gra();

                        gra.Tytul = czesci[0];
                        gra.Gatunek = czesci[1];
                        gra.RokWydania = rok;

                        gry.Add(gra);
                    }
                }
            }

            Console.WriteLine("Gry zostały wczytane.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik z grami jeszcze nie istnieje.");
        }
    }


    static void Main() 
    { 
        List<Gra> gry = new List<Gra>(); 
        string choice = ""; 
        do 
        { 
            Console.WriteLine("1. Dodaj grę"); 
            Console.WriteLine("2. Wyświetl wszystkie gry"); 
            Console.WriteLine("3. Wyszukaj grę"); 
            Console.WriteLine("4. Zapisz gry");
            Console.WriteLine("5. Wczytaj gry");
            Console.WriteLine("6. Zakończ");
            
            choice = Console.ReadLine(); 

            if (choice == "1") 
            { 
                DodajGre(gry); 
            } 
            else if (choice == "2") 
            { 
                WyswietlGry(gry); 
            } 
            else if (choice == "3") 
            { 
                WyszukajGre(gry); 
            }
            else if (choice == "4")
            {
                ZapiszGry(gry);
            }
            else if (choice == "5")
            {
                WczytajGry(gry);
            }
            else if (choice == "6") 
            { 
                Console.WriteLine("Koniec programu."); 
            } 
            else 
            { 
                Console.WriteLine("Zły wybór. Proszę wybrać jedną z dostępnych opcji."); 
            } 
        } while (choice != "6"); 
    } 
}