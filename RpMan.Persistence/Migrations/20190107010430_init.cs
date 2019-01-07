using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpMan.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 8, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 60, nullable: true),
                    Middlenames = table.Column<string>(maxLength: 60, nullable: true),
                    Lastname = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 8, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 60, nullable: true),
                    Middlenames = table.Column<string>(maxLength: 60, nullable: true),
                    Lastname = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenancyAgreements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    FixedTermEndDate = table.Column<DateTime>(nullable: false),
                    RentAmount = table.Column<decimal>(nullable: false),
                    RentPeriod = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenancyAgreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenancyAgreements_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandlordsTenancyAgreements",
                columns: table => new
                {
                    LandlordId = table.Column<int>(nullable: false),
                    TenancyAgreementId = table.Column<int>(nullable: false),
                    Dummy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandlordsTenancyAgreements", x => new { x.TenancyAgreementId, x.LandlordId });
                    table.ForeignKey(
                        name: "FK_LandlordsTenancyAgreements_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandlordsTenancyAgreements_TenancyAgreements_TenancyAgreementId",
                        column: x => x.TenancyAgreementId,
                        principalTable: "TenancyAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantsTenancyAgreements",
                columns: table => new
                {
                    TenantId = table.Column<int>(nullable: false),
                    TenancyAgreementId = table.Column<int>(nullable: false),
                    Dummy = table.Column<string>(type: "char", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantsTenancyAgreements", x => new { x.TenancyAgreementId, x.TenantId });
                    table.ForeignKey(
                        name: "FK_TenantsTenancyAgreements_TenancyAgreements_TenancyAgreementId",
                        column: x => x.TenancyAgreementId,
                        principalTable: "TenancyAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantsTenancyAgreements_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LandlordsTenancyAgreements_LandlordId",
                table: "LandlordsTenancyAgreements",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_TenancyAgreements_PropertyId",
                table: "TenancyAgreements",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantsTenancyAgreements_TenantId",
                table: "TenantsTenancyAgreements",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandlordsTenancyAgreements");

            migrationBuilder.DropTable(
                name: "TenantsTenancyAgreements");

            migrationBuilder.DropTable(
                name: "Landlords");

            migrationBuilder.DropTable(
                name: "TenancyAgreements");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
