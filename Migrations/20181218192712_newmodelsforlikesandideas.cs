using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbeltRetake.Migrations
{
    public partial class newmodelsforlikesandideas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    ideaid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: false),
                    myuseruserid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.ideaid);
                    table.ForeignKey(
                        name: "FK_Ideas_Users_myuseruserid",
                        column: x => x.myuseruserid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    likeid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userid = table.Column<int>(nullable: false),
                    ideaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.likeid);
                    table.ForeignKey(
                        name: "FK_Likes_Ideas_ideaid",
                        column: x => x.ideaid,
                        principalTable: "Ideas",
                        principalColumn: "ideaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_myuseruserid",
                table: "Ideas",
                column: "myuseruserid");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ideaid",
                table: "Likes",
                column: "ideaid");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_userid",
                table: "Likes",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Ideas");
        }
    }
}
