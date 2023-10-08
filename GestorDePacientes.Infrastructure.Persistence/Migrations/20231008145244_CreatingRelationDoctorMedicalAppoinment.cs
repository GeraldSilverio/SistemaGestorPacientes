using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDePacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatingRelationDoctorMedicalAppoinment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "MedicalAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_IdDoctor",
                table: "MedicalAppointment",
                column: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointment_Doctor_IdDoctor",
                table: "MedicalAppointment",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointment_Doctor_IdDoctor",
                table: "MedicalAppointment");

            migrationBuilder.DropIndex(
                name: "IX_MedicalAppointment_IdDoctor",
                table: "MedicalAppointment");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "MedicalAppointment");
        }
    }
}
