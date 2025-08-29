using Microsoft.EntityFrameworkCore;

namespace SpletnoNarociloBaza
{
    public class DBKontekst : DbContext
    {
        public DbSet<Narocilo> Narocila { get; set; }
        public DbSet<Narocnik> Narocniki { get; set; }

        /// <summary>
        /// Povezava do baze
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string potDoBaze = @"C:\Baze\SpletnoNarociloBaza\spletna_trgovina.sqlite";
            options.UseSqlite($"Data Source={potDoBaze}");
        }

    }
}
