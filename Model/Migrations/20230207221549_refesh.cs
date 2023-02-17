using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class refesh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Invoice_InvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails");

            migrationBuilder.RenameTable(
                name: "InvoiceDetails",
                newName: "InvoiceDetail");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetail",
                newName: "IX_InvoiceDetail_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDetail",
                table: "InvoiceDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDetail",
                table: "InvoiceDetail");

            migrationBuilder.RenameTable(
                name: "InvoiceDetail",
                newName: "InvoiceDetails");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Invoice_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
