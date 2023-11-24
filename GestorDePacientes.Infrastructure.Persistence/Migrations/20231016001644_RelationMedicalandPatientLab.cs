using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDePacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelationMedicalandPatientLab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMedicalAppoinment",
                table: "PatientLabTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientLabTests_IdMedicalAppoinment",
                table: "PatientLabTests",
                column: "IdMedicalAppoinment");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLabTests_MedicalAppointment_IdMedicalAppoinment",
                table: "PatientLabTests",
                column: "IdMedicalAppoinment",
                principalTable: "MedicalAppointment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLabTests_MedicalAppointment_IdMedicalAppoinment",
                table: "PatientLabTests");

            migrationBuilder.DropIndex(
                name: "IX_PatientLabTests_IdMedicalAppoinment",
                table: "PatientLabTests");

            migrationBuilder.DropColumn(
                name: "IdMedicalAppoinment",
                table: "PatientLabTests");
        }
    }
}
