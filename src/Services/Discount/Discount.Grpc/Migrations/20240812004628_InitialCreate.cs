using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.Grpc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[,]
                {
                    { 1, 150, "IPhone Discount", "IPhone X" },
                    { 2, 100, "Samsung Discount", "Samsung 10" },
                    { 3, 50, "Huawei Discount", "Huawei P30" },
                    { 4, 20, "Xiaomi Discount", "Xiaomi Mi 10" },
                    { 5, 30, "LG Discount", "LG G8" },
                    { 6, 80, "Sony Discount", "Sony Xperia 1" },
                    { 7, 75, "One Plus Discount", "One Plus 7T" },
                    { 8, 60, "Google Discount", "Google Pixel 4" },
                    { 9, 200, "Oppo Discount", "Oppo Reno" },
                    { 10, 95, "Vivo Discount", "Vivo Nex 3" },
                    { 11, 150, "Honor Discount", "Honor 20" },
                    { 12, 100, "Nokia Discount", "Nokia 9" },
                    { 13, 50, "Blackberry Discount", "Blackberry Key 2" },
                    { 14, 20, "HTC Discount", "HTC U12+" },
                    { 15, 30, "Asus Discount", "Asus Zenfone 6" },
                    { 16, 80, "ZTE Discount", "ZTE Nubia Red Magic" },
                    { 17, 75, "Sharp Discount", "Sharp Aquos R2" },
                    { 18, 60, "Lenovo Discount", "Lenovo Z6 Pro" },
                    { 19, 200, "Panasonic Discount", "Panasonic Eluga X1 Pro" },
                    { 20, 95, "Cat Discount", "Cat S61" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
