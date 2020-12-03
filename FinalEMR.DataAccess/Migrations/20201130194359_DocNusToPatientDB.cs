using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalEMR.DataAccess.Migrations
{
    public partial class DocNusToPatientDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_NurseId",
                table: "Patients",
                column: "NurseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_DoctorId",
                table: "Patients",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Patients_Doctors_DoctorId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Nurse_NurseId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_NurseId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "Patients");
        }
    }
}
