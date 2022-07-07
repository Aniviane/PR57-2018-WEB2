using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery_Core.Migrations
{
    public partial class AnotherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_AvailableOrders_AvailableOrderId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_TakenOrders_TakenOrderId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TakenOrders_Restoraunts_RestorauntId",
                table: "TakenOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TakenOrders_Users_DelivererId",
                table: "TakenOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TakenOrders_Users_OrdererId",
                table: "TakenOrders");

            migrationBuilder.DropTable(
                name: "AvailableOrders");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_AvailableOrderId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_TakenOrderId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TakenOrders",
                table: "TakenOrders");

            migrationBuilder.DropColumn(
                name: "AvailableOrderId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "TakenOrderId",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "TakenOrders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_TakenOrders_RestorauntId",
                table: "Order",
                newName: "IX_Order_RestorauntId");

            migrationBuilder.RenameIndex(
                name: "IX_TakenOrders_OrdererId",
                table: "Order",
                newName: "IX_Order_OrdererId");

            migrationBuilder.RenameIndex(
                name: "IX_TakenOrders_DelivererId",
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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_TakenOrder_OrdererId",
                table: "Order",
                column: "TakenOrder_OrdererId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TakenOrder_RestorauntId",
                table: "Order",
                column: "TakenOrder_RestorauntId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DishId",
                table: "OrderItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Restoraunts_RestorauntId",
                table: "Order",
                column: "RestorauntId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Restoraunts_TakenOrder_RestorauntId",
                table: "Order",
                column: "TakenOrder_RestorauntId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_TakenOrder_OrdererId",
                table: "Order",
                column: "TakenOrder_OrdererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "OrderItems");

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
                newName: "TakenOrders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_RestorauntId",
                table: "TakenOrders",
                newName: "IX_TakenOrders_RestorauntId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrdererId",
                table: "TakenOrders",
                newName: "IX_TakenOrders_OrdererId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DelivererId",
                table: "TakenOrders",
                newName: "IX_TakenOrders_DelivererId");

            migrationBuilder.AddColumn<long>(
                name: "AvailableOrderId",
                table: "Dishes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TakenOrderId",
                table: "Dishes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfOrder",
                table: "TakenOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TakenOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RestourantId",
                table: "TakenOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RestorauntId",
                table: "TakenOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OrdererId",
                table: "TakenOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeliveryId",
                table: "TakenOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DelivererId",
                table: "TakenOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "TakenOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TakenOrders",
                table: "TakenOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AvailableOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdererId = table.Column<long>(type: "bigint", nullable: false),
                    RestorauntId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestourantId = table.Column<long>(type: "bigint", nullable: false),
                    TimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableOrders_Restoraunts_RestorauntId",
                        column: x => x.RestorauntId,
                        principalTable: "Restoraunts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableOrders_Users_OrdererId",
                        column: x => x.OrdererId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_AvailableOrderId",
                table: "Dishes",
                column: "AvailableOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_TakenOrderId",
                table: "Dishes",
                column: "TakenOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableOrders_OrdererId",
                table: "AvailableOrders",
                column: "OrdererId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableOrders_RestorauntId",
                table: "AvailableOrders",
                column: "RestorauntId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_AvailableOrders_AvailableOrderId",
                table: "Dishes",
                column: "AvailableOrderId",
                principalTable: "AvailableOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_TakenOrders_TakenOrderId",
                table: "Dishes",
                column: "TakenOrderId",
                principalTable: "TakenOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TakenOrders_Restoraunts_RestorauntId",
                table: "TakenOrders",
                column: "RestorauntId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TakenOrders_Users_DelivererId",
                table: "TakenOrders",
                column: "DelivererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TakenOrders_Users_OrdererId",
                table: "TakenOrders",
                column: "OrdererId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
