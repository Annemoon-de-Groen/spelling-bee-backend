using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api_cinema_challenge.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>().HasData(
                
                new Players { Id = 1, FirstName = "Hannelieke", LastName = "Hoogenboom", Bio = "Hannelieke speelt al sinds haar vierde toneel. Ze doet zowel musicals als theatervoorstellingen. Idk wat ze nog meer doet dus bla bla bla", Functie = "acteur, regisseur, vertaler", Rol = "Rona" },
                new Players { Id = 2, FirstName = "Neomi", LastName = "Bes", Bio = "Informatie over Neomi", Functie = "acteur", Rol = "Panch" },
                new Players { Id = 3, FirstName = "Anne-Sophie", LastName = "", Bio = "Informatie over Anne-Sophie", Functie = "acteur, choreograaf", Rol = "Mitch Mahoney" },
                new Players { Id = 4, FirstName = "Diede", LastName = "", Bio = "Informatie over Diede", Functie = "acteur", Rol = "Olive Ostrovsky" },
                new Players { Id = 5, FirstName = "Lotte", LastName = "Hoek", Bio = "Informatie over Lotte", Functie = "acteur", Rol = "Logainne SchwartzandGrubenierre" },
                new Players { Id = 6, FirstName = "Lara", LastName = "", Bio = "Informatie over Lara", Functie = "acteur", Rol = "Marcy Park" },
                new Players { Id = 7, FirstName = "Liza", LastName = "", Bio = "Informatie over Liza", Functie = "acteur", Rol = "William Barfée" },
                new Players { Id = 8, FirstName = "Morris", LastName = "Mooijaart", Bio = "Informatie over Morris", Functie = "acteur", Rol = "Leaf Coneybear" },
                new Players { Id = 9, FirstName = "Quinten", LastName = "van Koeverden", Bio = "Informatie over Quinten", Functie = "acteur", Rol = "Chip Tolentino" }
            );

        }

        public DbSet<Play> Plays { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
