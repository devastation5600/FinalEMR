using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalEMR.DataAccess.Migrations
{
    public partial class ChangesNurseToPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_NurseId",
                table: "Patients",
                column: "NurseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Nurse_NurseId",
                table: "Patients",
                column: "NurseId",
                principalTable: "Nurse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Nurse_NurseId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_NurseId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "Patients");
        }
    }
}
