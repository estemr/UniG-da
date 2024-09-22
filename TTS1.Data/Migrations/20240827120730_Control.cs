using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTS.Data.Migrations
{
    public partial class Control : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("81bb1b9f-ce56-4408-b00b-f7eb0e54c596"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("a7bde811-3e08-4378-96be-d1d1fd1771d2"));

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("002bcc7c-5f3d-41fd-8fa2-2c3168a09be9"),
                column: "ConcurrencyStamp",
                value: "b0f181fc-3567-446d-9b7d-472bae77d405");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3de5d956-82d9-4a56-8de5-7d440eb4216f"),
                column: "ConcurrencyStamp",
                value: "0658193e-88f6-4be5-9460-6801951176db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b270ae59-5d7a-4ae8-bca1-2bf521af61cd"),
                column: "ConcurrencyStamp",
                value: "2268cd37-9bff-4059-9c2d-082e671a1685");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ff9c168-df4e-474f-bf63-d7758cbc08df", "AQAAAAEAACcQAAAAEDySsitafAtsS7+ViqM/bMUgQ/SY+2RSUdSUXuYnTdwTdKCtjK1yQsncDliK1zhH3g==", "8c6e86f6-6308-4685-b75f-6f040546d42e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae23073a-4ca0-4f9f-bddf-09f07e14743e", "AQAAAAEAACcQAAAAEJsjR4ZJSUVfpBhMVsiMf1AQO6vbKJDPJHBZdGLd7glGvT7W+0wTVyflECrts+uzpA==", "8611e1f1-3af9-428c-b0b9-cb4345ee0e81" });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("308aa8dc-7e56-4ef9-8a23-b21fad372cd4"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("93580e2a-268c-4fab-a91d-76791940d6c6"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("3082f889-efac-4a83-8eda-622dfe90c5b4"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4032), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("b411f8df-5816-4ba7-a86b-1d96c699b02c"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4047), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4048) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"),
                columns: new[] { "CreatedDate", "Unit" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4134), "Tane" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"),
                columns: new[] { "CreatedDate", "Unit" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4129), "Kg" });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("769256ce-a7b0-48e8-853b-08a8a4257639"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7716), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("dfe84775-a1a2-4df3-a910-873c86876138"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7723), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7726) });

            migrationBuilder.InsertData(
                table: "SensorDatas",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SensorId", "Timestamp", "Unit", "Value" },
                values: new object[,]
                {
                    { new Guid("57da7760-752b-47ca-9489-fbecd5174c8b"), "Undefined", new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7807), null, null, false, null, null, new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7810), "°C", "Fotokapan kayıtlarına göre bir canlı kayıtlara girmiştir." },
                    { new Guid("86b55bbd-9b69-44f3-81e1-95391808b77c"), "Undefined", new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7833), null, null, false, null, null, new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(7834), "pH", "Toprak nemi 12 bar olarak ölçülmüştür." }
                });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("30a9512b-ed73-4338-988c-5b43bc810de0"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8584), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8586) });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd9ca-b23c-4b0f-bd23-28ecbeb6be66"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8578), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("cb6de695-3d05-4439-89c9-30493779abe9"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8671), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8676) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("f214b7d2-b956-438f-a439-397d51529e1f"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8662), new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7e52c16f-83f5-4fed-83d4-d64e1edc4098"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 985, DateTimeKind.Local).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("cd55a1fb-e592-4679-8bca-5883dec0163f"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 985, DateTimeKind.Local).AddTicks(4467));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("57da7760-752b-47ca-9489-fbecd5174c8b"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("86b55bbd-9b69-44f3-81e1-95391808b77c"));

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("002bcc7c-5f3d-41fd-8fa2-2c3168a09be9"),
                column: "ConcurrencyStamp",
                value: "7418807d-6a34-4a5c-b8cd-d6c85aa12fee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3de5d956-82d9-4a56-8de5-7d440eb4216f"),
                column: "ConcurrencyStamp",
                value: "580b5fe5-8370-427a-964e-071ec9e52430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b270ae59-5d7a-4ae8-bca1-2bf521af61cd"),
                column: "ConcurrencyStamp",
                value: "4127fdb0-7114-4e52-8ff6-3b897aad4c5c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb455e4c-9dad-4c2a-b3f3-e15c7feb2e26", "AQAAAAEAACcQAAAAEK9dM7og+uM4d32XbiEpbw8TqEXyLUSPBcpwyOkgdNQtDkneDMURUbNbjwh+u5tIzA==", "edf52030-2600-418a-bb98-478a8de48a74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "496babcb-cc42-4acc-b186-61d873cdb169", "AQAAAAEAACcQAAAAENJDhoI5koI1v8fL6Mg5h5mco7sEup/1+2YT8UTGDtcylayMGN0cfNxI2BG/SFWVZQ==", "a9557dad-19c5-4676-89b8-dbb585d53ed7" });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("308aa8dc-7e56-4ef9-8a23-b21fad372cd4"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("93580e2a-268c-4fab-a91d-76791940d6c6"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("3082f889-efac-4a83-8eda-622dfe90c5b4"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5913), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5915) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("b411f8df-5816-4ba7-a86b-1d96c699b02c"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5917), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("769256ce-a7b0-48e8-853b-08a8a4257639"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9539), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("dfe84775-a1a2-4df3-a910-873c86876138"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9544), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9546) });

            migrationBuilder.InsertData(
                table: "SensorDatas",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SensorId", "Timestamp", "Unit", "Value" },
                values: new object[,]
                {
                    { new Guid("81bb1b9f-ce56-4408-b00b-f7eb0e54c596"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9654), null, null, false, null, null, new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9656), "pH", "Toprak nemi 12 bar olarak ölçülmüştür." },
                    { new Guid("a7bde811-3e08-4378-96be-d1d1fd1771d2"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9648), null, null, false, null, null, new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9651), "°C", "Fotokapan kayıtlarına göre bir canlı kayıtlara girmiştir." }
                });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("30a9512b-ed73-4338-988c-5b43bc810de0"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(419), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd9ca-b23c-4b0f-bd23-28ecbeb6be66"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(412), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(414) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("cb6de695-3d05-4439-89c9-30493779abe9"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(495), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(497) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("f214b7d2-b956-438f-a439-397d51529e1f"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(489), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7e52c16f-83f5-4fed-83d4-d64e1edc4098"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 388, DateTimeKind.Local).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("cd55a1fb-e592-4679-8bca-5883dec0163f"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 26, 18, 51, 21, 388, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
