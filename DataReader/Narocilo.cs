using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    public class Narocilo
    {
        public int Id { get; set; }
        public int NarocnikId { get; set; }
        public DateTime DatumNarocila { get; set; }
        public string Status { get; set; }
        public decimal CenaNarocila { get; set; }
    }
}
