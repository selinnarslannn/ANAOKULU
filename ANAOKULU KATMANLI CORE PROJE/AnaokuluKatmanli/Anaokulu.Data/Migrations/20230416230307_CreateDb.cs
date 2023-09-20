using Microsoft.EntityFrameworkCore.Migrations;

namespace Anaokulu.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    EtkinlikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtkinlikAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YasGrubu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.EtkinlikID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciNo);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenAdi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OgretmenSoyadi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Brans = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenID);
                });

            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenID = table.Column<int>(type: "int", nullable: false),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YasGrubu = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.DersID);
                    table.ForeignKey(
                        name: "FK_Dersler_Ogretmenler_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmenler",
                        principalColumn: "OgretmenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenID = table.Column<int>(type: "int", nullable: false),
                    OgrenciAdsoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.OgrenciID);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Ogretmenler_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmenler",
                        principalColumn: "OgretmenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_OgretmenID",
                table: "Dersler",
                column: "OgretmenID");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_OgretmenID",
                table: "Ogrenciler",
                column: "OgretmenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Ogretmenler");
        }
    }
}
