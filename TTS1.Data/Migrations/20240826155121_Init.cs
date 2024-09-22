using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTS.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PackagingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parameter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BatteryLevel = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sensors_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transports_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transports_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transports_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transports_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transports_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorDatas_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("002bcc7c-5f3d-41fd-8fa2-2c3168a09be9"), "7418807d-6a34-4a5c-b8cd-d6c85aa12fee", "User", "USER" },
                    { new Guid("3de5d956-82d9-4a56-8de5-7d440eb4216f"), "580b5fe5-8370-427a-964e-071ec9e52430", "Superadmin", "SUPERADMIN" },
                    { new Guid("b270ae59-5d7a-4ae8-bca1-2bf521af61cd"), "4127fdb0-7114-4e52-8ff6-3b897aad4c5c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Location", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("308aa8dc-7e56-4ef9-8a23-b21fad372cd4"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5420), null, null, false, "Ankara", null, null, "Albayrakoğlu Tarım İşletmesi" },
                    { new Guid("93580e2a-268c-4fab-a91d-76791940d6c6"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5398), null, null, false, "Düzce", null, null, "TMO" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "ImageType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"), "Admin Test", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5835), null, null, "İmages/pythontest", "png", 0, false, null, null },
                    { new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"), "Admin Test", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5832), null, null, "İmages/testimage", "jpg", 0, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Number", "PackagingDate", "Type" },
                values: new object[,]
                {
                    { new Guid("3082f889-efac-4a83-8eda-622dfe90c5b4"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5913), null, null, false, null, null, 1, new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5915), "Kutu" },
                    { new Guid("b411f8df-5816-4ba7-a86b-1d96c699b02c"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5917), null, null, false, null, null, 2, new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5918), "Torba" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5999), null, null, false, null, null, "Kestane", 250m, null },
                    { new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5994), null, null, false, null, null, "Fındık", 130m, null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DriverName", "ImageId", "IsDeleted", "Model", "ModifiedBy", "ModifiedDate", "Plate" },
                values: new object[,]
                {
                    { new Guid("7e52c16f-83f5-4fed-83d4-d64e1edc4098"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 388, DateTimeKind.Local).AddTicks(5011), null, null, "Esat Emir Albayrakoğlu", null, false, "Renault Clio 2006", null, null, "81 AH 975" },
                    { new Guid("cd55a1fb-e592-4679-8bca-5883dec0163f"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 388, DateTimeKind.Local).AddTicks(5018), null, null, "Melih Albayrakoğlu", null, false, "Toyota Corolla 2005", null, null, "06 DSA 100" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822"), 0, "bb455e4c-9dad-4c2a-b3f3-e15c7feb2e26", "admin@gmail.com", false, "Melih", new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"), "Albayrakoglu", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEK9dM7og+uM4d32XbiEpbw8TqEXyLUSPBcpwyOkgdNQtDkneDMURUbNbjwh+u5tIzA==", "1234566480", false, "edf52030-2600-418a-bb98-478a8de48a74", false, "admin@gmail.com" },
                    { new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e"), 0, "496babcb-cc42-4acc-b186-61d873cdb169", "superadmin@gmail.com", true, "Esat Emir", new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"), "Albayrakoglu", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENJDhoI5koI1v8fL6Mg5h5mco7sEup/1+2YT8UTGDtcylayMGN0cfNxI2BG/SFWVZQ==", "1234567890", true, "a9557dad-19c5-4676-89b8-dbb585d53ed7", false, "superadmin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ExpirationDate", "FacilityId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Parameter", "ProductId", "ProductionDate", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("30a9512b-ed73-4338-988c-5b43bc810de0"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(419), null, null, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Ayıklandı", "Ayıklama", new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"), new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(420) },
                    { new Guid("b9cdd9ca-b23c-4b0f-bd23-28ecbeb6be66"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(412), null, null, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Kurutmaya bırakıldı", "Kurutma", new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(414) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b270ae59-5d7a-4ae8-bca1-2bf521af61cd"), new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822") },
                    { new Guid("3de5d956-82d9-4a56-8de5-7d440eb4216f"), new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e") }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Location", "ModifiedBy", "ModifiedDate", "Name", "Size", "SoilType", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"), "Admin Test 2", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5610), null, null, false, "Erdemli Köyü", null, null, "Güney Tarla", 2.5, "Killi", new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822") },
                    { new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"), "Admin Test 1", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(5606), null, null, false, "Suncuk Köyü", null, null, "Taşlık Tarla", 3.0, "Kumlu", new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e") }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "ProductCount", "ProductId", "SaleDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("769256ce-a7b0-48e8-853b-08a8a4257639"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9539), null, null, false, null, null, 1m, new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9542), new Guid("b497f1b4-3299-4cb9-94af-e3a1a6c7ac8e") },
                    { new Guid("dfe84775-a1a2-4df3-a910-873c86876138"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9544), null, null, false, null, null, 2m, new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9546), new Guid("989afd35-55a6-40a2-92b7-725a9b0e8822") }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "BatteryLevel", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FieldId", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"), 0.0, "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(326), null, null, new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"), new Guid("d4a15540-afae-449e-b942-08b0e4e8f09c"), false, null, null, "Güney Tarla Sensör", "Toprak Nem Sensörü" },
                    { new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"), 0.0, "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(321), null, null, new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"), new Guid("e5008bc7-140d-4dd9-a739-5ebf8ee01fa8"), false, null, null, "Taşlıkbaş Sensör", "Fotokapan" }
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FacilityId", "FieldId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "PackageId", "ProductId", "Timestamp", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("cb6de695-3d05-4439-89c9-30493779abe9"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(495), null, null, new Guid("308aa8dc-7e56-4ef9-8a23-b21fad372cd4"), new Guid("2a5899ec-8b12-491c-9a4a-4e59c122d67d"), false, null, null, "Kestane Transfer", new Guid("b411f8df-5816-4ba7-a86b-1d96c699b02c"), new Guid("64ef8e12-5802-4295-b902-ab9e3f9f03bd"), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(497), new Guid("cd55a1fb-e592-4679-8bca-5883dec0163f") },
                    { new Guid("f214b7d2-b956-438f-a439-397d51529e1f"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(489), null, null, new Guid("93580e2a-268c-4fab-a91d-76791940d6c6"), new Guid("2c953ee3-f4d1-4766-857f-94327e2b6138"), false, null, null, "Fındık Transfer", new Guid("3082f889-efac-4a83-8eda-622dfe90c5b4"), new Guid("971f7086-05e6-4c7a-92a8-216c924affdb"), new DateTime(2024, 8, 26, 18, 51, 21, 385, DateTimeKind.Local).AddTicks(492), new Guid("7e52c16f-83f5-4fed-83d4-d64e1edc4098") }
                });

            migrationBuilder.InsertData(
                table: "SensorDatas",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SensorId", "Timestamp", "Unit", "Value" },
                values: new object[] { new Guid("81bb1b9f-ce56-4408-b00b-f7eb0e54c596"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9654), null, null, false, null, null, new Guid("0123f278-ff34-44d0-af18-f7f5882ed35a"), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9656), "pH", "Toprak nemi 12 bar olarak ölçülmüştür." });

            migrationBuilder.InsertData(
                table: "SensorDatas",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SensorId", "Timestamp", "Unit", "Value" },
                values: new object[] { new Guid("a7bde811-3e08-4378-96be-d1d1fd1771d2"), "Undefined", new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9648), null, null, false, null, null, new Guid("fde368ee-2228-43ee-b3cc-1ea8932843a5"), new DateTime(2024, 8, 26, 18, 51, 21, 384, DateTimeKind.Local).AddTicks(9651), "°C", "Fotokapan kayıtlarına göre bir canlı kayıtlara girmiştir." });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_UserId",
                table: "Fields",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorDatas_SensorId",
                table: "SensorDatas",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_FieldId",
                table: "Sensors",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_ImageId",
                table: "Sensors",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_FacilityId",
                table: "Stages",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ProductId",
                table: "Stages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_FacilityId",
                table: "Transports",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_FieldId",
                table: "Transports",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_PackageId",
                table: "Transports",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_ProductId",
                table: "Transports",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_VehicleId",
                table: "Transports",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ImageId",
                table: "Vehicles",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SensorDatas");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
