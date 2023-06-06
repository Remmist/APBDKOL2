using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBDKOL2.Migrations
{
    /// <inheritdoc />
    public partial class DbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Make_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Specialization_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationPlate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProductionYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Make_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Car_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Car_Make",
                        column: x => x.Make_Id,
                        principalTable: "Make",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Specialization_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Mechanic_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Mechanic_Specialization",
                        column: x => x.Specialization_Id,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MechanicCar",
                columns: table => new
                {
                    Mechanic_Id = table.Column<int>(type: "int", nullable: false),
                    Car_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MechanicCar_pk", x => new { x.Mechanic_Id, x.Car_Id });
                    table.ForeignKey(
                        name: "MechanicCar_Car",
                        column: x => x.Car_Id,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MechanicCar_Mechanic",
                        column: x => x.Mechanic_Id,
                        principalTable: "Mechanic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_Make_Id",
                table: "Car",
                column: "Make_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanic_Specialization_Id",
                table: "Mechanic",
                column: "Specialization_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicCar_Car_Id",
                table: "MechanicCar",
                column: "Car_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicCar");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Mechanic");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropTable(
                name: "Specialization");
        }
    }
}
