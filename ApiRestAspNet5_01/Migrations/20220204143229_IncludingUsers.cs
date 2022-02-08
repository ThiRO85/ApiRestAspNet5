using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestAspNet5_01.Migrations
{
    public partial class IncludingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(name: "User Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(name: "Full Name", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefresehToken = table.Column<string>(name: "Refreseh Token", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(name: "Refresh Token Expiry Time", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
