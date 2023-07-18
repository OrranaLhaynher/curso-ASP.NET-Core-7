using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePerson_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_UpdatePerson = @"
                CREATE PROCEDURE [dbo].[UpdatePerson](@PersonId uniqueidentifier, @PersonName nvarchar(40), @PersonEmail nvarchar(40), @DateOfBirth datetime2(7), @Gender nvarchar(10), @CountryId uniqueidentifier, @Address nvarchar(200), @ReceiveNewsLetters bit)
                AS BEGIN
                    UPDATE [dbo].[Persons]
                    SET PersonName = @PersonName, 
                        PersonEmail = @PersonEmail, 
                        DateOfBirth = @DateOfBirth, 
                        Gender = @Gender, 
                        CountryId = @CountryId, 
                        Address = @Address, 
                        ReceiveNewsLetters = @ReceiveNewsLetters
                    WHERE PersonId = @PersonId
                END
            ";
            migrationBuilder.Sql(sp_UpdatePerson);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_UpdatePerson = @"
                DROP PROCEDURE [dbo].[UpdatePerson]
            ";
            migrationBuilder.Sql(sp_UpdatePerson);
        }

        //UPDATE Customers
        //SET ContactName = 'Alfred Schmidt', City = 'Frankfurt'
        //WHERE CustomerID = 1;
        //UPDATE employee
        //SET first_name = @first_name,
        //       last_name = @last_name,
        //       salary = @salary,
        //       city = @city
        //WHERE id = @id
    }
}
