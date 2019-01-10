using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.DAL.Migrations
{
    public partial class init_repair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pms");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BillingInfos",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        principalSchema: "pms",
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        principalSchema: "pms",
                        principalTable: "BillingInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    ManHour = table.Column<decimal>(nullable: false),
                    Time = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "pms",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    StarDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "pms",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
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
                        principalSchema: "pms",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    DeveloperID = table.Column<int>(nullable: false),
                    TaskID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Developers_DeveloperID",
                        column: x => x.DeveloperID,
                        principalSchema: "pms",
                        principalTable: "Developers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalSchema: "pms",
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                schema: "pms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskID = table.Column<int>(nullable: false),
                    DeveloperID = table.Column<int>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    Close = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Times_Developers_DeveloperID",
                        column: x => x.DeveloperID,
                        principalSchema: "pms",
                        principalTable: "Developers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Times_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalSchema: "pms",
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Times_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalSchema: "pms",
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfos_AddressID",
                schema: "pms",
                table: "BillingInfos",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DeveloperID",
                schema: "pms",
                table: "Comments",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskID",
                schema: "pms",
                table: "Comments",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillingInfoID",
                schema: "pms",
                table: "Customers",
                column: "BillingInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerID",
                schema: "pms",
                table: "Invoices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerID",
                schema: "pms",
                table: "Projects",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectID",
                schema: "pms",
                table: "Tasks",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Times_DeveloperID",
                schema: "pms",
                table: "Times",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_Times_InvoiceID",
                schema: "pms",
                table: "Times",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Times_TaskID",
                schema: "pms",
                table: "Times",
                column: "TaskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Times",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Developers",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "BillingInfos",
                schema: "pms");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "pms");
        }
    }
}
