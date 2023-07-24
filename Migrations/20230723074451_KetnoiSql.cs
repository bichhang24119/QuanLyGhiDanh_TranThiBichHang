using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyGhiDanh.Migrations
{
    /// <inheritdoc />
    public partial class KetnoiSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Giangvien",
                columns: table => new
                {
                    Idgiangvien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Masothue = table.Column<double>(type: "float", nullable: false),
                    Hotengiangvien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaysinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sodienthoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mongiangday = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giangvien", x => x.Idgiangvien);
                });

            migrationBuilder.CreateTable(
                name: "Hocvien",
                columns: table => new
                {
                    Idhocvien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotenhocvien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaysinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenphuhuynh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hocvien", x => x.Idhocvien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giangvien");

            migrationBuilder.DropTable(
                name: "Hocvien");
        }
    }
}
