using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddDonhangSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoas");

            migrationBuilder.DropTable(
                name: "Loaihhs");

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Madh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ngaydh = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Ngaygiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tinhtrangdh = table.Column<int>(type: "int", nullable: false),
                    Nguoimua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sodienthoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Madh);
                });

            migrationBuilder.CreateTable(
                name: "Loaihh",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaihh", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    Mahh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tenhh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dongia = table.Column<double>(type: "float", nullable: false),
                    Giamgia = table.Column<byte>(type: "tinyint", nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.Mahh);
                    table.ForeignKey(
                        name: "FK_HangHoa_Loaihh_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loaihh",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    Mahh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Madh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<double>(type: "float", nullable: false),
                    Giamgia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => new { x.Madh, x.Mahh });
                    table.ForeignKey(
                        name: "FK_Chitietdh_Donhang",
                        column: x => x.Madh,
                        principalTable: "DonHang",
                        principalColumn: "Madh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietdh_Hanghoa",
                        column: x => x.Mahh,
                        principalTable: "HangHoa",
                        principalColumn: "Mahh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_Mahh",
                table: "ChiTietDonHang",
                column: "Mahh");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "Loaihh");

            migrationBuilder.CreateTable(
                name: "Loaihhs",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaihhs", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    Mahh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: true),
                    Dongia = table.Column<double>(type: "float", nullable: false),
                    Giamgia = table.Column<byte>(type: "tinyint", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenhh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.Mahh);
                    table.ForeignKey(
                        name: "FK_HangHoas_Loaihhs_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loaihhs",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoas",
                column: "MaLoai");
        }
    }
}
