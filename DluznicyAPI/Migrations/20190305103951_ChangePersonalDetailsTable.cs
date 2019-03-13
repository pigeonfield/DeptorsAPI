using Microsoft.EntityFrameworkCore.Migrations;

namespace DluznicyAPI.Migrations
{
    public partial class ChangePersonalDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Persons_PersonId",
                table: "PersonalDetails");

            migrationBuilder.RenameColumn(
                name: "Secrets",
                table: "PersonalDetails",
                newName: "DarkSecrets");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailsId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Persons_PersonId",
                table: "PersonalDetails",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Persons_PersonId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "PersonalDetailsId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "DarkSecrets",
                table: "PersonalDetails",
                newName: "Secrets");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Persons_PersonId",
                table: "PersonalDetails",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
