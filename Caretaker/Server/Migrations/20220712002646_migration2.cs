using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caretaker.Server.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingCategoryType",
                table: "BillingCategories");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PostedBy",
                table: "NoticeBoards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "NoticeBoards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BillingCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeID",
                table: "BillingCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingCategories_TransactionTypeID",
                table: "BillingCategories",
                column: "TransactionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingCategories_TransactionType_TransactionTypeID",
                table: "BillingCategories",
                column: "TransactionTypeID",
                principalTable: "TransactionType",
                principalColumn: "TransactionTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingCategories_TransactionType_TransactionTypeID",
                table: "BillingCategories");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_BillingCategories_TransactionTypeID",
                table: "BillingCategories");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "NoticeBoards");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "NoticeBoards");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BillingCategories");

            migrationBuilder.DropColumn(
                name: "TransactionTypeID",
                table: "BillingCategories");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCategoryType",
                table: "BillingCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
