using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class Access : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Grant_Access_Tbl_Access_AccessId",
                table: "tbl_Grant_Access");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Grant_Access_Tbl_Users_UserId",
                table: "tbl_Grant_Access");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Grant_Access",
                table: "tbl_Grant_Access");

            migrationBuilder.DeleteData(
                table: "Tbl_Access",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tbl_Access",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tbl_Access",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "tbl_Grant_Access",
                newName: "Tbl_Grant_Access");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Grant_Access_UserId",
                table: "Tbl_Grant_Access",
                newName: "IX_Tbl_Grant_Access_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Grant_Access_AccessId",
                table: "Tbl_Grant_Access",
                newName: "IX_Tbl_Grant_Access_AccessId");

            migrationBuilder.RenameColumn(
                name: "AccessName",
                table: "Tbl_Access",
                newName: "AccessCode");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccessId",
                table: "Tbl_Grant_Access",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Tbl_Grant_Access",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Tbl_Grant_Access",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Tbl_Access",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tbl_Access",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "ModuleId",
                table: "Tbl_Access",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Grant_Access",
                table: "Tbl_Grant_Access",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tbl_Module",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Module_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Module", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Grant_Access_CompanyId",
                table: "Tbl_Grant_Access",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Access_ModuleId",
                table: "Tbl_Access",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Access_Tbl_Module_ModuleId",
                table: "Tbl_Access",
                column: "ModuleId",
                principalTable: "Tbl_Module",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Access_AccessId",
                table: "Tbl_Grant_Access",
                column: "AccessId",
                principalTable: "Tbl_Access",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Company_CompanyId",
                table: "Tbl_Grant_Access",
                column: "CompanyId",
                principalTable: "Tbl_Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Users_UserId",
                table: "Tbl_Grant_Access",
                column: "UserId",
                principalTable: "Tbl_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Access_Tbl_Module_ModuleId",
                table: "Tbl_Access");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Access_AccessId",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Company_CompanyId",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Users_UserId",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropTable(
                name: "Tbl_Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Grant_Access",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Grant_Access_CompanyId",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Access_ModuleId",
                table: "Tbl_Access");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tbl_Access");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Tbl_Access");

            migrationBuilder.RenameTable(
                name: "Tbl_Grant_Access",
                newName: "tbl_Grant_Access");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Grant_Access_UserId",
                table: "tbl_Grant_Access",
                newName: "IX_tbl_Grant_Access_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Grant_Access_AccessId",
                table: "tbl_Grant_Access",
                newName: "IX_tbl_Grant_Access_AccessId");

            migrationBuilder.RenameColumn(
                name: "AccessCode",
                table: "Tbl_Access",
                newName: "AccessName");

            migrationBuilder.AlterColumn<int>(
                name: "AccessId",
                table: "tbl_Grant_Access",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "tbl_Grant_Access",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tbl_Access",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Grant_Access",
                table: "tbl_Grant_Access",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Tbl_Access",
                columns: new[] { "Id", "AccessName" },
                values: new object[,]
                {
                    { 1, "View Module 1" },
                    { 2, "Add Module 1" },
                    { 3, "Edit Module 1" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Grant_Access_Tbl_Access_AccessId",
                table: "tbl_Grant_Access",
                column: "AccessId",
                principalTable: "Tbl_Access",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Grant_Access_Tbl_Users_UserId",
                table: "tbl_Grant_Access",
                column: "UserId",
                principalTable: "Tbl_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
