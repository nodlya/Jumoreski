using Microsoft.EntityFrameworkCore;

namespace ParseJumoreski
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Jumoreski> Jumoreskis { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Jumoreski.db");
        }

    }

    public class Jumoreski
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Jumoreski(string text)
        {
            Text = text;
        }
    }
}
