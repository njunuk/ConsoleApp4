using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp4.Migrations
{
    /// <inheritdoc />
    public partial class StudentGroupView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Students",
                newName: "Birthday");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Attendance",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Scholarship",
                table: "Students",
                type: "decimal(6,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.CheckConstraint("CK_Group_Name_NotEmpty", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Kafedras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kafedras", x => x.Id);
                    table.CheckConstraint("CK_Kafedra_Name_NotEmpty", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                    table.CheckConstraint("CK_Passport_Number_9Digits", "LEN([Number]) = 9 AND [Number] NOT LIKE '%[^0-9]%'");
                    table.ForeignKey(
                        name: "FK_Passports_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 25000m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.CheckConstraint("CK_Salary>0", "[Salary] > 0");
                    table.CheckConstraint("CK_Teacher_FirstName_NotEmpty", "[FirstName] <> ''");
                    table.CheckConstraint("CK_Teacher_LastName_NotEmpty", "[LastName] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KafedraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.CheckConstraint("CK_Subject_Name_NotEmpty", "[Name] <> ''");
                    table.ForeignKey(
                        name: "FK_Subject_Kafedras_KafedraId",
                        column: x => x.KafedraId,
                        principalTable: "Kafedras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Student_Email_At",
                table: "Students",
                sql: "[Email] LIKE '%@%'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Student_FirstName_NotEmpty",
                table: "Students",
                sql: "[FirstName] <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Student_LastName_NotEmpty",
                table: "Students",
                sql: "[LastName] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_Number",
                table: "Passports",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passports_StudentId",
                table: "Passports",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_KafedraId",
                table: "Subject",
                column: "KafedraId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Kafedras");

            migrationBuilder.DropIndex(
                name: "IX_Students_Email",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_Email_At",
                table: "Students");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_FirstName_NotEmpty",
                table: "Students");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_LastName_NotEmpty",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Scholarship",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Students",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.Sql("DROP VIEW vw_StudentsGroups;");
        }
    }
}
