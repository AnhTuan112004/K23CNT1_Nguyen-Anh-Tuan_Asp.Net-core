using Microsoft.EntityFrameworkCore;
using NguyenAnhTuan_2310900113.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Đảm bảo đúng tên connection string và DbContext
        var connectionString = builder.Configuration.GetConnectionString("NguyenAnhTuan_2310900113");
        builder.Services.AddDbContext<NguyenAnhTuan2310900113Context>(x => x.UseSqlServer(connectionString));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/NatHome/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=NatHome}/{action=NatIndex}/{natid?}");

        app.Run();
    }
}
