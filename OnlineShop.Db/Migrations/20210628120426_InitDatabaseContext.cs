using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class InitDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompareProduct",
                columns: table => new
                {
                    ComparesId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompareProduct", x => new { x.ComparesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CompareProduct_Compares_ComparesId",
                        column: x => x.ComparesId,
                        principalTable: "Compares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompareProduct_Products_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritesProduct",
                columns: table => new
                {
                    FavoritesId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesProduct", x => new { x.FavoritesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_FavoritesProduct_Favorites_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "Favorites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritesProduct_Products_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoStatus = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContacts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_UserContacts_UserContactId",
                        column: x => x.UserContactId,
                        principalTable: "UserContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), 11426m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Пистолетик" },
                    { new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), 82167m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Ложка" },
                    { new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), 6957m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "Кукла" },
                    { new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), 94741m, "Ex ea commodo consequat.Duis aute irure dolor in r", "Кукла" },
                    { new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), 18346m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "Шапка" },
                    { new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), 54643m, "Minim veniam, quis nostrud exercitation ullamco laboris ", "Конструктор" },
                    { new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), 4225m, "Ex ea commodo consequat.Duis aute i ", "Ложка" },
                    { new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), 12248m, "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in v", "Соска" },
                    { new Guid("615496eb-0537-4657-8237-f033266a3a57"), 76311m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "Пистолетик" },
                    { new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), 51625m, "Velit esse cillum dolore eu fugiat nulla pariatur.E", "Ложка" },
                    { new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), 66068m, "Sed do eiusmod tempor incididunt ut labore et dolore magna ", "Пистолетик" },
                    { new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), 73815m, "Ex ea commodo consequat.Duis aute irure dolor", "Пистолетик" },
                    { new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), 59657m, "Lorem ipsum dolor sit amet, consectetur adipiscing", "Трусы" },
                    { new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), 38020m, "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", "Пирамидка" },
                    { new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), 83000m, "Velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat", "Мишка" },
                    { new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), 94608m, "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate", "Пистолетик" },
                    { new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), 10398m, "Ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ", "Конструктор" },
                    { new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), 11426m, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim", "Шапка" },
                    { new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), 82167m, "Velit esse cillum dolore eu fugiat nulla pariatur", "Чашка" },
                    { new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), 88268m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Ползунки" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("54def983-272a-4338-b402-a1ede218b0ff"), new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), "/img/Products/1.jpg" },
                    { new Guid("b8ef5aae-849c-4adc-ad09-51271c3d95d8"), new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), "/img/Products/4.jpg" },
                    { new Guid("f609703a-7f81-421c-bb43-50cf9134a418"), new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), "/img/Products/6.jpg" },
                    { new Guid("aa223248-3f96-41e2-845c-eb17c7819931"), new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), "/img/Products/5.jpg" },
                    { new Guid("6ab01e98-7448-46ae-a6c4-39962f594e14"), new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), "/img/Products/4.jpg" },
                    { new Guid("68223097-9220-4aa2-b293-810792371772"), new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), "/img/Products/3.jpg" },
                    { new Guid("622e5a61-254f-4104-9b3d-591bb85be465"), new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), "/img/Products/2.jpg" },
                    { new Guid("a821f92b-5cfc-45b9-957f-7529c1a04bdf"), new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), "/img/Products/1.jpg" },
                    { new Guid("6b81ced9-6a52-45d1-b2e7-8baa5ac72923"), new Guid("615496eb-0537-4657-8237-f033266a3a57"), "/img/Products/2.jpg" },
                    { new Guid("1fa03418-c5ef-44bb-902c-c4d545948317"), new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), "/img/Products/3.jpg" },
                    { new Guid("75db362d-10c3-4454-a3d6-44276002fb7b"), new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), "/img/Products/4.jpg" },
                    { new Guid("c779322a-8045-49f6-a079-20fd0e031a02"), new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), "/img/Products/5.jpg" },
                    { new Guid("a5ceb602-f754-4480-935b-9f5da57b0713"), new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), "/img/Products/6.jpg" },
                    { new Guid("e0749463-894e-470a-95f7-6728b874f193"), new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), "/img/Products/6.jpg" },
                    { new Guid("51e329e8-db1e-49a6-948b-b2b11be2d9f9"), new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), "/img/Products/5.jpg" },
                    { new Guid("167826b6-4bef-48ab-81d3-a1b02f865281"), new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), "/img/Products/3.jpg" },
                    { new Guid("25083d34-a27d-4efa-b545-0861006ca727"), new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), "/img/Products/3.jpg" },
                    { new Guid("7deac20e-8a6b-43ee-b7c0-336ef03aeb65"), new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), "/img/Products/2.jpg" },
                    { new Guid("9cd4a49c-734b-4e68-863e-d6f7a0c73894"), new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), "/img/Products/3.jpg" },
                    { new Guid("c3d8044a-85ca-4067-a260-62ff2b256dcf"), new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), "/img/Products/1.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserContactId",
                table: "CartItems",
                column: "UserContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CompareProduct_ItemsId",
                table: "CompareProduct",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesProduct_ItemsId",
                table: "FavoritesProduct",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_OrderId",
                table: "UserContacts",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CompareProduct");

            migrationBuilder.DropTable(
                name: "FavoritesProduct");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "UserContacts");

            migrationBuilder.DropTable(
                name: "Compares");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
