using Microsoft.EntityFrameworkCore;

namespace SpletnoNarociloBaza
{
    internal class DataZaBazo
    {
        static void Main(string[] args)
        {
            using(var kontekst = new DBKontekst())
            {
                //kontekst.Narocila.RemoveRange(kontekst.Narocila);
                //kontekst.Narocniki.RemoveRange(kontekst.Narocniki);
                //kontekst.SaveChanges();

                Random rnd = new Random();
                
                //tabeli imen in priimkov za bazo
                var imena = new List<string> { "Nejc", "Matej", "Ana", "Janez", "Bojan", "Eva", "Marko", "Sara", "Miha", "Luka",
                                           "Tina", "Katja", "Rok", "Zoran", "Vanja", "Uros", "Nina", "Tadej", "Igor", "Manca" };
                var priimki = new List<string> { "Novak", "Horvat", "Kralj", "Zupan", "Kovacic", "Vidmar", "Turk", "Rozman", "Jug", "Koren",
                                             "Simic", "Bozic", "Majcen", "Petek", "Dolar", "Kranjc", "Peric", "Kopitar", "Strnad" };

                HashSet<string> unikatniUporabniki = new HashSet<string>();
                List<Narocnik> narocniki = new List<Narocnik>();

                //Generiranje 50 unikatnih narocnikov
                while(narocniki.Count < 50)
                {
                    string ime = imena[rnd.Next(imena.Count)];
                    string priimek = priimki[rnd.Next(priimki.Count)];
                    string email = $"{priimek.ToLower()}.{ime.ToLower()}@gmail.com";

                    if (!unikatniUporabniki.Contains(email))
                    {
                        var narocnik = new Narocnik { Ime = $"{ime} {priimek}", Email = email };
                        narocniki.Add(narocnik);
                        unikatniUporabniki.Add(email);
                    }
                }

                kontekst.Narocniki.AddRange(narocniki);
                kontekst.SaveChanges();

                // generacija narocila za vsakega narocnika
                List<Narocilo> narocila = new List<Narocilo>();
                var statusi = new List<string> { "V obdelavi", "Zaključeno", "Preklicano", "Na poti" };
                foreach (var narocnik in kontekst.Narocniki.ToList())
                {
                    int steviloNarocil = rnd.Next(1, 5); // število naročil na naročnika
                    for (int j = 0; j < steviloNarocil; j++)
                    {
                        var narocilo = new Narocilo
                        {
                            NarocnikId = narocnik.Id,
                            DatumNarocila = DateTime.Now.AddDays(-rnd.Next(1, 365)).Date, // naključni datumi v preteklem obdobju 365 dni
                            Status = statusi[rnd.Next(statusi.Count)],
                            CenaNarocila = Math.Round((decimal)(rnd.NextDouble() * 200 + 10), 2) // nakljucna cena med 10 in 200e
                        };
                        narocila.Add(narocilo);
                    }
                }

                kontekst.Narocila.AddRange(narocila);
                kontekst.SaveChanges();

                Console.WriteLine("Naročila in naročniki uspešno dodani!");
            }
        }
    }
}
