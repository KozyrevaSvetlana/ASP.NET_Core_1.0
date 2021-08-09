using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class DeleteProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("167826b6-4bef-48ab-81d3-a1b02f865281"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("1fa03418-c5ef-44bb-902c-c4d545948317"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("25083d34-a27d-4efa-b545-0861006ca727"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("51e329e8-db1e-49a6-948b-b2b11be2d9f9"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("54def983-272a-4338-b402-a1ede218b0ff"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("622e5a61-254f-4104-9b3d-591bb85be465"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("68223097-9220-4aa2-b293-810792371772"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("6ab01e98-7448-46ae-a6c4-39962f594e14"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("6b81ced9-6a52-45d1-b2e7-8baa5ac72923"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("75db362d-10c3-4454-a3d6-44276002fb7b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("7deac20e-8a6b-43ee-b7c0-336ef03aeb65"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("9cd4a49c-734b-4e68-863e-d6f7a0c73894"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("a5ceb602-f754-4480-935b-9f5da57b0713"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("a821f92b-5cfc-45b9-957f-7529c1a04bdf"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("aa223248-3f96-41e2-845c-eb17c7819931"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("b8ef5aae-849c-4adc-ad09-51271c3d95d8"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c3d8044a-85ca-4067-a260-62ff2b256dcf"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c779322a-8045-49f6-a079-20fd0e031a02"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("e0749463-894e-470a-95f7-6728b874f193"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f609703a-7f81-421c-bb43-50cf9134a418"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("94071aa3-5452-4feb-8246-9a39bd1566ad"), new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), "/img/Products/1.jpg" },
                    { new Guid("72b4e684-3d77-4044-96fa-83a10568db92"), new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), "/img/Products/4.jpg" },
                    { new Guid("326ea53d-6560-4adf-bfc9-694821670496"), new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), "/img/Products/6.jpg" },
                    { new Guid("79b22ce5-414b-4e82-9409-5ef2adf616f0"), new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), "/img/Products/5.jpg" },
                    { new Guid("68f1abd2-4d42-4664-8f0f-e24b09888535"), new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), "/img/Products/4.jpg" },
                    { new Guid("e04bd3f0-51e9-4436-8b81-330d77469cc6"), new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), "/img/Products/3.jpg" },
                    { new Guid("9541f59c-80c9-4529-8b4b-0ca3b116606d"), new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), "/img/Products/2.jpg" },
                    { new Guid("d8dae5ad-3e8e-416d-95f5-f80a7a80ee07"), new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), "/img/Products/1.jpg" },
                    { new Guid("322f854b-36d5-4239-a271-2e917f6bbbd7"), new Guid("615496eb-0537-4657-8237-f033266a3a57"), "/img/Products/2.jpg" },
                    { new Guid("9d4fdad8-37d3-4b99-8f8a-79b6eda1242a"), new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), "/img/Products/3.jpg" },
                    { new Guid("01f51329-108a-4719-9c5e-2814b03fd851"), new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), "/img/Products/4.jpg" },
                    { new Guid("31349315-168a-4ffe-b700-f3f61307ed34"), new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), "/img/Products/5.jpg" },
                    { new Guid("4fc122c4-ba54-4350-85ab-b50c0e176af6"), new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), "/img/Products/6.jpg" },
                    { new Guid("6e18de15-ba9e-4219-8f71-9a6bf6ec9377"), new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), "/img/Products/6.jpg" },
                    { new Guid("5bc96938-64d2-4d6a-aced-8f27cc1bb198"), new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), "/img/Products/5.jpg" },
                    { new Guid("cb651ccb-187c-4481-bf41-d7f741fe1405"), new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), "/img/Products/3.jpg" },
                    { new Guid("ddf85b63-da7e-4a1e-b70b-ffbff17b4b2b"), new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), "/img/Products/3.jpg" },
                    { new Guid("43ab8992-9894-409f-b39b-d50e9aa1b119"), new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), "/img/Products/2.jpg" },
                    { new Guid("b45e6f23-372e-42cb-b027-f64064953f5d"), new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), "/img/Products/3.jpg" },
                    { new Guid("a2fa654a-066d-4988-be96-3d60cf1fb49c"), new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), "/img/Products/1.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("01f51329-108a-4719-9c5e-2814b03fd851"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("31349315-168a-4ffe-b700-f3f61307ed34"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("322f854b-36d5-4239-a271-2e917f6bbbd7"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("326ea53d-6560-4adf-bfc9-694821670496"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("43ab8992-9894-409f-b39b-d50e9aa1b119"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("4fc122c4-ba54-4350-85ab-b50c0e176af6"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5bc96938-64d2-4d6a-aced-8f27cc1bb198"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("68f1abd2-4d42-4664-8f0f-e24b09888535"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("6e18de15-ba9e-4219-8f71-9a6bf6ec9377"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("72b4e684-3d77-4044-96fa-83a10568db92"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("79b22ce5-414b-4e82-9409-5ef2adf616f0"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("94071aa3-5452-4feb-8246-9a39bd1566ad"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("9541f59c-80c9-4529-8b4b-0ca3b116606d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("9d4fdad8-37d3-4b99-8f8a-79b6eda1242a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("a2fa654a-066d-4988-be96-3d60cf1fb49c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("b45e6f23-372e-42cb-b027-f64064953f5d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("cb651ccb-187c-4481-bf41-d7f741fe1405"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("d8dae5ad-3e8e-416d-95f5-f80a7a80ee07"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ddf85b63-da7e-4a1e-b70b-ffbff17b4b2b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("e04bd3f0-51e9-4436-8b81-330d77469cc6"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

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
        }
    }
}
