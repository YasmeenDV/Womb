using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WOMB_Final.Data.Migrations
{
    public partial class userView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationFee = table.Column<double>(type: "float", nullable: false),
                    HPCSAnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserViewModel");
        }
    }
}
