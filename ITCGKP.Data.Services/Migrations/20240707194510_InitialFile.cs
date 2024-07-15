using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ITCGKP.Data.Services.Migrations
{
    public partial class InitialFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckMessageSendTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustCode = table.Column<int>(type: "integer", nullable: true),
                    CurrentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TodayMessageSend = table.Column<bool>(type: "boolean", nullable: false),
                    MessageType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckMessageSendTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FontCustomTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FontCustomTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadGroupTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HDGCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Ledger_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Under_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nature = table.Column<int>(type: "integer", nullable: true),
                    TNo1 = table.Column<int>(type: "integer", nullable: false),
                    EffectGrossProfit = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadGroupTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroupTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItGPCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    ItemGroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IHSNCode = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    IGSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CGSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    SGSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CessPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroupTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackingTable",
                columns: table => new
                {
                    PackId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PackCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    PackName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingTable", x => x.PackId);
                });

            migrationBuilder.CreateTable(
                name: "PatientIITable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MobileNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TitleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Sex = table.Column<int>(type: "integer", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    AgeType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientIITable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCompanyTable",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    ProdName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompanyTable", x => x.ProdId);
                });

            migrationBuilder.CreateTable(
                name: "StateTable",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTable", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "TitlesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadPhotoFrontTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descriptions = table.Column<string>(type: "text", nullable: true),
                    GroupName = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadPhotoFrontTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UQCMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UQCMasterTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                name: "DistrictTable",
                columns: table => new
                {
                    DistId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DistStateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictTable", x => x.DistId);
                    table.ForeignKey(
                        name: "FK_DistrictTable_StateTable_DistStateId",
                        column: x => x.DistStateId,
                        principalTable: "StateTable",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasurementTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    UnitName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UQCId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasurementTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitMeasurementTable_UQCMasterTable_UQCId",
                        column: x => x.UQCId,
                        principalTable: "UQCMasterTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetailTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PinNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    DistId = table.Column<int>(type: "integer", nullable: true),
                    PhoneNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MobileNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GSTNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Jurisdiction = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TransCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UptoDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActionForm = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    SignaturePhotoPath = table.Column<string>(type: "text", nullable: true),
                    SignaturePhotoPathLeft = table.Column<string>(type: "text", nullable: true),
                    PhotoPathPrint = table.Column<bool>(type: "boolean", nullable: false),
                    SignaturePrint = table.Column<bool>(type: "boolean", nullable: false),
                    SignaturePrintLeft = table.Column<bool>(type: "boolean", nullable: false),
                    ExitFooterReport = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetailTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDetailTable_DistrictTable_DistId",
                        column: x => x.DistId,
                        principalTable: "DistrictTable",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyDetailTable_StateTable_StateId",
                        column: x => x.StateId,
                        principalTable: "StateTable",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTable",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemCode = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    PackId = table.Column<int>(type: "integer", nullable: true),
                    ItGPCode = table.Column<int>(type: "integer", nullable: true),
                    ProdId = table.Column<int>(type: "integer", nullable: true),
                    UnitId = table.Column<int>(type: "integer", nullable: true),
                    ItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IHSNCode = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    DiscPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CessPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ProfitPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    UnitCase = table.Column<int>(type: "integer", nullable: false),
                    ShowStock = table.Column<int>(type: "integer", nullable: false),
                    ReversCharge = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTable", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemTable_ItemGroupTable_ItGPCode",
                        column: x => x.ItGPCode,
                        principalTable: "ItemGroupTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTable_PackingTable_PackId",
                        column: x => x.PackId,
                        principalTable: "PackingTable",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTable_ProductCompanyTable_ProdId",
                        column: x => x.ProdId,
                        principalTable: "ProductCompanyTable",
                        principalColumn: "ProdId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTable_UnitMeasurementTable_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitMeasurementTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountConfigTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    SaleCode = table.Column<int>(type: "integer", nullable: false),
                    CreditCode = table.Column<int>(type: "integer", nullable: false),
                    PurCode = table.Column<int>(type: "integer", nullable: false),
                    DebitCode = table.Column<int>(type: "integer", nullable: false),
                    FreightCode = table.Column<int>(type: "integer", nullable: false),
                    FreightOut = table.Column<int>(type: "integer", nullable: false),
                    CGSTCode = table.Column<int>(type: "integer", nullable: false),
                    SGSTCode = table.Column<int>(type: "integer", nullable: false),
                    IGSTCode = table.Column<int>(type: "integer", nullable: false),
                    CessCode = table.Column<int>(type: "integer", nullable: false),
                    DiscCode = table.Column<int>(type: "integer", nullable: false),
                    DiscAllowed = table.Column<int>(type: "integer", nullable: false),
                    CashCode = table.Column<int>(type: "integer", nullable: false),
                    DigitalCode = table.Column<int>(type: "integer", nullable: false),
                    AdvCode = table.Column<int>(type: "integer", nullable: false),
                    CommissionCode = table.Column<int>(type: "integer", nullable: false),
                    ServiceCode = table.Column<int>(type: "integer", nullable: false),
                    ServiceOut = table.Column<int>(type: "integer", nullable: false),
                    StockCode = table.Column<int>(type: "integer", nullable: false),
                    ProfitCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountConfigTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountConfigTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgentFileTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompIdA = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PinNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    MobileNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IPAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    BankName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BankAcNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IFSC = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    EPFAcNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BasicPay = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    HRA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CCA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TransferStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveType = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentFileTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentFileTable_CompanyDetailTable_CompIdA",
                        column: x => x.CompIdA,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreaFileTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompIdA = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaFileTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaFileTable_CompanyDetailTable_CompIdA",
                        column: x => x.CompIdA,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AreaFileTable_DistrictTable_DistId",
                        column: x => x.DistId,
                        principalTable: "DistrictTable",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFileTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompIdA = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PinNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    MobileNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RegPanel = table.Column<int>(type: "integer", nullable: false),
                    ActiveType = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFileTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientFileTable_CompanyDetailTable_CompIdA",
                        column: x => x.CompIdA,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorLabTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MobileNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Education = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PrintReport = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IPAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorLabTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorLabTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MobileNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Education = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeadTable",
                columns: table => new
                {
                    LedgerMasterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    LedCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PartyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PinNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LedStateId = table.Column<int>(type: "integer", nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PhoneNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MobileNo1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MobileNo2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PanNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AdharNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GSTNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AcGroupId = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateOfAnversary = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OpnAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OpnAc = table.Column<int>(type: "integer", nullable: true),
                    CloseAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CloseAc = table.Column<int>(type: "integer", nullable: true),
                    PrintTag = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadTable", x => x.LedgerMasterId);
                    table.ForeignKey(
                        name: "FK_HeadTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadTable_HeadGroupTable_AcGroupId",
                        column: x => x.AcGroupId,
                        principalTable: "HeadGroupTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadTable_StateTable_LedStateId",
                        column: x => x.LedStateId,
                        principalTable: "StateTable",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    TestDetailsA = table.Column<string>(type: "text", nullable: true),
                    PatResultA = table.Column<string>(type: "text", nullable: true),
                    RangeDetailsA = table.Column<string>(type: "text", nullable: true),
                    TestLineA = table.Column<bool>(type: "boolean", nullable: false),
                    TestDetailsB = table.Column<string>(type: "text", nullable: true),
                    PatResultB = table.Column<string>(type: "text", nullable: true),
                    RangeDetailsB = table.Column<string>(type: "text", nullable: true),
                    TestLineB = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedMasterTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoneyMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    MerchantId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    APIKey = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    APISalt = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AuthKey = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PostURL = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SurURL = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FurURL = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyMasterTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpenItemMasterTable",
                columns: table => new
                {
                    OpnId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: false),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    OpnVNo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    OpnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenItemMasterTable", x => x.OpnId);
                    table.ForeignKey(
                        name: "FK_OpenItemMasterTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageSetupTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    LeftA = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RightA = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TopA = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BottomA = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CustomPapersizeA = table.Column<int>(type: "integer", nullable: false),
                    CustomOrientationA = table.Column<int>(type: "integer", nullable: false),
                    LeftB = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RightB = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TopB = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BottomB = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CustomPapersizeB = table.Column<int>(type: "integer", nullable: false),
                    CustomOrientationB = table.Column<int>(type: "integer", nullable: false),
                    PageHeaderB = table.Column<string>(type: "text", nullable: true),
                    PageFooterB = table.Column<string>(type: "text", nullable: true),
                    PrintHeaderB = table.Column<bool>(type: "boolean", nullable: false),
                    PrintFooterB = table.Column<bool>(type: "boolean", nullable: false),
                    HeaderPhotoPath = table.Column<string>(type: "text", nullable: true),
                    HeaderPhotoFile = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderPrint = table.Column<bool>(type: "boolean", nullable: false),
                    FooterPhotoPath = table.Column<string>(type: "text", nullable: true),
                    FooterPhotoFile = table.Column<string>(type: "text", nullable: true),
                    ReportFooterPrintA = table.Column<bool>(type: "boolean", nullable: false),
                    ReportFooterB = table.Column<string>(type: "text", nullable: true),
                    ReportFooterPrintB = table.Column<bool>(type: "boolean", nullable: false),
                    LeftR = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RightR = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TopR = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BottomR = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CustomPapersizeR = table.Column<int>(type: "integer", nullable: false),
                    CustomOrientationR = table.Column<int>(type: "integer", nullable: false),
                    LeftC = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RightC = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TopC = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BottomC = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CustomPapersizeC = table.Column<int>(type: "integer", nullable: false),
                    CustomOrientationC = table.Column<int>(type: "integer", nullable: false),
                    HeaderFont = table.Column<string>(type: "text", nullable: true),
                    HeaderSize = table.Column<string>(type: "text", nullable: true),
                    HeaderStyle = table.Column<string>(type: "text", nullable: true),
                    HeaderWeight = table.Column<string>(type: "text", nullable: true),
                    HeaderColor = table.Column<string>(type: "text", nullable: true),
                    HeaderDecorate = table.Column<string>(type: "text", nullable: true),
                    HeaderDetails = table.Column<string>(type: "text", nullable: true),
                    HeaderSecondFont = table.Column<string>(type: "text", nullable: true),
                    HeaderSecondSize = table.Column<string>(type: "text", nullable: true),
                    HeaderSecondStyle = table.Column<string>(type: "text", nullable: true),
                    HeaderSecondWeight = table.Column<string>(type: "text", nullable: true),
                    HeaderSecondColor = table.Column<string>(type: "text", nullable: true),
                    HeaderSecondDecorate = table.Column<string>(type: "text", nullable: true),
                    HeaderSecondDetails = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderFont = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderSize = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderStyle = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderWeight = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderLineHeight = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderColor = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderDecorate = table.Column<string>(type: "text", nullable: true),
                    ReportHeaderDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeLDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeMDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeYDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeSDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeBDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeNormalDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeUnnormalDetails = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeFont = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeSize = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeStyle = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeWeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeLineHeight = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeColor = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeDecorate = table.Column<string>(type: "text", nullable: true),
                    TestLockTypeRangeDetails = table.Column<string>(type: "text", nullable: true),
                    PrintMedReport = table.Column<bool>(type: "boolean", nullable: false),
                    MedReportType = table.Column<int>(type: "integer", nullable: true),
                    BarcodeTop = table.Column<bool>(type: "boolean", nullable: false),
                    TestHeaderTop = table.Column<bool>(type: "boolean", nullable: false),
                    PatientRefNo = table.Column<bool>(type: "boolean", nullable: false),
                    PatientRefNoGroupwise = table.Column<bool>(type: "boolean", nullable: false),
                    PagePrintLine = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OnePrintChart = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    QRCodePrint = table.Column<bool>(type: "boolean", nullable: false),
                    BarCodePrint = table.Column<bool>(type: "boolean", nullable: false),
                    TestFormulaApply = table.Column<bool>(type: "boolean", nullable: false),
                    FormulaDecimalPlace = table.Column<int>(type: "integer", nullable: true),
                    PrintBillOneTwo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSetupTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSetupTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientAuditTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatId = table.Column<int>(type: "integer", nullable: true),
                    CompId = table.Column<int>(type: "integer", nullable: false),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    SDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    RefNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PatientInformation = table.Column<string>(type: "text", nullable: true),
                    PaidPreInformation = table.Column<string>(type: "text", nullable: true),
                    PaidPostInformation = table.Column<string>(type: "text", nullable: true),
                    UpdateType = table.Column<string>(type: "text", nullable: true),
                    SelectDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    EditUserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAuditTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAuditTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportGroupTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TempNo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportGroupTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportGroupTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleRTable",
                columns: table => new
                {
                    SRId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    SRVNo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    SDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CustName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustAddress1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TaxAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NetAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleRTable", x => x.SRId);
                    table.ForeignKey(
                        name: "FK_SaleRTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleTable",
                columns: table => new
                {
                    SSId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    SSVNo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    SDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PayMode = table.Column<int>(type: "integer", nullable: false),
                    CustName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustAddress1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TaxAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NetAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CreditAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PaidAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CustAcCode = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTable", x => x.SSId);
                    table.ForeignKey(
                        name: "FK_SaleTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSFileTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    Dateofbirth = table.Column<string>(type: "text", nullable: false),
                    DateofAnniversary = table.Column<string>(type: "text", nullable: false),
                    DateOfInstallment = table.Column<string>(type: "text", nullable: false),
                    DateOfMaturity = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSFileTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSFileTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSKeyTable",
                columns: table => new
                {
                    SMSKeyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    APIKeyNo = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    SenderName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MessageDetail = table.Column<string>(type: "text", nullable: true),
                    MessageType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MessageActive = table.Column<bool>(type: "boolean", nullable: false),
                    URLName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSKeyTable", x => x.SMSKeyId);
                    table.ForeignKey(
                        name: "FK_SMSKeyTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestGroupTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    IPPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IPAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestGroupTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestGroupTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResultTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    TestIdX = table.Column<int>(type: "integer", nullable: true),
                    TestDetailName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResultTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResultTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoucherTable",
                columns: table => new
                {
                    VId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    VType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    VVNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    VDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DrAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CrAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherTable", x => x.VId);
                    table.ForeignKey(
                        name: "FK_VoucherTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemBalanceTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: false),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    BatchNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MRP = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetSaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CessPer = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OnFreeCase = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    BalQty = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBalanceTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBalanceTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemBalanceTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemStockTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    VouchVNo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    VouchDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    BatchNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OpnPCS = table.Column<int>(type: "integer", nullable: false),
                    PurPCS = table.Column<int>(type: "integer", nullable: false),
                    PurRtPCS = table.Column<int>(type: "integer", nullable: false),
                    SalePCS = table.Column<int>(type: "integer", nullable: false),
                    SaleRtPCS = table.Column<int>(type: "integer", nullable: false),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    SaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetSaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TempNo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStockTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemStockTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemStockTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayBillTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: false),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    VDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    BasicPay = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    AttendDays = table.Column<int>(type: "integer", nullable: false),
                    NewBasicPay = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    HRA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CCA = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IPAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    BonusAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TotalPay = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    EFP = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    AdvAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    AdvRemarks = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LIC = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalDedPay = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NetPay = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayBillTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayBillTable_AgentFileTable_EmpId",
                        column: x => x.EmpId,
                        principalTable: "AgentFileTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayBillTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CompanyDetailId = table.Column<int>(type: "integer", nullable: true),
                    ClientId = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ClientFileTable_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientFileTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CompanyDetailTable_CompanyDetailId",
                        column: x => x.CompanyDetailId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: false),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    VNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    STime = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    RDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RTime = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    RefNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TitleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AdharNo = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    AgeType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    MobileNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    EmailAuto = table.Column<bool>(type: "boolean", nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ClientCode = table.Column<int>(type: "integer", nullable: false),
                    CollectedIn = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AgentAcCode = table.Column<int>(type: "integer", nullable: false),
                    DrName = table.Column<string>(type: "text", nullable: true),
                    DoctorAcCode = table.Column<int>(type: "integer", nullable: true),
                    PaymentType = table.Column<int>(type: "integer", nullable: false),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalIPAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscountReasion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ApprovalBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DiscountType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DiscPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    AreaCode = table.Column<int>(type: "integer", nullable: false),
                    PatientAreadCodeId = table.Column<int>(type: "integer", nullable: true),
                    CollectionCharge = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CollectionBoy = table.Column<string>(type: "text", nullable: true),
                    DeliveryCharge = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DeliveryBoy = table.Column<string>(type: "text", nullable: true),
                    PaidAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    BalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    TestDetailRecord = table.Column<string>(type: "text", nullable: true),
                    ReportDate = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    ReportCancel = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ResultNotDone = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ResultDone = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ReportApproved = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ReportIssue = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ReportHold = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ReportRecipt = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ReportDispatch = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    DispatchColorHold = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    DrLabId = table.Column<int>(type: "integer", nullable: true),
                    PrintBill = table.Column<bool>(type: "boolean", nullable: false),
                    EditUserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientTable_AgentFileTable_AgentAcCode",
                        column: x => x.AgentAcCode,
                        principalTable: "AgentFileTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTable_AreaFileTable_PatientAreadCodeId",
                        column: x => x.PatientAreadCodeId,
                        principalTable: "AreaFileTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientTable_ClientFileTable_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "ClientFileTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTable_DoctorLabTable_DrLabId",
                        column: x => x.DrLabId,
                        principalTable: "DoctorLabTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientTable_HeadTable_DoctorAcCode",
                        column: x => x.DoctorAcCode,
                        principalTable: "HeadTable",
                        principalColumn: "LedgerMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderTable",
                columns: table => new
                {
                    SOId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    SOVNo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    ODate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AcCode = table.Column<int>(type: "integer", nullable: false),
                    CustName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustAddress1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderTable", x => x.SOId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTable_HeadTable_AcCode",
                        column: x => x.AcCode,
                        principalTable: "HeadTable",
                        principalColumn: "LedgerMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRTable",
                columns: table => new
                {
                    STId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: false),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    STVNo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    STDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AcCode = table.Column<int>(type: "integer", nullable: false),
                    CustName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustAddress1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CustLedStateId = table.Column<int>(type: "integer", nullable: false),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CGSTTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    SGSTTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IGSTTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CessTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OtherAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OtherAmt2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NetAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CashAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DigitalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRTable", x => x.STId);
                    table.ForeignKey(
                        name: "FK_PurchaseRTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRTable_HeadTable_AcCode",
                        column: x => x.AcCode,
                        principalTable: "HeadTable",
                        principalColumn: "LedgerMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTable",
                columns: table => new
                {
                    STId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: false),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    STVNo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    STDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OrderNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PayMode = table.Column<int>(type: "integer", nullable: false),
                    AcCode = table.Column<int>(type: "integer", nullable: false),
                    CustName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustAddress1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CustLedStateId = table.Column<int>(type: "integer", nullable: false),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CGSTTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    SGSTTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IGSTTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CessTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OtherAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OtherAmt2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NetAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CashAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DigitalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTable", x => x.STId);
                    table.ForeignKey(
                        name: "FK_PurchaseTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTable_HeadTable_AcCode",
                        column: x => x.AcCode,
                        principalTable: "HeadTable",
                        principalColumn: "LedgerMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenItemMasterDetailTable",
                columns: table => new
                {
                    OpnIMDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BatchNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CasePcs = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    FreePcs = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalPcs = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CessPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CessAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    MRP = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MRPAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    UnitCase = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    CompIdOpnItemMD = table.Column<int>(type: "integer", nullable: false),
                    UserCodeOpnItemMD = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    OpnVNoD = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    OpnIMId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenItemMasterDetailTable", x => x.OpnIMDId);
                    table.ForeignKey(
                        name: "FK_OpenItemMasterDetailTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenItemMasterDetailTable_OpenItemMasterTable_OpnIMId",
                        column: x => x.OpnIMId,
                        principalTable: "OpenItemMasterTable",
                        principalColumn: "OpnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleRDetailTable",
                columns: table => new
                {
                    SRMDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    SRItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BatchNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Qty = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalDiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CustSaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    CompIdSRItemMD = table.Column<int>(type: "integer", nullable: false),
                    UserCodeSRItemMD = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    SRVNoD = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    SRIMId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleRDetailTable", x => x.SRMDId);
                    table.ForeignKey(
                        name: "FK_SaleRDetailTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleRDetailTable_SaleRTable_SRIMId",
                        column: x => x.SRIMId,
                        principalTable: "SaleRTable",
                        principalColumn: "SRId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetailTable",
                columns: table => new
                {
                    SSMDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    SSItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BatchNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Qty = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalDiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CustSaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetTotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    CompIdSSItemMD = table.Column<int>(type: "integer", nullable: false),
                    UserCodeSSItemMD = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    SSVNoD = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    SSIMId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetailTable", x => x.SSMDId);
                    table.ForeignKey(
                        name: "FK_SaleDetailTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetailTable_SaleTable_SSIMId",
                        column: x => x.SSIMId,
                        principalTable: "SaleTable",
                        principalColumn: "SSId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDetailsMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: true),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    TestGId = table.Column<int>(type: "integer", nullable: true),
                    IPPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IPAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDetailsMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorDetailsMasterTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorDetailsMasterTable_DoctorTable_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorDetailsMasterTable_TestGroupTable_TestGId",
                        column: x => x.TestGId,
                        principalTable: "TestGroupTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestDocMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    TestCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TestGroupId = table.Column<int>(type: "integer", nullable: true),
                    documentFile = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDocMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestDocMasterTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestDocMasterTable_TestGroupTable_TestGroupId",
                        column: x => x.TestGroupId,
                        principalTable: "TestGroupTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    TestCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReportId = table.Column<int>(type: "integer", nullable: true),
                    TestGroupId = table.Column<int>(type: "integer", nullable: true),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IPPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IPAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    documentType = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ColumnsNo = table.Column<int>(type: "integer", nullable: false),
                    GraphsType = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    PPRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CCRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestMasterTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestMasterTable_ReportGroupTable_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ReportGroupTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestMasterTable_TestGroupTable_TestGroupId",
                        column: x => x.TestGroupId,
                        principalTable: "TestGroupTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResultDetailTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientValue = table.Column<string>(type: "text", nullable: true),
                    TempNo = table.Column<int>(type: "integer", nullable: true),
                    TestResultId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResultDetailTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResultDetailTable_TestResultTable_TestResultId",
                        column: x => x.TestResultId,
                        principalTable: "TestResultTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherDetailTable",
                columns: table => new
                {
                    VMDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AcCode1 = table.Column<int>(type: "integer", nullable: true),
                    VoucherPartyName = table.Column<string>(type: "text", nullable: true),
                    AcCode2 = table.Column<int>(type: "integer", nullable: true),
                    ChequeNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Dr_Amt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Cr_Amt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    RefNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PatientName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    CompIdVItemMD = table.Column<int>(type: "integer", nullable: true),
                    UserCodeVItemMD = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    VVNoD = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    VVType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    VIMId = table.Column<int>(type: "integer", nullable: false),
                    CustAcCode1 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CustAcCode2 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherDetailTable", x => x.VMDId);
                    table.ForeignKey(
                        name: "FK_VoucherDetailTable_HeadTable_AcCode1",
                        column: x => x.AcCode1,
                        principalTable: "HeadTable",
                        principalColumn: "LedgerMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherDetailTable_HeadTable_AcCode2",
                        column: x => x.AcCode2,
                        principalTable: "HeadTable",
                        principalColumn: "LedgerMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherDetailTable_VoucherTable_VIMId",
                        column: x => x.VIMId,
                        principalTable: "VoucherTable",
                        principalColumn: "VId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "MedTestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    PtId = table.Column<int>(type: "integer", nullable: true),
                    PassportNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DateOfIssue = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Nationality = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    DateOfBirth = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Trade = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    ExamDate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ExpiryDate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    VisaNoDate = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    MedRemarks = table.Column<string>(type: "text", nullable: true),
                    MedPatientType = table.Column<int>(type: "integer", nullable: true),
                    PatHeight = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    PatWeight = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    PatientMarried = table.Column<int>(type: "integer", nullable: true),
                    PatientReligion = table.Column<int>(type: "integer", nullable: true),
                    PlaceIssue = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    RecrutingAgency = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    AllergyIssue = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    OtherIssue = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedTestTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedTestTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedTestTable_PatientTable_PtId",
                        column: x => x.PtId,
                        principalTable: "PatientTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientDiscountMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestGId = table.Column<int>(type: "integer", nullable: false),
                    DiscPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PtIMId = table.Column<int>(type: "integer", nullable: false),
                    CompIdX = table.Column<int>(type: "integer", nullable: false),
                    UserCodeX = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    VNoX = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiscountMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDiscountMasterTable_PatientTable_PtIMId",
                        column: x => x.PtIMId,
                        principalTable: "PatientTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDiscountMasterTable_TestGroupTable_TestGId",
                        column: x => x.TestGId,
                        principalTable: "TestGroupTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDueReciptTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    VDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VNo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PatId = table.Column<int>(type: "integer", nullable: false),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PaidAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    PaymentType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDueReciptTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDueReciptTable_PatientTable_PatId",
                        column: x => x.PatId,
                        principalTable: "PatientTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetailTable",
                columns: table => new
                {
                    SOMDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    SSItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CasePcs = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    UnitName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    CompIdSOItemMD = table.Column<int>(type: "integer", nullable: false),
                    UserCodeSOItemMD = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    SOVNoD = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    SOIMId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetailTable", x => x.SOMDId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetailTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetailTable_PurchaseOrderTable_SOIMId",
                        column: x => x.SOIMId,
                        principalTable: "PurchaseOrderTable",
                        principalColumn: "SOId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRDetailTable",
                columns: table => new
                {
                    STMDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    STItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BatchNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CasePcs = table.Column<decimal>(type: "numeric", nullable: false),
                    OnFreeCase = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    UnitCase = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    FreePcs = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalPcs = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscPer2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscPer3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalDiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CGSTAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    SGSTAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IGSTAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    MRP = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MRPAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    CompIdSTItemMD = table.Column<int>(type: "integer", nullable: false),
                    UserCodeSTItemMD = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    STVNoD = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    STIMId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRDetailTable", x => x.STMDId);
                    table.ForeignKey(
                        name: "FK_PurchaseRDetailTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRDetailTable_PurchaseRTable_STIMId",
                        column: x => x.STIMId,
                        principalTable: "PurchaseRTable",
                        principalColumn: "STId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailTable",
                columns: table => new
                {
                    STMDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemCode = table.Column<int>(type: "integer", nullable: false),
                    STItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BatchNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CasePcs = table.Column<decimal>(type: "numeric", nullable: false),
                    OnFreeCase = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    UnitCase = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    FreePcs = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalPcs = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscPer2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscPer3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DiscAmt3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TotalDiscAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    GSTPer = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CGSTAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    SGSTAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IGSTAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    MRP = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SaleRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PurAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPurAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MRPAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    CompIdSTItemMD = table.Column<int>(type: "integer", nullable: false),
                    UserCodeSTItemMD = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    STVNoD = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    STIMId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailTable", x => x.STMDId);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailTable_ItemTable_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "ItemTable",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailTable_PurchaseTable_STIMId",
                        column: x => x.STIMId,
                        principalTable: "PurchaseTable",
                        principalColumn: "STId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDetailsMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    StanderRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IPPer1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IPAmt1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false),
                    PtIMId = table.Column<int>(type: "integer", nullable: false),
                    CompIdX = table.Column<int>(type: "integer", nullable: false),
                    UserCodeX = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    VNoX = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PrintTest = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDetailsMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDetailsMasterTable_PatientTable_PtIMId",
                        column: x => x.PtIMId,
                        principalTable: "PatientTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDetailsMasterTable_TestMasterTable_TestId",
                        column: x => x.TestId,
                        principalTable: "TestMasterTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSubMasterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestDetails = table.Column<string>(type: "text", nullable: true),
                    ColFirst = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColSecond = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColThird = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColFourth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColFifth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColSixth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VisualTrueFalse = table.Column<bool>(type: "boolean", nullable: false),
                    TestLocked = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Gender = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Units = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FromRange = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UptoRange = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    RangeSymble = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    RangeDetails = table.Column<string>(type: "text", nullable: true),
                    AgeType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    FromAge = table.Column<int>(type: "integer", nullable: false),
                    UptoAge = table.Column<int>(type: "integer", nullable: false),
                    DefaultResult = table.Column<string>(type: "text", nullable: true),
                    MiniRange = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    MaxRange = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TempNo = table.Column<int>(type: "integer", nullable: true),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    TestId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSubMasterTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSubMasterTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestSubMasterTable_TestMasterTable_TestId",
                        column: x => x.TestId,
                        principalTable: "TestMasterTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedTestDetailTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedId = table.Column<int>(type: "integer", nullable: true),
                    TestDetailsA = table.Column<string>(type: "text", nullable: true),
                    PatResultA = table.Column<string>(type: "text", nullable: true),
                    RangeDetailsA = table.Column<string>(type: "text", nullable: true),
                    TestLineA = table.Column<bool>(type: "boolean", nullable: false),
                    TestDetailsB = table.Column<string>(type: "text", nullable: true),
                    PatResultB = table.Column<string>(type: "text", nullable: true),
                    RangeDetailsB = table.Column<string>(type: "text", nullable: true),
                    TestLineB = table.Column<bool>(type: "boolean", nullable: false),
                    TempSrNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedTestDetailTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedTestDetailTable_MedTestTable_MedId",
                        column: x => x.MedId,
                        principalTable: "MedTestTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientInvestigationTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestDetails = table.Column<string>(type: "text", nullable: true),
                    ColFirst = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColSecond = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColThird = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColFourth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColFifth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ColSixth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PatResult = table.Column<string>(type: "text", nullable: true),
                    VisualTrueFalse = table.Column<bool>(type: "boolean", nullable: false),
                    TestLocked = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Gender = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Units = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FromRange = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UptoRange = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    RangeSymble = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    RangeDetails = table.Column<string>(type: "text", nullable: true),
                    FromAge = table.Column<int>(type: "integer", nullable: false),
                    UptoAge = table.Column<int>(type: "integer", nullable: false),
                    DefaultResult = table.Column<string>(type: "text", nullable: true),
                    MiniRange = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    MaxRange = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PrintTrueFalse = table.Column<bool>(type: "boolean", nullable: false),
                    TempNo = table.Column<int>(type: "integer", nullable: true),
                    CompId = table.Column<int>(type: "integer", nullable: true),
                    TestIdX = table.Column<int>(type: "integer", nullable: true),
                    TestSubId = table.Column<int>(type: "integer", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInvestigationTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientInvestigationTable_CompanyDetailTable_CompId",
                        column: x => x.CompId,
                        principalTable: "CompanyDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientInvestigationTable_PatientTable_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientInvestigationTable_TestMasterTable_TestIdX",
                        column: x => x.TestIdX,
                        principalTable: "TestMasterTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientInvestigationTable_TestSubMasterTable_TestSubId",
                        column: x => x.TestSubId,
                        principalTable: "TestSubMasterTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountConfigTable_CompId",
                table: "AccountConfigTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentFileTable_CompIdA",
                table: "AgentFileTable",
                column: "CompIdA");

            migrationBuilder.CreateIndex(
                name: "IX_AreaFileTable_CompIdA",
                table: "AreaFileTable",
                column: "CompIdA");

            migrationBuilder.CreateIndex(
                name: "IX_AreaFileTable_DistId",
                table: "AreaFileTable",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyDetailId",
                table: "AspNetUsers",
                column: "CompanyDetailId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientFileTable_CompIdA",
                table: "ClientFileTable",
                column: "CompIdA");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetailTable_DistId",
                table: "CompanyDetailTable",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetailTable_StateId",
                table: "CompanyDetailTable",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictTable_DistStateId",
                table: "DistrictTable",
                column: "DistStateId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetailsMasterTable_CompId",
                table: "DoctorDetailsMasterTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetailsMasterTable_DoctorId",
                table: "DoctorDetailsMasterTable",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetailsMasterTable_TestGId",
                table: "DoctorDetailsMasterTable",
                column: "TestGId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLabTable_CompId",
                table: "DoctorLabTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTable_CompId",
                table: "DoctorTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadTable_AcGroupId",
                table: "HeadTable",
                column: "AcGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadTable_CompId",
                table: "HeadTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadTable_LedStateId",
                table: "HeadTable",
                column: "LedStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBalanceTable_CompId",
                table: "ItemBalanceTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBalanceTable_ItemCode",
                table: "ItemBalanceTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStockTable_CompId",
                table: "ItemStockTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStockTable_ItemCode",
                table: "ItemStockTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTable_ItGPCode",
                table: "ItemTable",
                column: "ItGPCode");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTable_PackId",
                table: "ItemTable",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTable_ProdId",
                table: "ItemTable",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTable_UnitId",
                table: "ItemTable",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MedMasterTable_CompId",
                table: "MedMasterTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestDetailTable_MedId",
                table: "MedTestDetailTable",
                column: "MedId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestTable_CompId",
                table: "MedTestTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_MedTestTable_PtId",
                table: "MedTestTable",
                column: "PtId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyMasterTable_CompId",
                table: "MoneyMasterTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenItemMasterDetailTable_ItemCode",
                table: "OpenItemMasterDetailTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_OpenItemMasterDetailTable_OpnIMId",
                table: "OpenItemMasterDetailTable",
                column: "OpnIMId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenItemMasterTable_CompId",
                table: "OpenItemMasterTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSetupTable_CompId",
                table: "PageSetupTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAuditTable_CompId",
                table: "PatientAuditTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetailsMasterTable_PtIMId",
                table: "PatientDetailsMasterTable",
                column: "PtIMId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetailsMasterTable_TestId",
                table: "PatientDetailsMasterTable",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiscountMasterTable_PtIMId",
                table: "PatientDiscountMasterTable",
                column: "PtIMId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiscountMasterTable_TestGId",
                table: "PatientDiscountMasterTable",
                column: "TestGId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDueReciptTable_PatId",
                table: "PatientDueReciptTable",
                column: "PatId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigationTable_CompId",
                table: "PatientInvestigationTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigationTable_PatientId",
                table: "PatientInvestigationTable",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigationTable_TestIdX",
                table: "PatientInvestigationTable",
                column: "TestIdX");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigationTable_TestSubId",
                table: "PatientInvestigationTable",
                column: "TestSubId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTable_AgentAcCode",
                table: "PatientTable",
                column: "AgentAcCode");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTable_ClientCode",
                table: "PatientTable",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTable_CompId",
                table: "PatientTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTable_DoctorAcCode",
                table: "PatientTable",
                column: "DoctorAcCode");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTable_DrLabId",
                table: "PatientTable",
                column: "DrLabId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTable_PatientAreadCodeId",
                table: "PatientTable",
                column: "PatientAreadCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayBillTable_CompId",
                table: "PayBillTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PayBillTable_EmpId",
                table: "PayBillTable",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailTable_ItemCode",
                table: "PurchaseDetailTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailTable_STIMId",
                table: "PurchaseDetailTable",
                column: "STIMId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetailTable_ItemCode",
                table: "PurchaseOrderDetailTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetailTable_SOIMId",
                table: "PurchaseOrderDetailTable",
                column: "SOIMId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTable_AcCode",
                table: "PurchaseOrderTable",
                column: "AcCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTable_CompId",
                table: "PurchaseOrderTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRDetailTable_ItemCode",
                table: "PurchaseRDetailTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRDetailTable_STIMId",
                table: "PurchaseRDetailTable",
                column: "STIMId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRTable_AcCode",
                table: "PurchaseRTable",
                column: "AcCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRTable_CompId",
                table: "PurchaseRTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTable_AcCode",
                table: "PurchaseTable",
                column: "AcCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTable_CompId",
                table: "PurchaseTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportGroupTable_CompId",
                table: "ReportGroupTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailTable_ItemCode",
                table: "SaleDetailTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailTable_SSIMId",
                table: "SaleDetailTable",
                column: "SSIMId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRDetailTable_ItemCode",
                table: "SaleRDetailTable",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRDetailTable_SRIMId",
                table: "SaleRDetailTable",
                column: "SRIMId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRTable_CompId",
                table: "SaleRTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTable_CompId",
                table: "SaleTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSFileTable_CompId",
                table: "SMSFileTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSKeyTable_CompId",
                table: "SMSKeyTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDocMasterTable_CompId",
                table: "TestDocMasterTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDocMasterTable_TestGroupId",
                table: "TestDocMasterTable",
                column: "TestGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TestGroupTable_CompId",
                table: "TestGroupTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_TestMasterTable_CompId",
                table: "TestMasterTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_TestMasterTable_ReportId",
                table: "TestMasterTable",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TestMasterTable_TestGroupId",
                table: "TestMasterTable",
                column: "TestGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResultDetailTable_TestResultId",
                table: "TestResultDetailTable",
                column: "TestResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResultTable_CompId",
                table: "TestResultTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubMasterTable_CompId",
                table: "TestSubMasterTable",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubMasterTable_TestId",
                table: "TestSubMasterTable",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMeasurementTable_UQCId",
                table: "UnitMeasurementTable",
                column: "UQCId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetailTable_AcCode1",
                table: "VoucherDetailTable",
                column: "AcCode1");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetailTable_AcCode2",
                table: "VoucherDetailTable",
                column: "AcCode2");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetailTable_VIMId",
                table: "VoucherDetailTable",
                column: "VIMId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherTable_CompId",
                table: "VoucherTable",
                column: "CompId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountConfigTable");

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
                name: "CheckMessageSendTable");

            migrationBuilder.DropTable(
                name: "DoctorDetailsMasterTable");

            migrationBuilder.DropTable(
                name: "FontCustomTable");

            migrationBuilder.DropTable(
                name: "ItemBalanceTable");

            migrationBuilder.DropTable(
                name: "ItemStockTable");

            migrationBuilder.DropTable(
                name: "MedMasterTable");

            migrationBuilder.DropTable(
                name: "MedTestDetailTable");

            migrationBuilder.DropTable(
                name: "MoneyMasterTable");

            migrationBuilder.DropTable(
                name: "OpenItemMasterDetailTable");

            migrationBuilder.DropTable(
                name: "PageSetupTable");

            migrationBuilder.DropTable(
                name: "PatientAuditTable");

            migrationBuilder.DropTable(
                name: "PatientDetailsMasterTable");

            migrationBuilder.DropTable(
                name: "PatientDiscountMasterTable");

            migrationBuilder.DropTable(
                name: "PatientDueReciptTable");

            migrationBuilder.DropTable(
                name: "PatientIITable");

            migrationBuilder.DropTable(
                name: "PatientInvestigationTable");

            migrationBuilder.DropTable(
                name: "PayBillTable");

            migrationBuilder.DropTable(
                name: "PurchaseDetailTable");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetailTable");

            migrationBuilder.DropTable(
                name: "PurchaseRDetailTable");

            migrationBuilder.DropTable(
                name: "SaleDetailTable");

            migrationBuilder.DropTable(
                name: "SaleRDetailTable");

            migrationBuilder.DropTable(
                name: "SMSFileTable");

            migrationBuilder.DropTable(
                name: "SMSKeyTable");

            migrationBuilder.DropTable(
                name: "TestDocMasterTable");

            migrationBuilder.DropTable(
                name: "TestResultDetailTable");

            migrationBuilder.DropTable(
                name: "TitlesTable");

            migrationBuilder.DropTable(
                name: "UploadPhotoFrontTable");

            migrationBuilder.DropTable(
                name: "VoucherDetailTable");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DoctorTable");

            migrationBuilder.DropTable(
                name: "MedTestTable");

            migrationBuilder.DropTable(
                name: "OpenItemMasterTable");

            migrationBuilder.DropTable(
                name: "TestSubMasterTable");

            migrationBuilder.DropTable(
                name: "PurchaseTable");

            migrationBuilder.DropTable(
                name: "PurchaseOrderTable");

            migrationBuilder.DropTable(
                name: "PurchaseRTable");

            migrationBuilder.DropTable(
                name: "SaleTable");

            migrationBuilder.DropTable(
                name: "ItemTable");

            migrationBuilder.DropTable(
                name: "SaleRTable");

            migrationBuilder.DropTable(
                name: "TestResultTable");

            migrationBuilder.DropTable(
                name: "VoucherTable");

            migrationBuilder.DropTable(
                name: "PatientTable");

            migrationBuilder.DropTable(
                name: "TestMasterTable");

            migrationBuilder.DropTable(
                name: "ItemGroupTable");

            migrationBuilder.DropTable(
                name: "PackingTable");

            migrationBuilder.DropTable(
                name: "ProductCompanyTable");

            migrationBuilder.DropTable(
                name: "UnitMeasurementTable");

            migrationBuilder.DropTable(
                name: "AgentFileTable");

            migrationBuilder.DropTable(
                name: "AreaFileTable");

            migrationBuilder.DropTable(
                name: "ClientFileTable");

            migrationBuilder.DropTable(
                name: "DoctorLabTable");

            migrationBuilder.DropTable(
                name: "HeadTable");

            migrationBuilder.DropTable(
                name: "ReportGroupTable");

            migrationBuilder.DropTable(
                name: "TestGroupTable");

            migrationBuilder.DropTable(
                name: "UQCMasterTable");

            migrationBuilder.DropTable(
                name: "HeadGroupTable");

            migrationBuilder.DropTable(
                name: "CompanyDetailTable");

            migrationBuilder.DropTable(
                name: "DistrictTable");

            migrationBuilder.DropTable(
                name: "StateTable");
        }
    }
}
