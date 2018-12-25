using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.DAL.Migrations
{
    public partial class database_initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cpms");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    ZIP = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    ManHour = table.Column<decimal>(nullable: false),
                    Time = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false),
                    StarDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BillingInfos",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    ICO = table.Column<string>(nullable: false),
                    DIC = table.Column<string>(nullable: false),
                    IBAN = table.Column<string>(maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillingInfos_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalSchema: "cpms",
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    TaskID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    Close = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Times_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalSchema: "cpms",
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Point = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    StarDate = table.Column<DateTime>(nullable: false),
                    CloseDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "cpms",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BillingInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_BillingInfos_BillingInfoID",
                        column: x => x.BillingInfoID,
                        principalSchema: "cpms",
                        principalTable: "BillingInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "cpms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    DeveloperID = table.Column<int>(nullable: false),
                    TaskID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalSchema: "cpms",
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfos_AddressID",
                schema: "cpms",
                table: "BillingInfos",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskID",
                schema: "cpms",
                table: "Comments",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillingInfoID",
                schema: "cpms",
                table: "Customers",
                column: "BillingInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectID",
                schema: "cpms",
                table: "Tasks",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Times_InvoiceID",
                schema: "cpms",
                table: "Times",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "Developers",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "Times",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "BillingInfos",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "cpms");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "cpms");
        }
    }
}
