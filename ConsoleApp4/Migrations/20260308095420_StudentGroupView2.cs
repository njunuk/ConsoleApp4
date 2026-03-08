using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp4.Migrations
{
    /// <inheritdoc />
    public partial class StudentGroupView2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW vw_StudentsGroups AS
                SELECT S.[FirstName] + ' ' + S.[LastName] AS StudentName,
                        G.[Name] AS GroupName
                FROM Students S
                JOIN Groups G ON S.GroupId = G.Id;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vw_StudentsGroups;");
        }
    }
}
