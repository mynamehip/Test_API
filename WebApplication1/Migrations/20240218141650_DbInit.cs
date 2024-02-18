using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    Mahh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tenhh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dongia = table.Column<double>(type: "float", nullable: false),
                    Giamgia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.Mahh);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoas");
        }
    }
}
