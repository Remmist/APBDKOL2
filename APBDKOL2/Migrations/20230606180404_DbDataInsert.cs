using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBDKOL2.Migrations
{
    /// <inheritdoc />
    public partial class DbDataInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Make",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ford" },
                    { 2, "Audi" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "EngineMaster" },
                    { 2, "Engi" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Make_Id", "ProductionYear", "RegistrationPlate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), "A777AA77" },
                    { 2, 2, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), "O777OO77" }
                });

            migrationBuilder.InsertData(
                table: "Mechanic",
                columns: new[] { "Id", "FirstName", "LastName", "Nickname", "Specialization_Id" },
                values: new object[,]
                {
                    { 1, "Ivan", "Illarionov", "Remmy", 1 },
                    { 2, "Joe", "Barbaro", "Black hand", 2 }
                });

            migrationBuilder.InsertData(
                table: "MechanicCar",
                columns: new[] { "Car_Id", "Mechanic_Id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MechanicCar",
                keyColumns: new[] { "Car_Id", "Mechanic_Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MechanicCar",
                keyColumns: new[] { "Car_Id", "Mechanic_Id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mechanic",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mechanic",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Make",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
