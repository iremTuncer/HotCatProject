using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedMenu_Orders_OrderId",
                table: "SelectedMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedMenu",
                table: "SelectedMenu");

            migrationBuilder.RenameTable(
                name: "SelectedMenu",
                newName: "SelectedMenus");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedMenu_OrderId",
                table: "SelectedMenus",
                newName: "IX_SelectedMenus_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedMenus",
                table: "SelectedMenus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedMenus_Orders_OrderId",
                table: "SelectedMenus",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedMenus_Orders_OrderId",
                table: "SelectedMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedMenus",
                table: "SelectedMenus");

            migrationBuilder.RenameTable(
                name: "SelectedMenus",
                newName: "SelectedMenu");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedMenus_OrderId",
                table: "SelectedMenu",
                newName: "IX_SelectedMenu_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedMenu",
                table: "SelectedMenu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedMenu_Orders_OrderId",
                table: "SelectedMenu",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
