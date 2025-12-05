using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyCompanyUserTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Access_AccessId",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Users_UserId",
                table: "Tbl_Grant_Access");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Grant_Access",
                table: "Tbl_Grant_Access");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Grant_Access",
                table: "tbl_Grant_Access",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tbl_Company_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    User_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created_timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Company_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Company_User_Tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Company_User_UserId",
                table: "Tbl_Company_User",
                column: "UserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Grant_Access_Tbl_Access_AccessId",
                table: "tbl_Grant_Access");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Grant_Access_Tbl_Users_UserId",
                table: "tbl_Grant_Access");

            migrationBuilder.DropTable(
                name: "Tbl_Company_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Grant_Access",
                table: "tbl_Grant_Access");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Grant_Access",
                table: "Tbl_Grant_Access",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Grant_Access_Tbl_Access_AccessId",
                table: "Tbl_Grant_Access",
                column: "AccessId",
                principalTable: "Tbl_Access",
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
    }
}
