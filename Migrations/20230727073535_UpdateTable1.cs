using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyGhiDanh.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoahoc",
                columns: table => new
                {
                    Idkhoahoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenkhoahoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoahoc", x => x.Idkhoahoc);
                });

            migrationBuilder.CreateTable(
                name: "Lophoc",
                columns: table => new
                {
                    Idlophoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenlop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monhoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Giangvienphutrach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngayhoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Giohoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Batdauketthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hocphi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lophoc", x => x.Idlophoc);
                });

            migrationBuilder.CreateTable(
                name: "Monhoc",
                columns: table => new
                {
                    Idmonhoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenmon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tobomon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Khoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monhoc", x => x.Idmonhoc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khoahoc");

            migrationBuilder.DropTable(
                name: "Lophoc");

            migrationBuilder.DropTable(
                name: "Monhoc");
        }
    }
}
