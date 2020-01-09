using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CostRegisterMobile.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryID = table.Column<int>(nullable: false),
                    ShopID = table.Column<int>(nullable: false),
                    AmountOfCost = table.Column<int>(nullable: false),
                    DateOfCost = table.Column<DateTime>(nullable: false),
                    AdditionalInformation = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostID);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    IncomeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeOfIncome = table.Column<string>(maxLength: 100, nullable: false),
                    AmountOfIncome = table.Column<int>(nullable: false),
                    DateOFIncome = table.Column<DateTime>(nullable: false),
                    IncomeAdditionalInformation = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.IncomeID);
                });

            migrationBuilder.CreateTable(
                name: "PlanCosts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeOfCostPlan = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    CostPlanned = table.Column<int>(nullable: false),
                    DateOfPlan = table.Column<DateTime>(nullable: false),
                    PlanAdditionalInformation = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCosts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SettingType = table.Column<string>(nullable: true),
                    SettingMode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShopName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopID);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Rezsi" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 9, "Extra" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 8, "Háztartási gépek és karbantartás" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 7, "Egészségügyi" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 6, "Hobbik" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 10, "Egyéb" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Ruházat" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Háztartás és élelmiszer" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Lakbér" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Sport" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "ID", "SettingMode", "SettingType" },
                values: new object[] { 1, 1, "IncludePlans" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 11, "IKEA" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 18, "New Yorker" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 17, "Bershka" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 16, "Fressnapf" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 15, "Rossmann" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 14, "DM" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 13, "Praktiker" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 12, "KIKA" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 10, "Obi" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 5, "Tesco" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 8, "COOP" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 7, "CBA" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 6, "Auchan" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 19, "C&A" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 4, "Reál" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 3, "Penny Market" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 2, "Aldi" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 1, "Lidl" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 9, "Decathlon" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopID", "ShopName" },
                values: new object[] { 20, "Egyéb/nem üzlet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "PlanCosts");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
