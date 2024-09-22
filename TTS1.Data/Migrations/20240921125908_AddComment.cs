using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTS.Data.Migrations
{
    public partial class AddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("7a7e1174-587c-4f03-b693-8e9b76827589"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("f78ea244-ac8e-4e50-9fa8-31b99a319384"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("002bcc7c-5f3d-41fd-8fa2-2c3168a09be9"),
                column: "ConcurrencyStamp",
                value: "f01e0809-dcd5-4b5b-9055-d03c2fda5cbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3de5d956-82d9-4a56-8de5-7d440eb4216f"),
                column: "ConcurrencyStamp",
                value: "4370917b-f777-4f89-a37b-9ade12b1b01a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b270ae59-5d7a-4ae8-bca1-2bf521af61cd"),
                column: "ConcurrencyStamp",
                value: "14abddf5-046b-47ed-be7e-776397b581f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb017436-b182-4821-8f68-40eae3ad30b7", "AQAAAAEAACcQAAAAEOm9jsn5V8DWnwI2Z4ZRLwFjaOzFC0fm+xe4fOqZ9jbebLfKoMCEcrbyvNX6X9QA5Q==", "c6a76f18-977a-4129-9498-f6730dc518a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a7bcfb0-e720-4db0-8e1c-de5e6c366ad8", "AQAAAAEAACcQAAAAEMI1owLUkaiBqldvWnmysZD9Voa7pi4oGrrxI5vbHs8XgBHfFetXqX5N6ga+tZj95A==", "197f1424-2aad-4690-96c4-061fc3bcfec6" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "ProductId", "Title" },
                values: new object[,]
                {
                    { new Guid("2de2b4a1-43dc-4d67-9699-621c79f39f02"), "Bu siteyi yapana çok teşekkürlerimi sunarım", "Undefined", new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(1993), null, null, false, null, null, new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"), "Bu siteyi yapana çok teşekkürlerimi sunarım" },
                    { new Guid("37bbd36a-3643-4168-8476-14d7945d25e1"), "Her bilgiye ulaşmamız çok iyi", "Undefined", new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(1969), null, null, false, null, null, new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"), "Her bilgiye ulaşmamız çok iyi" }
                });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("308aa8dc-7e56-4ef9-8a23-b21fad372cd4"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("93580e2a-268c-4fab-a91d-76791940d6c6"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("3082f889-efac-4a83-8eda-622dfe90c5b4"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2606), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2609) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("b411f8df-5816-4ba7-a86b-1d96c699b02c"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2610), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2611) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("769256ce-a7b0-48e8-853b-08a8a4257639"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(6481), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(6485) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("dfe84775-a1a2-4df3-a910-873c86876138"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(6488), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.InsertData(
                table: "SensorDatas",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SensorId", "Timestamp", "Unit", "Value" },
                values: new object[,]
                {
                    { new Guid("96f8af9c-f46d-4232-a3e7-d0d4f5856949"), "Undefined", new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7102), null, null, false, null, null, new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7109), "°C", "Fotokapan kayıtlarına göre bir canlı kayıtlara girmiştir." },
                    { new Guid("e76d5835-f3a0-490e-b60f-cd9b70e37753"), "Undefined", new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7110), null, null, false, null, null, new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7112), "pH", "Toprak nemi 12 bar olarak ölçülmüştür." }
                });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("30a9512b-ed73-4338-988c-5b43bc810de0"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7281), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd9ca-b23c-4b0f-bd23-28ecbeb6be66"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7278), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("cb6de695-3d05-4439-89c9-30493779abe9"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7368), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("f214b7d2-b956-438f-a439-397d51529e1f"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7359), new DateTime(2024, 9, 21, 15, 59, 7, 655, DateTimeKind.Local).AddTicks(7363) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7e52c16f-83f5-4fed-83d4-d64e1edc4098"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 659, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("cd55a1fb-e592-4679-8bca-5883dec0163f"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 21, 15, 59, 7, 659, DateTimeKind.Local).AddTicks(33));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("96f8af9c-f46d-4232-a3e7-d0d4f5856949"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("e76d5835-f3a0-490e-b60f-cd9b70e37753"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("002bcc7c-5f3d-41fd-8fa2-2c3168a09be9"),
                column: "ConcurrencyStamp",
                value: "abc8db04-eb40-4ac6-b836-1133d376be3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3de5d956-82d9-4a56-8de5-7d440eb4216f"),
                column: "ConcurrencyStamp",
                value: "2d577418-3b65-41d4-b645-6e1cecb4c91a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b270ae59-5d7a-4ae8-bca1-2bf521af61cd"),
                column: "ConcurrencyStamp",
                value: "bf8538dc-5000-4fa0-b622-1fc6e1036aaa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b898ace2-fd5b-4351-8301-61e264bcd6f3", "AQAAAAEAACcQAAAAEOD4bI5kCBCZY5rrRKwJQbiOBMQk4lQMTBle9SYKVEQ6KzXROI//2R9pVZ/CSlkKCw==", "67a9fcdb-f58e-4990-96b1-162332ba162b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bce0b2bf-78a8-464f-a722-a612ce2079ac", "AQAAAAEAACcQAAAAEJTsSID7+DIlP00CoiUoGBxwxcfbSiE/wxko+k9mzcpHvRMLpbqGkZueNARM5y25TQ==", "11cad848-e435-4fd2-8ab0-fa8aa6980726" });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("308aa8dc-7e56-4ef9-8a23-b21fad372cd4"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("93580e2a-268c-4fab-a91d-76791940d6c6"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("3082f889-efac-4a83-8eda-622dfe90c5b4"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1349), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1352) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("b411f8df-5816-4ba7-a86b-1d96c699b02c"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1354), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1355) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("769256ce-a7b0-48e8-853b-08a8a4257639"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5411), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("dfe84775-a1a2-4df3-a910-873c86876138"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5418), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.InsertData(
                table: "SensorDatas",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SensorId", "Timestamp", "Unit", "Value" },
                values: new object[,]
                {
                    { new Guid("7a7e1174-587c-4f03-b693-8e9b76827589"), "Undefined", new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5507), null, null, false, null, null, new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5510), "°C", "Fotokapan kayıtlarına göre bir canlı kayıtlara girmiştir." },
                    { new Guid("f78ea244-ac8e-4e50-9fa8-31b99a319384"), "Undefined", new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5512), null, null, false, null, null, new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(5514), "pH", "Toprak nemi 12 bar olarak ölçülmüştür." }
                });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("30a9512b-ed73-4338-988c-5b43bc810de0"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6288), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6289) });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd9ca-b23c-4b0f-bd23-28ecbeb6be66"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6264), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6267) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("cb6de695-3d05-4439-89c9-30493779abe9"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6386), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6388) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("f214b7d2-b956-438f-a439-397d51529e1f"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6378), new DateTime(2024, 9, 6, 19, 12, 4, 408, DateTimeKind.Local).AddTicks(6383) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7e52c16f-83f5-4fed-83d4-d64e1edc4098"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 411, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("cd55a1fb-e592-4679-8bca-5883dec0163f"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 19, 12, 4, 411, DateTimeKind.Local).AddTicks(8878));
        }
    }
}
