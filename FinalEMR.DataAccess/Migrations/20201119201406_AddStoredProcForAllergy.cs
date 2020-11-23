using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalEMR.DataAccess.Migrations
{
    public partial class AddStoredProcForAllergy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetAllergies 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.Allergies 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetAllergy
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.Allergies  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateAllergy
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.Allergies
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteAllergy
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.Allergies
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateAllergy
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.Allergies(Name)
                                    VALUES (@Name)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetAllergies");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetAllergy");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateAllergy");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteAllergy");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateAllergy");
        }
    }
}
