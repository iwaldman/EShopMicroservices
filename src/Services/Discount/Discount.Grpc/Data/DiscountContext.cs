namespace Discount.Grpc.Data;

public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed the database with sample data
        modelBuilder
            .Entity<Coupon>()
            .HasData(
                new Coupon
                {
                    Id = 1,
                    ProductName = "IPhone X",
                    Description = "IPhone Discount",
                    Amount = 150
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "Samsung 10",
                    Description = "Samsung Discount",
                    Amount = 100
                },
                new Coupon
                {
                    Id = 3,
                    ProductName = "Huawei P30",
                    Description = "Huawei Discount",
                    Amount = 50
                },
                new Coupon
                {
                    Id = 4,
                    ProductName = "Xiaomi Mi 10",
                    Description = "Xiaomi Discount",
                    Amount = 20
                },
                new Coupon
                {
                    Id = 5,
                    ProductName = "LG G8",
                    Description = "LG Discount",
                    Amount = 30
                },
                new Coupon
                {
                    Id = 6,
                    ProductName = "Sony Xperia 1",
                    Description = "Sony Discount",
                    Amount = 80
                },
                new Coupon
                {
                    Id = 7,
                    ProductName = "One Plus 7T",
                    Description = "One Plus Discount",
                    Amount = 75
                },
                new Coupon
                {
                    Id = 8,
                    ProductName = "Google Pixel 4",
                    Description = "Google Discount",
                    Amount = 60
                },
                new Coupon
                {
                    Id = 9,
                    ProductName = "Oppo Reno",
                    Description = "Oppo Discount",
                    Amount = 200
                },
                new Coupon
                {
                    Id = 10,
                    ProductName = "Vivo Nex 3",
                    Description = "Vivo Discount",
                    Amount = 95
                },
                new Coupon
                {
                    Id = 11,
                    ProductName = "Honor 20",
                    Description = "Honor Discount",
                    Amount = 150
                },
                new Coupon
                {
                    Id = 12,
                    ProductName = "Nokia 9",
                    Description = "Nokia Discount",
                    Amount = 100
                },
                new Coupon
                {
                    Id = 13,
                    ProductName = "Blackberry Key 2",
                    Description = "Blackberry Discount",
                    Amount = 50
                },
                new Coupon
                {
                    Id = 14,
                    ProductName = "HTC U12+",
                    Description = "HTC Discount",
                    Amount = 20
                },
                new Coupon
                {
                    Id = 15,
                    ProductName = "Asus Zenfone 6",
                    Description = "Asus Discount",
                    Amount = 30
                },
                new Coupon
                {
                    Id = 16,
                    ProductName = "ZTE Nubia Red Magic",
                    Description = "ZTE Discount",
                    Amount = 80
                },
                new Coupon
                {
                    Id = 17,
                    ProductName = "Sharp Aquos R2",
                    Description = "Sharp Discount",
                    Amount = 75
                },
                new Coupon
                {
                    Id = 18,
                    ProductName = "Lenovo Z6 Pro",
                    Description = "Lenovo Discount",
                    Amount = 60
                },
                new Coupon
                {
                    Id = 19,
                    ProductName = "Panasonic Eluga X1 Pro",
                    Description = "Panasonic Discount",
                    Amount = 200
                },
                new Coupon
                {
                    Id = 20,
                    ProductName = "Cat S61",
                    Description = "Cat Discount",
                    Amount = 95
                }
            );
    }
}
