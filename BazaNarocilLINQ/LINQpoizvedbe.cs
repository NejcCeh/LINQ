
using SpletnoNarociloBaza;

namespace BazaNarocilLINQ
{
    internal class LINQpoizvedbe
    {
        static void Main(string[] args)
        { 
            // Metodna sintaksa

            using (var db = new DBKontekst())
            {
                var narocila50 = db.Narocila.Where(n => n.CenaNarocila > 50 && 100 > n.CenaNarocila).ToList();

                Console.WriteLine("Naročila z zneskom med 50 in 100e:");
                foreach (var narocilo in narocila50)
                {
                    Console.WriteLine($"{narocilo.Id}: {narocilo.CenaNarocila}e");
                }

                var narocilaNarocnik = db.Narocila.Where(n => n.NarocnikId == 1).ToList();

                Console.WriteLine("Naročila naročnika z id 1:");
                foreach (var narocilo in narocilaNarocnik)
                {
                    Console.WriteLine($"{narocilo.Id} : {narocilo.NarocnikId} : {narocilo.DatumNarocila} : {narocilo.CenaNarocila} : {narocilo.Status}");
                }

                var VsiNarocinikiZIstimImenom = db.Narocniki.Where(narocnik => narocnik.Ime.Contains("Nejc")).ToList();

                Console.WriteLine("Naročniki z imenom Nejc");
                foreach (Narocnik narocnik in VsiNarocinikiZIstimImenom)
                {
                    Console.WriteLine($"{narocnik.Id} : {narocnik.Ime} : {narocnik.Email}");
                }

                var zacetniDatum = new DateTime(2024, 12, 1);
                var koncniDatum = new DateTime(2025, 1, 1);
                var NarocilaDatum = db.Narocila.Where(n => n.DatumNarocila > zacetniDatum && koncniDatum > n.DatumNarocila).ToList();

                Console.WriteLine("Naročila za določeno datumsko obdobje");
                foreach (Narocilo narocilo in NarocilaDatum)
                {
                    Console.WriteLine($"{narocilo.Id} : {narocilo.NarocnikId} : {narocilo.DatumNarocila}");
                }


                // JOIN

                var narocilaTadej = db.Narocila
                        .Join(db.Narocniki,
                                narocilo => narocilo.NarocnikId, // Narocila
                                narocnik => narocnik.Id,  // Narocniki
                                (narocilo, narocnik) => new { narocnik.Ime, narocilo.Id, narocilo.Status, narocilo.CenaNarocila }) // katere podatke želimo
                    .Where(n => n.Ime == "Tadej Kopitar")
                    .ToList();
                Console.WriteLine("Naročila za naročnika Tadej Kopitar skupaj z izpisom imena");
                foreach (var n in narocilaTadej)
                {
                    Console.WriteLine($"Naročnik: {n.Ime}, ID naročila: {n.Id}, Status: {n.Status}, Cena: {n.CenaNarocila}");
                }

                var narocila2025 = db.Narocila
                    .Join(db.Narocniki,
                        narocilo => narocilo.NarocnikId,
                        narocnik => narocnik.Id,
                        (narocilo, narocnik) => new {narocnik.Ime, narocilo.DatumNarocila, narocilo.CenaNarocila, narocilo.Status})
                    .Where(n => n.DatumNarocila.Year == 2025).ToList();

                Console.WriteLine("Naročila iz leta 2025 z imenom naročnika");
                foreach (var n in narocila2025)
                {
                    Console.WriteLine($"{n.Ime} : {n.DatumNarocila} : {n.CenaNarocila} : {n.Status}");
                }

                var narocilaNaNarocnika = db.Narocniki
                    .GroupJoin(db.Narocila,
                        narocnik => narocnik.Id,
                        narocilo => narocilo.NarocnikId,
                        (narocnik, narocilo) => new {narocnik.Ime, steviloNarocil = narocilo.Count()})
                    .OrderBy(n => n.steviloNarocil).ToList();

                Console.WriteLine("Števlo naročil na naročnika: ");
                foreach (var n in narocilaNaNarocnika)
                {
                    Console.WriteLine($"{n.Ime} : {n.steviloNarocil}");
                }
            }
        }
    }
}
