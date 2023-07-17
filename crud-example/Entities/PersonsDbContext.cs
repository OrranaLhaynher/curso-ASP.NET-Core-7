using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class PersonsDbContext : DbContext //cada um desses DbContext é um banco
    {
        public DbSet<Country> Countries { get; set; } //cada um desses é uma tabela
        public DbSet<Person> Persons { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");
        }
    }
}
