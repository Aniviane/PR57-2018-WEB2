using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery_Core.Migrations
{
    public partial class CorrectMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restoraunts_restorauntId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_restorauntId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "restorauntId",
                table: "Dishes");

            migrationBuilder.AlterColumn<long>(
                name: "RestaurantId",
                table: "Dishes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateTable(
                name: "AvailableOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdererId = table.Column<long>(type: "bigint", nullable: false),
                    RestourantId = table.Column<long>(type: "bigint", nullable: false),
                    TimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestorauntId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TakenOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdererId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestourantId = table.Column<long>(type: "bigint", nullable: false),
                    TimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelivererId = table.Column<long>(type: "bigint", nullable: false),
                    RestorauntId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakenOrders_Restoraunts_RestorauntId",
                        column: x => x.RestorauntId,
                        principalTable: "Restoraunts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakenOrders_Users_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakenOrders_Users_OrdererId",
                        column: x => x.OrdererId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_AvailableOrderId",
                table: "Dishes",
                column: "AvailableOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                column: "RestaurantId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TakenOrders_DelivererId",
                table: "TakenOrders",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_TakenOrders_OrdererId",
                table: "TakenOrders",
                column: "OrdererId");

            migrationBuilder.CreateIndex(
                name: "IX_TakenOrders_RestorauntId",
                table: "TakenOrders",
                column: "RestorauntId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_AvailableOrders_AvailableOrderId",
                table: "Dishes",
                column: "AvailableOrderId",
                principalTable: "AvailableOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restoraunts_RestaurantId",
                table: "Dishes",
                column: "RestaurantId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_TakenOrders_TakenOrderId",
                table: "Dishes",
                column: "TakenOrderId",
                principalTable: "TakenOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_AvailableOrders_AvailableOrderId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restoraunts_RestaurantId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_TakenOrders_TakenOrderId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "AvailableOrders");

            migrationBuilder.DropTable(
                name: "TakenOrders");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_AvailableOrderId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_TakenOrderId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "AvailableOrderId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "TakenOrderId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "restorauntId",
                table: "Dishes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_restorauntId",
                table: "Dishes",
                column: "restorauntId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restoraunts_restorauntId",
                table: "Dishes",
                column: "restorauntId",
                principalTable: "Restoraunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
