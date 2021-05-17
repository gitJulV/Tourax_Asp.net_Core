using Microsoft.EntityFrameworkCore.Migrations;

namespace Tourax.Data.Migrations
{
    public partial class MoreEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    IdMatiere = table.Column<int>(nullable: false),
                    LibelleMatiere = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.IdMatiere);
                });

            migrationBuilder.CreateTable(
                name: "Bobine",
                columns: table => new
                {
                    IdBobine = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(maxLength: 50, nullable: true),
                    Nom = table.Column<string>(maxLength: 50, nullable: true),
                    Trancanage = table.Column<bool>(nullable: false),
                    Enroulement = table.Column<bool>(nullable: false),
                    Consigne = table.Column<bool>(nullable: false),
                    LargeurExt = table.Column<double>(nullable: false),
                    LargeurInt = table.Column<double>(nullable: false),
                    DiametreExt = table.Column<double>(nullable: false),
                    DiametreInt = table.Column<double>(nullable: false),
                    Moyeu = table.Column<double>(nullable: false),
                    PoidsAVide = table.Column<double>(nullable: false),
                    PoidsMaxAutorise = table.Column<double>(nullable: false),
                    ImageName = table.Column<string>(maxLength: 150, nullable: true),
                    IdMatiere = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bobine", x => x.IdBobine);
                    table.ForeignKey(
                        name: "FK_Bobine_Matiere_IdMatiere",
                        column: x => x.IdMatiere,
                        principalTable: "Matiere",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bobine_IdMatiere",
                table: "Bobine",
                column: "IdMatiere");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bobine");

            migrationBuilder.DropTable(
                name: "Matiere");
        }
    }
}
