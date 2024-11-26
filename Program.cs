using System.ComponentModel;

namespace Áruház_rendszer
{
    internal class Program
    {

        static string[] raktarTermekek = new string[10];
        static int[] raktarMennyisegek = new int[10];
        static int[] termekAr = new int[10];

        static List<string> vasarlolista = new List<string>();
        static List<int> mennyisegek = new List<int>();

        static void Main()
        {
            bool fut = true;
            while (fut)
            {
                Console.WriteLine();
                Console.WriteLine("Válassz az alábbui opciók közül:\n1.: Raktárkészlet megtekintése\n2.: Vasárlókosárba hozzáadás\n3.: Vásárlási kosár megtekintése\n4.: Termek eltávoltása a kosárból\n5.: Raktár frissítés\n6.: Vásárlás szimuláció\n7.: Legdrágább termék\n8.: Legolcsóbb termék\n9.: Kosár ürítése\n10.: Kosár statisztika\n11.: Raktár Ellenőrzés\n12.: Kosár jelenlegi értéke\n13.: Termékek rendezése ár szerint");
                int opcio = Convert.ToInt32(Console.ReadLine());

                switch (opcio)
                {
                    case 1:
                        Console.Clear();
                        Raktarmegtekintes();
                        break;

                    case 2:
                        Console.Clear();
                        Hozzaadas();
                        break;

                    case 3:
                        Console.Clear();
                        ListaMegtekintes();
                        break;

                    case 4:
                        Console.Clear();
                        Torles();
                        break;

                    case 5:
                        Console.Clear();
                        RaktarFriss();
                        break;

                    case 6:
                        Console.Clear();
                        VasarlasSim();
                        break;

                    case 7:
                        Console.Clear();
                        draga();
                        break;

                    case 8:
                        Console.Clear();
                        ocso();
                        break;

                    case 9:
                        Console.Clear();
                        Uristes();
                        break;

                    case 10:
                        Console.Clear();
                        KosarStatisztika();
                        break;

                    case 11:
                        Console.Clear();
                        RaktarEllenorzes();
                        break;

                    case 12:
                        Console.Clear();
                        KosarErteke();
                        break;

                    case 13:
                        Console.Clear();
                        TermekekRendezese();
                        break;
                        
                }
            }
        }

        static void Raktarmegtekintes()
        {
            Console.WriteLine("Raktárkészlet:");
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (raktarTermekek[i] == null)
                {
                    Console.WriteLine($"- Nincs termék a {i + 1}. helyen.");
                }
                else
                {
                    Console.WriteLine($"- {raktarTermekek[i]}: {raktarMennyisegek[i]} db; Ár: {termekAr[i]}");
                }
            }
        }

        static void Hozzaadas()
        {
            Console.Write("Add meg a termék nevét: ");
            string termek = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(termek))
            {
                Console.WriteLine("A termék neve nem lehet üres!");
                return;
            }

            Console.Write("Add meg a mennyiséget: ");
            string? mennyisegBemenet = Console.ReadLine();

            if (!int.TryParse(mennyisegBemenet, out int mennyiseg) || mennyiseg <= 0)
            {
                Console.WriteLine("A mennyiség nem lehet negatív");
                return;
            }
           
            vasarlolista.Add(termek);
            mennyisegek.Add(mennyiseg);
            

            Console.WriteLine("Termék hozzáadva a bevásárlólistához!");
        }

        static void ListaMegtekintes()
        {
            Console.WriteLine("Bevásárlólista:");
            if (vasarlolista.Any() == false)
            {
                Console.WriteLine("Üres a bevásárló kosarad");
            }
            else
            {
                for (int i = 0; i <= vasarlolista.Count - 1; i++)
                {
                    Console.WriteLine($"- {vasarlolista[i]}: {mennyisegek[i]} db");
                }
            }

        }


        static void Torles()
        {
            Console.WriteLine("Termék neve: ");
            string termek = Convert.ToString(Console.ReadLine()) ?? "";

            if (!vasarlolista.Contains(termek))
            {
                Console.WriteLine("Ilyen termék nincs a bevásárló listádba");
            }
            else
            {
                int index = vasarlolista.IndexOf(termek);
                vasarlolista.RemoveAt(index);
                mennyisegek.RemoveAt(index);
                Console.WriteLine("Termék eltávolítva!");
            }
        }

        static void RaktarFriss()
        {
            Console.Write("Add meg a termék nevét: ");
            string termek = Convert.ToString(Console.ReadLine()) ?? "";


            if (string.IsNullOrWhiteSpace(termek))
            {
                Console.WriteLine("A termék neve nem lehet üres!");
                return;
            }

            int index = Array.IndexOf(raktarTermekek, termek);
            if (index == -1)
            {
                Console.WriteLine("Ez a termék nincs a raktárban! Hozzáadjuk");
                index = Array.IndexOf(raktarTermekek, null);
                if (index == -1)
                {
                    Console.WriteLine("Nincs több hely a raktárban");
                }
                raktarTermekek[index] = termek;
                raktarMennyisegek[index] = 0;
                return;
            }

            Console.Write("Add meg a frissítendő mennyiséget (pozitív/nem negatív szám): ");
            string? mennyisegBemenet = Console.ReadLine();

            if (!int.TryParse(mennyisegBemenet, out int mennyiseg) || mennyiseg <= 0)
            {
                Console.WriteLine("A mennyiség nem lehet üres/negatív");
                return;
            }
            raktarMennyisegek[index] += mennyiseg;


            Console.Write("Add meg a frissítendő árát (pozitív/nem negatív szám): ");
            string? Arbemenet = Console.ReadLine();

            if (!int.TryParse(Arbemenet, out int TermekAr) || TermekAr <= 0)
            {
                Console.WriteLine("A mennyiség nem lehet üres/negatív");
                return;
            }
            termekAr[index] += TermekAr;

            Console.WriteLine("A raktárkészlet frissítve!");
        }

        static void Uristes()
        {
            for (int i = 0; i < vasarlolista.Count; i++)
            {
                string termek = vasarlolista[i];
                int mennyiseg = mennyisegek[i];
                int index = Array.IndexOf(raktarTermekek, termek);
                raktarMennyisegek[index] += mennyiseg;

            }
            vasarlolista.Clear();
        }


        static void VasarlasSim()
        {
            Console.WriteLine("Bevásárlás folyamatban...");
            int elkoltottPenz = 0;

            for (int i = 0; i < vasarlolista.Count; i++)
            {
                string termek = vasarlolista[i];
                int mennyiseg = mennyisegek[i];

                int index = Array.IndexOf(raktarTermekek, termek);
                if (index == -1)
                {
                    Console.WriteLine($"Nincs a raktárban: {termek}");
                    continue;
                }

                if (raktarMennyisegek[index] < mennyiseg)
                {
                    Console.WriteLine($"Nincs elég {termek} a raktárban!");
                }
                else
                {
                    raktarMennyisegek[index] -= mennyiseg;
                    elkoltottPenz += termekAr[index] * mennyiseg;
                    Console.WriteLine($"Sikeresen megvásárolt: {termek}, {mennyiseg} db.");
                }
            }
            vasarlolista.Clear();

            Console.WriteLine($"Elköltött pénz: {elkoltottPenz}");
        }


        static void draga()
        {
            int legdragabb = 0;
            string neve = "";
            for (int i = 0; i < termekAr.Length; i++)
            {
                if (termekAr[i] > legdragabb)
                {
                    legdragabb = termekAr[i];
                    neve = raktarTermekek[i];
                }
            }
            Console.WriteLine($"A legdrágább termék a raktárban: {neve} aminek az ára {legdragabb}");
        }

        static void ocso()
        {

            int ocso = termekAr.Min();
            
            Console.WriteLine($"A legdrágább termék az ára a raktárban {ocso}");
        }

        static void KosarStatisztika()
        {
            Console.WriteLine($"Kosárban található termékek száma: {vasarlolista.Count}");
            Console.WriteLine($"Különböző termékek száma: {vasarlolista.Distinct().Count()}");
        }


        static void RaktarEllenorzes()
        {
            Console.WriteLine("Termékek, melyek készlete 5 alatt van:");
            for (int i = 0; i < raktarMennyisegek.Length; i++)
            {
                if (raktarMennyisegek[i] > 0 && raktarMennyisegek[i] < 5)
                {
                    Console.WriteLine($"- {raktarTermekek[i]}: {raktarMennyisegek[i]} db");
                }
            }
        }


        static void KosarErteke()
        {
            int total = 0;
            for (int i = 0; i < vasarlolista.Count; i++)
            {
                string termek = vasarlolista[i];
                int mennyiseg = mennyisegek[i];
                int index = Array.IndexOf(raktarTermekek, termek);

                if (index != -1)
                {
                    total += termekAr[index] * mennyiseg;
                }
            }

            Console.WriteLine($"Kosár teljes értéke: {total} Ft");
        }

        static void TermekekRendezese()
        {
            var rendezett = raktarTermekek
                .Select((t, i) => new { Termek = t, Ar = termekAr[i], Mennyiseg = raktarMennyisegek[i] })
                .Where(x => x.Termek != null)
                .OrderBy(x => x.Ar)
                .ToList();

            Console.WriteLine("Rendezett termékek ár szerint:");
            foreach (var t in rendezett)
            {
                Console.WriteLine($"- {t.Termek}: {t.Mennyiseg} db, Ár: {t.Ar}");
            }
        }
    }
}
