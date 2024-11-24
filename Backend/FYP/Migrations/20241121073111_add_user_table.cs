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
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    user_salt = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    user_role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    user_created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    user_updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_nic = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    user_phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    user_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "Offline")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_email",
                table: "Users",
                column: "user_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_name",
                table: "Users",
                column: "user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_nic",
                table: "Users",
                column: "user_nic",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_phone_number",
                table: "Users",
                column: "user_phone_number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
