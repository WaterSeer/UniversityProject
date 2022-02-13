using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityProject.Infrastucture.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COURSES",
                columns: table => new
                {
                    COURSE_ID = table.Column<long>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSES", x => x.COURSE_ID);
                });

            migrationBuilder.CreateTable(
                name: "GROUPS",
                columns: table => new
                {
                    GROUP_ID = table.Column<long>(type: "int", nullable: false),
                    COURSE_ID = table.Column<long>(type: "int", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUPS", x => x.GROUP_ID);
                    table.ForeignKey(
                        name: "FK_GROUPS_COURSES_COURSE_ID",
                        column: x => x.COURSE_ID,
                        principalTable: "COURSES",
                        principalColumn: "COURSE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENTS",
                columns: table => new
                {
                    STUDENT_ID = table.Column<long>(type: "int", nullable: false),
                    GROUP_ID = table.Column<long>(type: "int", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTS", x => x.STUDENT_ID);
                    table.ForeignKey(
                        name: "FK_STUDENTS_GROUPS_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "GROUPS",
                        principalColumn: "GROUP_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GROUPS_COURSE_ID",
                table: "GROUPS",
                column: "COURSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENTS_GROUP_ID",
                table: "STUDENTS",
                column: "GROUP_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STUDENTS");

            migrationBuilder.DropTable(
                name: "GROUPS");

            migrationBuilder.DropTable(
                name: "COURSES");
        }
    }
}
