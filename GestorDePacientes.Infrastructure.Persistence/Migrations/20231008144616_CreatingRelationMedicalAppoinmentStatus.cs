using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDePacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatingRelationMedicalAppoinmentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAppoinmentStatus",
                table: "MedicalAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_IdAppoinmentStatus",
                table: "MedicalAppointment",
                column: "IdAppoinmentStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointment_AppoinmentStatus_IdAppoinmentStatus",
                table: "MedicalAppointment",
                column: "IdAppoinmentStatus",
                principalTable: "AppoinmentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointment_AppoinmentStatus_IdAppoinmentStatus",
                table: "MedicalAppointment");

            migrationBuilder.DropIndex(
                name: "IX_MedicalAppointment_IdAppoinmentStatus",
                table: "MedicalAppointment");

            migrationBuilder.DropColumn(
                name: "IdAppoinmentStatus",
                table: "MedicalAppointment");
        }
    }
}
