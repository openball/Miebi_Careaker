using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caretaker.Server.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingCategories_TransactionType_TransactionTypeID",
                table: "BillingCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType");

            migrationBuilder.RenameTable(
                name: "TransactionType",
                newName: "TransactionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "TransactionTypeID");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    BillingCategoryId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Expired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_BillingCategories_BillingCategoryId",
                        column: x => x.BillingCategoryId,
                        principalTable: "BillingCategories",
                        principalColumn: "BillingCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BillingCategoryId",
                table: "Transactions",
                column: "BillingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingCategories_TransactionTypes_TransactionTypeID",
                table: "BillingCategories",
                column: "TransactionTypeID",
                principalTable: "TransactionTypes",
                principalColumn: "TransactionTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingCategories_TransactionTypes_TransactionTypeID",
                table: "BillingCategories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "TransactionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType",
                column: "TransactionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingCategories_TransactionType_TransactionTypeID",
                table: "BillingCategories",
                column: "TransactionTypeID",
                principalTable: "TransactionType",
                principalColumn: "TransactionTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
