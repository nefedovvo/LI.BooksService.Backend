using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LI.BookService.DAL.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLists_Lists_ListId",
                table: "UserLists");

            migrationBuilder.DropIndex(
                name: "IX_UserLists_ListId",
                table: "UserLists");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "UserLists");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "WishLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserAddressId",
                table: "WishLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WishLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "OfferLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExchangeLists",
                columns: table => new
                {
                    ExchangeListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferList1Id = table.Column<int>(type: "int", nullable: false),
                    WishList1Id = table.Column<int>(type: "int", nullable: false),
                    OfferList2Id = table.Column<int>(type: "int", nullable: false),
                    WishList2Id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBoth = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OfferListId = table.Column<int>(type: "int", nullable: true),
                    WishListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeLists", x => x.ExchangeListId);
                    table.ForeignKey(
                        name: "FK_ExchangeLists_OfferLists_OfferListId",
                        column: x => x.OfferListId,
                        principalTable: "OfferLists",
                        principalColumn: "OfferListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeLists_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "WishListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserExchangeLists",
                columns: table => new
                {
                    UserExchangeListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeListId = table.Column<int>(type: "int", nullable: false),
                    OfferListId = table.Column<int>(type: "int", nullable: false),
                    TrackNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Receiving = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExchangeLists", x => x.UserExchangeListId);
                    table.ForeignKey(
                        name: "FK_UserExchangeLists_ExchangeLists_ExchangeListId",
                        column: x => x.ExchangeListId,
                        principalTable: "ExchangeLists",
                        principalColumn: "ExchangeListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExchangeLists_OfferLists_OfferListId",
                        column: x => x.OfferListId,
                        principalTable: "OfferLists",
                        principalColumn: "OfferListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_StatusId",
                table: "WishLists",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserAddressId",
                table: "WishLists",
                column: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferLists_StatusId",
                table: "OfferLists",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_OfferListId",
                table: "ExchangeLists",
                column: "OfferListId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeLists_WishListId",
                table: "ExchangeLists",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExchangeLists_ExchangeListId",
                table: "UserExchangeLists",
                column: "ExchangeListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExchangeLists_OfferListId",
                table: "UserExchangeLists",
                column: "OfferListId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferLists_Statuses_StatusId",
                table: "OfferLists",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Statuses_StatusId",
                table: "WishLists",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_User_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_UserAddresses_UserAddressId",
                table: "WishLists",
                column: "UserAddressId",
                principalTable: "UserAddresses",
                principalColumn: "UserAddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferLists_Statuses_StatusId",
                table: "OfferLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Statuses_StatusId",
                table: "WishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_User_UserId",
                table: "WishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_UserAddresses_UserAddressId",
                table: "WishLists");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "UserExchangeLists");

            migrationBuilder.DropTable(
                name: "ExchangeLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_StatusId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_UserAddressId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_OfferLists_StatusId",
                table: "OfferLists");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "UserAddressId",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "OfferLists");

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "UserLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLists_ListId",
                table: "UserLists",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLists_Lists_ListId",
                table: "UserLists",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "ListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
