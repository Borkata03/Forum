using Forum.Core.Contracts;
using Forum.Core.Services;
using Forum.Data;
using Forum.Infrastructure.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace Forum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            var connectionString = builder.Configuration.GetConnectionString("ForumDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ForumDbContextConnection' not found.");
            builder.Services.AddDbContext<ForumDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<IRepository, Repository>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IThreadService, ThreadService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddSingleton<PredictionEngine<CommentData, CommentPrediction>>(sp =>
            {
                var mlContext = new MLContext();
                var modelPath = @"C:\Users\bvasi\source\repos\Forum\model.zip";
                var mlModel = mlContext.Model.Load(modelPath, out var schema);
                return mlContext.Model.CreatePredictionEngine<CommentData, CommentPrediction>(mlModel);
            });




            builder.Services.AddDefaultIdentity<IdentityUser>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ForumDbContext>();
            builder.Services.AddControllersWithViews();




            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();


        }
    }
}
