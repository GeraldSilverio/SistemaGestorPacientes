using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDePacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatingRelationMedicalAppoinmentPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "MedicalAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_IdPatient",
                table: "MedicalAppointment",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointment_Patient_IdPatient",
                table: "MedicalAppointment",
                column: "IdPatient",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointment_Patient_IdPatient",
                table: "MedicalAppointment");

            migrationBuilder.DropIndex(
                name: "IX_MedicalAppointment_IdPatient",
                table: "MedicalAppointment");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "MedicalAppointment");
        }
    }
}
