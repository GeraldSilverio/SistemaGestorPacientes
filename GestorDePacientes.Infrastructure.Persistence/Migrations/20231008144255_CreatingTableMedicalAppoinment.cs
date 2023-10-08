using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDePacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTableMedicalAppoinment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfAppoinment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HourOfAppoinment = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReasonOfAppoinment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creaty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAppointment", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalAppointment");
        }
    }
}
