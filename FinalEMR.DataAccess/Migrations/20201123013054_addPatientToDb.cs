using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalEMR.DataAccess.Migrations
{
    public partial class addPatientToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    SocialSecurity = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    AllergyId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AllergyId",
                table: "Patients",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PrescriptionId",
                table: "Patients",
                column: "PrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
