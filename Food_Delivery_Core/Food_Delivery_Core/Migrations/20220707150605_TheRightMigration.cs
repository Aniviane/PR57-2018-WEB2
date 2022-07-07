using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery_Core.Migrations
{
    public partial class TheRightMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Restoraunts_RestorauntId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Restoraunts_TakenOrder_RestorauntId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_DelivererId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_OrdererId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_TakenOrder_OrdererId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Order_OrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_TakenOrder_OrdererId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_TakenOrder_RestorauntId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TakenOrder_Comment",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TakenOrder_OrdererId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TakenOrder_RestorauntId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TakenOrder_RestourantId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TakenOrder_TimeOfOrder",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_RestorauntId",
                table: "Orders",
                newName: "IX_Orders_RestorauntId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrdererId",
                table: "Orders",
                newName: "IX_Orders_OrdererId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DelivererId",
                table: "Orders",
                newName: "IX_Orders_DelivererId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfOrder",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RestourantId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RestorauntId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OrdererId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeliveryId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DelivererId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restoraunts_RestorauntId",
                table: "Orders",
                column: "RestorauntId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_DelivererId",
                table: "Orders",
                column: "DelivererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_OrdererId",
                table: "Orders",
                column: "OrdererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restoraunts_RestorauntId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_DelivererId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_OrdererId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestorauntId",
                table: "Order",
                newName: "IX_Order_RestorauntId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrdererId",
                table: "Order",
                newName: "IX_Order_OrdererId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DelivererId",
                table: "Order",
                newName: "IX_Order_DelivererId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfOrder",
                table: "Order",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "RestourantId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RestorauntId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OrdererId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DeliveryId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DelivererId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TakenOrder_Comment",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TakenOrder_OrdererId",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TakenOrder_RestorauntId",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TakenOrder_RestourantId",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TakenOrder_TimeOfOrder",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TakenOrder_OrdererId",
                table: "Order",
                column: "TakenOrder_OrdererId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TakenOrder_RestorauntId",
                table: "Order",
                column: "TakenOrder_RestorauntId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Restoraunts_RestorauntId",
                table: "Order",
                column: "RestorauntId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Restoraunts_TakenOrder_RestorauntId",
                table: "Order",
                column: "TakenOrder_RestorauntId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_DelivererId",
                table: "Order",
                column: "DelivererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_OrdererId",
                table: "Order",
                column: "OrdererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_TakenOrder_OrdererId",
                table: "Order",
                column: "TakenOrder_OrdererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Order_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
