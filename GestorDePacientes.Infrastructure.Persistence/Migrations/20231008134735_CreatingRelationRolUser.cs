using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDePacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatingRelationRolUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRol",
                table: "User",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Rol_IdRol",
                table: "User",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Rol_IdRol",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdRol",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "User");
        }
    }
}
