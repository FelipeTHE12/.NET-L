using Microsoft.EntityFrameworkCore.Migrations;

namespace cadastro_restfull.Migrations
{
    public partial class InitialBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TB_COURSE",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COURSE", x => x.Code);
                    table.ForeignKey(
                        name: "FK_TB_COURSE_TB_USER_CodeUser",
                        column: x => x.CodeUser,
                        principalTable: "TB_USER",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_COURSE_CodeUser",
                table: "TB_COURSE",
                column: "CodeUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_COURSE");

            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
