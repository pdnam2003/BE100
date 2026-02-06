using BE100.Data;
using BE100.Data.Seed;
using BEProject4.DependencyInjection;

namespace BEProject4
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ================= SERVICES =================
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddDatabase(builder.Configuration)
                .AddApplicationServices()
                .AddJwtAuthentication(builder.Configuration);

            // ================= CORS =================
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // ================= SEED DATA =================
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                SeedData.Initialize(context);
            }

            // ================= SWAGGER (ENABLE PROD) =================
            app.UseSwagger();
            app.UseSwaggerUI();

            // ================= MIDDLEWARE =================
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAll");

            app.MapControllers();

            // ================= PORT (BẮT BUỘC KHI DEPLOY) =================
            var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
            app.Run($"http://0.0.0.0:{port}");
        }
    }
}
