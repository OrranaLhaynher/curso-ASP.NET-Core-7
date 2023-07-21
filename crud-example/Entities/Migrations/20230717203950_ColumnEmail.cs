using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("012107df-862f-4f16-ba94-e5c16886f005"),
                column: "PersonEmail",
                value: "hmosco8@tripod.com");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("28d11936-9466-4a4b-b9c5-2f0a8e0cbde9"),
                column: "PersonEmail",
                value: "mconachya@va.gov");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("29339209-63f5-492f-8459-754943c74abf"),
                column: "PersonEmail",
                value: "mjarrell6@wisc.edu");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("2a6d3738-9def-43ac-9279-0310edc7ceca"),
                column: "PersonEmail",
                value: "mlingfoot5@netvibes.com");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("89e5f445-d89f-4e12-94e0-5ad5b235d704"),
                column: "PersonEmail",
                value: "ttregona4@stumbleupon.com");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("a3b9833b-8a4d-43e9-8690-61e08df81a9a"),
                column: "PersonEmail",
                value: "vklussb@nationalgeographic.com");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("ac660a73-b0b7-4340-abc1-a914257a6189"),
                column: "PersonEmail",
                value: "pretchford7@virginia.edu");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("c03bbe45-9aeb-4d24-99e0-4743016ffce9"),
                column: "PersonEmail",
                value: "mwebsdale0@people.com.cn");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("c3abddbd-cf50-41d2-b6c4-cc7d5a750928"),
                column: "PersonEmail",
                value: "ushears1@globo.com");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("c6d50a47-f7e6-4482-8be0-4ddfc057fa6e"),
                column: "PersonEmail",
                value: "fbowsher2@howstuffworks.com");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("cb035f22-e7cf-4907-bd07-91cfee5240f3"),
                column: "PersonEmail",
                value: "lwoodwing9@wix.com");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("d15c6d9f-70b4-48c5-afd3-e71261f1a9be"),
                column: "PersonEmail",
                value: "asarvar3@dropbox.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("012107df-862f-4f16-ba94-e5c16886f005"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("28d11936-9466-4a4b-b9c5-2f0a8e0cbde9"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("29339209-63f5-492f-8459-754943c74abf"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("2a6d3738-9def-43ac-9279-0310edc7ceca"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("89e5f445-d89f-4e12-94e0-5ad5b235d704"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("a3b9833b-8a4d-43e9-8690-61e08df81a9a"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("ac660a73-b0b7-4340-abc1-a914257a6189"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("c03bbe45-9aeb-4d24-99e0-4743016ffce9"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("c3abddbd-cf50-41d2-b6c4-cc7d5a750928"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("c6d50a47-f7e6-4482-8be0-4ddfc057fa6e"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("cb035f22-e7cf-4907-bd07-91cfee5240f3"),
                column: "PersonEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: new Guid("d15c6d9f-70b4-48c5-afd3-e71261f1a9be"),
                column: "PersonEmail",
                value: null);
        }
    }
}
