using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMBD.Types.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transcript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterType = table.Column<int>(type: "int", nullable: false),
                    PreSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreFacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreDepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectCredit = table.Column<int>(type: "int", nullable: false),
                    SubjectAkts = table.Column<int>(type: "int", nullable: false),
                    ExemptSubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExemptSubjectCredit = table.Column<int>(type: "int", nullable: false),
                    ExemptSubjectAkts = table.Column<int>(type: "int", nullable: false),
                    ExemptSubjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "DepartmentName", "FormId", "MailAddress", "Name", "PhoneNumber", "PreDepartmentName", "PreFacultyName", "PreSchoolName", "RegisterType", "StudentId", "StudentNo", "Surname", "TcNo", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 5, 10, 19, 11, 13, 62, DateTimeKind.Local).AddTicks(6234), "2362", "Muhendislik ve mimarlik", 0, "w31312", "Galip", "1234567890", "1234567890", "1234567890", "1234567890", 0, "1234567890", "1234567890", "Abay", "2637239385", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
