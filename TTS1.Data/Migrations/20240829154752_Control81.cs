using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTS.Data.Migrations
{
    public partial class Control81 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("57da7760-752b-47ca-9489-fbecd5174c8b"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("86b55bbd-9b69-44f3-81e1-95391808b77c"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Transports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Stages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Sensors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SensorDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Fields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3093), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd9ca-b23c-4b0f-bd23-28ecbeb6be66"),
                columns: new[] { "CreatedDate", "Timestamp" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3085), new DateTime(2024, 8, 29, 18, 47, 51, 772, DateTimeKind.Local).AddTicks(3089) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("7e54d8f3-7b5a-4369-af03-31c3dcd404a7"));

            migrationBuilder.DeleteData(
                table: "SensorDatas",
                keyColumn: "Id",
                keyValue: new Guid("d570ea2f-fdfd-4f27-bb49-007b2df5727a"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Transports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Stages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Sensors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SensorDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Fields",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 15, 7, 29, 981, DateTimeKind.Local).AddTicks(4129));

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
    }
}
