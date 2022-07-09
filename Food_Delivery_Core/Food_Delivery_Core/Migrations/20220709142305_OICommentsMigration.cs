using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery_Core.Migrations
{
    public partial class OICommentsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_OrdererId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "DishComment",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_OrdererId",
                table: "Orders",
                column: "OrdererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_OrdererId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DishComment",
                table: "OrderItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_OrdererId",
                table: "Orders",
                column: "OrdererId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
