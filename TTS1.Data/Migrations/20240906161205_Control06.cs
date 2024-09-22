using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTS.Data.Migrations
{
    public partial class Control06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("7e54d8f3-7b5a-4369-af03-31c3dcd404a7"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("d570ea2f-fdfd-4f27-bb49-007b2df5727a"));

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Stages");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("7a7e1174-587c-4f03-b693-8e9b76827589"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("f78ea244-ac8e-4e50-9fa8-31b99a319384"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Stages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Stages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("002bcc7c-5f3d-41fd-8fa2-2c3168a09be9"),
                column: "ConcurrencyStamp",
                value: "0d922f51-ef05-46b7-8b2c-c4cedf315cdc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3de5d956-82d9-4a56-8de5-7d440eb4216f"),
                column: "ConcurrencyStamp",
                value: "c9a0b8ce-13b5-4234-8d2c-5c34507dda8a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b270ae59-5d7a-4ae8-bca1-2bf521af61cd"),
                column: "ConcurrencyStamp",
                value: "3135b6a5-5f62-4bc9-93bb-886e7f9e6dc5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c1f0c4d-783e-48a6-91b6-69fe4d0a97a1", "AQAAAAEAACcQAAAAEE9tK2pwwHQWJZJhAL+OUWXjHUtUZemBPF8agZjhBWwwLrK1jvYbTFfTTD8isxNE6w==", "b4cf659a-7d24-423c-8f3f-5113bbdc3fd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9967489-7147-45c9-b8e5-46d94ba898c3", "AQAAAAEAACcQAAAAEFS7/+eOY687s27UDOFVoE7B/O8PI8A3ybWb/dHGnUc0VEugFg2ThN7zntCMQyGWQQ==", "3795f3b5-b6e1-4a79-b1dd-fbffba0502f8" });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("308aa8dc-7e56-4ef9-8a23-b21fad372cd4"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("93580e2a-268c-4fab-a91d-76791940d6c6"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("3082f889-efac-4a83-8eda-622dfe90c5b4"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8353), new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("b411f8df-5816-4ba7-a86b-1d96c699b02c"),
                columns: new[] { "CreatedDate", "PackagingDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8358), new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 771, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("769256ce-a7b0-48e8-853b-08a8a4257639"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2116), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("dfe84775-a1a2-4df3-a910-873c86876138"),
                columns: new[] { "CreatedDate", "SaleDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2130), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.InsertData(
                table: "SensorDatas",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SensorId", "Timestamp", "Unit", "Value" },
                values: new object[,]
                {
                    { new Guid("7e54d8f3-7b5a-4369-af03-31c3dcd404a7"), "Undefined", new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2256), null, null, false, null, null, new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2261), "°C", "Fotokapan kayıtlarına göre bir canlı kayıtlara girmiştir." },
                    { new Guid("d570ea2f-fdfd-4f27-bb49-007b2df5727a"), "Undefined", new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2262), null, null, false, null, null, new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2264), "pH", "Toprak nemi 12 bar olarak ölçülmüştür." }
                });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("30a9512b-ed73-4338-988c-5b43bc810de0"),
                columns: new[] { "CreatedDate", "ExpirationDate", "ProductionDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3093), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd9ca-b23c-4b0f-bd23-28ecbeb6be66"),
                columns: new[] { "CreatedDate", "ExpirationDate", "ProductionDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3085), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3089) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("cb6de695-3d05-4439-89c9-30493779abe9"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3185), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3187) });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: new Guid("f214b7d2-b956-438f-a439-397d51529e1f"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3174), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("7e52c16f-83f5-4fed-83d4-d64e1edc4098"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 775, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("cd55a1fb-e592-4679-8bca-5883dec0163f"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 18, 47, 51, 775, DateTimeKind.Local).AddTicks(6011));
        }
    }
}
