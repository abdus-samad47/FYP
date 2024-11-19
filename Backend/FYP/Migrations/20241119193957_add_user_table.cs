using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYP.Migrations
{
    public partial class add_user_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    User_Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UserSalt = table.Column<string>(name: "User.Salt", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UserRole = table.Column<string>(name: "User.Role", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    User_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    User_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User_DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserNIC = table.Column<string>(name: "User.NIC", type: "nvarchar(13)", maxLength: 13, nullable: false),
                    User_PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    User_Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    User_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "Offline")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Email",
                table: "Users",
                column: "User_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_name",
                table: "Users",
                column: "User_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_PhoneNumber",
                table: "Users",
                column: "User_PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_User.NIC",
                table: "Users",
                column: "User.NIC",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
