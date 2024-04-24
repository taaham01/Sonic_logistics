using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sonic_logistics.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PO",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    cus_id = table.Column<int>(type: "int", nullable: false),
                    Sup_id = table.Column<int>(type: "int", nullable: false),
                    prod_ID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    order_datetime = table.Column<DateTime>(name: "order_date/time", type: "datetime", nullable: false),
                    shipped_date = table.Column<DateOnly>(type: "date", nullable: false),
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PO", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    prod_ID = table.Column<int>(type: "int", nullable: false),
                    Sup_id = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UOM = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Product_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.prod_ID);
                });

            migrationBuilder.CreateTable(
                name: "RFQ",
                columns: table => new
                {
                    rfq_id = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    operational_unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Shipping_address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    buyer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    currency = table.Column<int>(type: "int", nullable: false),
                    prod_ID = table.Column<int>(type: "int", nullable: false),
                    product_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UOM = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Item_discription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    price_per_unit = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQ", x => x.rfq_id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Sup_id = table.Column<int>(type: "int", nullable: false),
                    Supplier_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Website = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Sup_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PO");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RFQ");

            migrationBuilder.DropTable(
                name: "Supplier");


        }
    }
}
