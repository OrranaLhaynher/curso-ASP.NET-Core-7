using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Entities
{
    public class PersonsDbContext : DbContext //cada um desses DbContext é um banco
    {
        public PersonsDbContext(DbContextOptions options) : base(options) {  }

        public DbSet<Country> Countries { get; set; } //cada um desses é uma tabela
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");

            //Seed to Countries
            string countriesJson = File.ReadAllText("countries.json");
            List<Country> countries = JsonSerializer.Deserialize<List<Country>>(countriesJson);

            foreach (Country country in countries)
                modelBuilder.Entity<Country>().HasData(country);


            //Seed to Persons
            string personsJson = File.ReadAllText("persons.json");
            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(personsJson);

            foreach (Person person in persons)
                modelBuilder.Entity<Person>().HasData(person);

            //    modelBuilder.Entity<Country>().HasData(new Country()
            //    {
            //        CountryId = Guid.NewGuid(),
            //        CountryName = "Brazil"
            //    });
            //}
        }

        public List<Person> sp_GetAllPersons()
        {
            return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]").ToList();
        }

        public int sp_InsertPerson(Person person)
        {
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@PersonId", person.PersonId),
                new SqlParameter("@PersonName", person.PersonName),
                new SqlParameter("@PersonEmail", person.PersonEmail),
                new SqlParameter("@DateOfBirth", person.DateOfBirth),
                new SqlParameter("@Gender", person.Gender),
                new SqlParameter("@CountryId", person.CountryId),
                new SqlParameter("@Address", person.Address),
                new SqlParameter("@ReceiveNewsLetters", person.ReceiveNewsLetters)
            };

            return Database.ExecuteSqlRaw("EXECUTE [dbo].[InsertPerson] @PersonId, @PersonName, @PersonEmail, @DateOfBirth, @Gender, @CountryId, @Address, @ReceiveNewsLetters", param);
        }

        public int sp_UpdatePerson(Person person)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@PersonId", person.PersonId),
                new SqlParameter("@PersonName", person.PersonName),
                new SqlParameter("@PersonEmail", person.PersonEmail),
                new SqlParameter("@DateOfBirth", person.DateOfBirth),
                new SqlParameter("@Gender", person.Gender),
                new SqlParameter("@CountryId", person.CountryId),
                new SqlParameter("@Address", person.Address),
                new SqlParameter("@ReceiveNewsLetters", person.ReceiveNewsLetters)
            };

            return Database.ExecuteSqlRaw("EXECUTE [dbo].[UpdatePerson] @PersonId, @PersonName, @PersonEmail, @DateOfBirth, @Gender, @CountryId, @Address, @ReceiveNewsLetters", param);
        }

        public int sp_DeletePerson(Person person)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@PersonId", person.PersonId)
            };

            return Database.ExecuteSqlRaw("EXECUTE [dbo].[DeletePerson] @PersonId", param);
        }

        //public IQueryable<Person> DbSetName.FromSqlRaw(string sql, params object[] parameters) //for select
        //public int DbContext.Database.ExecuteSqlRaw(string sql, params object[] parameters) //for insert, update and delete
    }
}
