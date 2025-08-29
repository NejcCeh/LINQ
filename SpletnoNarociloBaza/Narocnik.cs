using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpletnoNarociloBaza
{
    public class Narocnik
    {
        [Key] // primarni kljuc
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Samodejno generiranje ID
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Email { get; set; }

        public List<Narocilo> Narocila { get; set; } // povežemo naročnika in naročila
    
    }
}
