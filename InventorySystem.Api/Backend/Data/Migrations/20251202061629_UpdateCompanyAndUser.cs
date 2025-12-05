using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company_id",
                table: "Tbl_Company_User");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Tbl_Company_User");

            migrationBuilder.RenameColumn(
                name: "Created_timestamp",
                table: "Tbl_Company_User",
                newName: "Created_Timestamp");

            migrationBuilder.RenameColumn(
                name: "Updated_timestamp",
                table: "Tbl_Company",
                newName: "Updated_Timestamp");

            migrationBuilder.RenameColumn(
                name: "Created_timestamp",
                table: "Tbl_Company",
                newName: "Created_Timestamp");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Tbl_Company",
                newName: "Company_Name");

            migrationBuilder.RenameColumn(
                name: "Access",
                table: "Tbl_Access",
                newName: "AccessName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_Timestamp",
                table: "Tbl_Company_User",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated_Timestamp",
                table: "Tbl_Company_User");

            migrationBuilder.RenameColumn(
                name: "Created_Timestamp",
                table: "Tbl_Company_User",
                newName: "Created_timestamp");

            migrationBuilder.RenameColumn(
                name: "Updated_Timestamp",
                table: "Tbl_Company",
                newName: "Updated_timestamp");

            migrationBuilder.RenameColumn(
                name: "Created_Timestamp",
                table: "Tbl_Company",
                newName: "Created_timestamp");

            migrationBuilder.RenameColumn(
                name: "Company_Name",
                table: "Tbl_Company",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "AccessName",
                table: "Tbl_Access",
                newName: "Access");

            migrationBuilder.AddColumn<Guid>(
                name: "Company_id",
                table: "Tbl_Company_User",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "User_id",
                table: "Tbl_Company_User",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }
    }
}
