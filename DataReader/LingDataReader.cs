using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;  // Za uporabo List<>
using System.Linq;


namespace DataReader
{
    public class LingDataReader
    {
        static void Main(string[] args)
        {
            string povNiz = "Data Source = C:\\Baze\\SpletnoNarociloBaza\\spletna_trgovina.sqlite";
            using(SqliteConnection pov = new SqliteConnection(povNiz))
            {
                pov.Open();

                using(SqliteCommand ukaz = new SqliteCommand("SELECT * FROM Narocila", pov))
                using (SqliteDataReader rez = ukaz.ExecuteReader())
                {
                    List<Narocilo> narocila = new List<Narocilo>();

                    while (rez.Read())
                    {
                        var narocilo = new Narocilo
                        {
                            Id = rez.GetInt32(0),
                            NarocnikId = rez.GetInt32(1),
                            DatumNarocila = rez.GetDateTime(2),
                            Status = rez.GetString(3),
                            CenaNarocila = rez.GetDecimal(4)
                        };

                        narocila.Add(narocilo);
                    }


                    //Uporabimo LINQ ukaze
                    List<Narocilo> narocilaNad150 = narocila.Where(n => n.CenaNarocila > 150).ToList();
                    Console.WriteLine("Naročila nad 150e: ");
                    foreach(Narocilo narocilo in narocilaNad150)
                    {
                        Console.WriteLine($"ID: {narocilo.Id}, Cena: {narocilo.CenaNarocila}");
                    }

                    List<Narocilo> narocila1 = narocila.Where(n => n.NarocnikId == 1).ToList();
                    foreach (var nar in narocila1) Console.WriteLine(nar.Id);
                    
                }
            }
        }
    }
}
