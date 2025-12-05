using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "User_id",
                table: "Tbl_Company_User",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Tbl_Company_User",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Company_id",
                table: "Tbl_Company_User",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Company_User_CompanyId",
                table: "Tbl_Company_User",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Company_User_Tbl_Company_CompanyId",
                table: "Tbl_Company_User",
                column: "CompanyId",
                principalTable: "Tbl_Company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Company_User_Tbl_Company_CompanyId",
                table: "Tbl_Company_User");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Company_User_CompanyId",
                table: "Tbl_Company_User");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Tbl_Company_User");

            migrationBuilder.DropColumn(
                name: "Company_id",
                table: "Tbl_Company_User");

            migrationBuilder.AlterColumn<Guid>(
                name: "User_id",
                table: "Tbl_Company_User",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
