using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpletnoNarociloBaza
{
    public class Narocilo
    {
        [Key] // primarni kljuc
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Samodejni ID
        public int Id { get; set; }
        [ForeignKey("Narocnik")] // tuji kljuc
        public int NarocnikId { get; set; }
        public DateTime DatumNarocila { get; set; }
        public string Status { get; set; }
        public decimal CenaNarocila { get; set; }

        public Narocnik Narocnik { get; set; } // referenca na narocnika
    }
}
