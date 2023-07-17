using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Entities
{
    public class PersonsDbContext : DbContext //cada um desses DbContext é um banco
    {
        public DbSet<Country> Countries { get; set; } //cada um desses é uma tabela
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");

            //Seed data to Countries
            string countriesJson = File.ReadAllText("countries.json");
            List<Country> countries = JsonSerializer.Deserialize<List<Country>>(countriesJson)!;

            foreach (Country country in countries)
            {
                modelBuilder.Entity<Country>().HasData(country);
            }

            //Seed data to Persons
            string personsJson = File.ReadAllText("persons.json");
            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(personsJson)!;

            foreach (Person person in persons)
            {
                modelBuilder.Entity<Person>().HasData(person);
            }
            //    modelBuilder.Entity<Country>().HasData(new Country()
            //    {
            //        CountryId = Guid.NewGuid(),
            //        CountryName = "Brazil"
            //    });
            //}
        }
    }
}
