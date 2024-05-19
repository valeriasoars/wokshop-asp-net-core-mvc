using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMvc.Migrations
{
    /// <inheritdoc />
    public partial class DepartamentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salesRecords_Seller_SellerId",
                table: "salesRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_salesRecords",
                table: "salesRecords");

            migrationBuilder.RenameTable(
                name: "salesRecords",
                newName: "SalesRecord");

            migrationBuilder.RenameIndex(
                name: "IX_salesRecords_SellerId",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord");

            migrationBuilder.RenameTable(
                name: "SalesRecord",
                newName: "salesRecords");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerId",
                table: "salesRecords",
                newName: "IX_salesRecords_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salesRecords",
                table: "salesRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_salesRecords_Seller_SellerId",
                table: "salesRecords",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
