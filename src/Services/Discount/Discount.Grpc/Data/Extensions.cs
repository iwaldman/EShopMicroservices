﻿using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public static class Extensions
{
    public static async Task<IApplicationBuilder> UseMigration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<DiscountContext>();
        await context.Database.MigrateAsync();
        return app;
    }
}
