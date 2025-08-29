using SpletnoNarociloBaza;

namespace BazaNarocilLINQ2
{
    internal class LINQPoizvedbe2
    {
        static void Main(string[] args)
        {
            // Poizvedbena sintaksa


            using(var db = new DBKontekst())
            {
                var narocila50 =
                    from n in db.Narocila
                    where n.CenaNarocila > 50 && n.CenaNarocila < 100
                    select n;

                Console.WriteLine("Naročila z zneskom med 50 in 100e:");
                foreach (var narocilo in narocila50)
                {
                    Console.WriteLine($"{narocilo.Id}: {narocilo.CenaNarocila}e");
                }

                var narocilaNarocnik = 
                    from n in db.Narocila
                    where n.NarocnikId == 1
                    select n;

                Console.WriteLine("Naročila naročnika z id 1:");
                foreach (var narocilo in narocilaNarocnik)
                {
                    Console.WriteLine($"{narocilo.Id} : {narocilo.NarocnikId} : {narocilo.DatumNarocila} : {narocilo.CenaNarocila} : {narocilo.Status}");
                }

                var VsiNarocinikiZIstimImenom = "";

                //Console.WriteLine("Naročniki z imenom Nejc");
                //foreach (Narocnik narocnik in VsiNarocinikiZIstimImenom)
                //{
                //    Console.WriteLine($"{narocnik.Id} : {narocnik.Ime} : {narocnik.Email}");
                //}

                var zacetniDatum = new DateTime(2024, 12, 1);
                var koncniDatum = new DateTime(2025, 1, 1);
                var NarocilaDatum = "";
                
                //Console.WriteLine("Naročila za določeno datumsko obdobje");
                //foreach (Narocilo narocilo in NarocilaDatum)
                //{
                //    Console.WriteLine($"{narocilo.Id} : {narocilo.NarocnikId} : {narocilo.DatumNarocila}");
                //}


                //JOIN


                var narocilaTadej =
                    from narocilo in db.Narocila
                    join narocnik in db.Narocniki on narocilo.NarocnikId equals narocnik.Id
                    where narocnik.Ime == "Tadej Kopitar"
                    select new { narocnik.Ime, narocilo.Id, narocilo.Status, narocilo.CenaNarocila};
                Console.WriteLine("Naročila za naročnika Tadej Kopitar skupaj z izpisom imena");
                foreach (var n in narocilaTadej)
                {
                    Console.WriteLine($"Naročnik: {n.Ime}, ID naročila: {n.Id}, Status: {n.Status}, Cena: {n.CenaNarocila}");
                }


                var narocila2025 = "";

                //Console.WriteLine("Naročila iz leta 2025 z imenom naročnika");
                //foreach (var n in narocila2025)
                //{
                //    Console.WriteLine($"{n.Ime} : {n.DatumNarocila} : {n.CenaNarocila} : {n.Status}");
                //}

                var narocilaNaNarocnika = "";

                //Console.WriteLine("Števlo naročil na naročnika: ");
                //foreach (var n in narocilaNaNarocnika)
                //{
                //    Console.WriteLine($"{n.Ime} : {n.steviloNarocil}");
                //}
            }
        }
    }
}
