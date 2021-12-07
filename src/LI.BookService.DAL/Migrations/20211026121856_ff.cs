using Microsoft.EntityFrameworkCore.Migrations;

namespace LI.BookService.DAL.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeLists_OfferLists_OfferListId",
                table: "ExchangeLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeLists_WishLists_WishListId",
                table: "ExchangeLists");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeLists_OfferListId",
                table: "ExchangeLists");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeLists_WishListId",
                table: "ExchangeLists");

            migrationBuilder.DropColumn(
                name: "OfferListId",
                table: "ExchangeLists");

            migrationBuilder.DropColumn(
                name: "WishListId",
                table: "ExchangeLists");

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "UserLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[] { 1, "Новый" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[] { 2, "В работе" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[] { 3, "Закрыто" });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_OfferList1Id",
                table: "ExchangeLists",
                column: "OfferList1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_OfferList2Id",
                table: "ExchangeLists",
                column: "OfferList2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_WishList1Id",
                table: "ExchangeLists",
                column: "WishList1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_WishList2Id",
                table: "ExchangeLists",
                column: "WishList2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeLists_OfferLists_OfferList1Id",
                table: "ExchangeLists",
                column: "OfferList1Id",
                principalTable: "OfferLists",
                principalColumn: "OfferListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeLists_OfferLists_OfferList2Id",
                table: "ExchangeLists",
                column: "OfferList2Id",
                principalTable: "OfferLists",
                principalColumn: "OfferListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeLists_WishLists_WishList1Id",
                table: "ExchangeLists",
                column: "WishList1Id",
                principalTable: "WishLists",
                principalColumn: "WishListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeLists_WishLists_WishList2Id",
                table: "ExchangeLists",
                column: "WishList2Id",
                principalTable: "WishLists",
                principalColumn: "WishListId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeLists_OfferLists_OfferList1Id",
                table: "ExchangeLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeLists_OfferLists_OfferList2Id",
                table: "ExchangeLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeLists_WishLists_WishList1Id",
                table: "ExchangeLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeLists_WishLists_WishList2Id",
                table: "ExchangeLists");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeLists_OfferList1Id",
                table: "ExchangeLists");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeLists_OfferList2Id",
                table: "ExchangeLists");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeLists_WishList1Id",
                table: "ExchangeLists");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeLists_WishList2Id",
                table: "ExchangeLists");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "UserLists");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "OfferListId",
                table: "ExchangeLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WishListId",
                table: "ExchangeLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_OfferListId",
                table: "ExchangeLists",
                column: "OfferListId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_WishListId",
                table: "ExchangeLists",
                column: "WishListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeLists_OfferLists_OfferListId",
                table: "ExchangeLists",
                column: "OfferListId",
                principalTable: "OfferLists",
                principalColumn: "OfferListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeLists_WishLists_WishListId",
                table: "ExchangeLists",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "WishListId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
