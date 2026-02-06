using BE100.Data;
using BE100.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace BEProject4.DependencyInjection
{
    public static class DatabaseDependency
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

            dataSourceBuilder.MapEnum<QuestionType>("question_type");
            dataSourceBuilder.MapEnum<ExamStatus>("exam_status");
            dataSourceBuilder.MapEnum<ExamResult>("exam_result");
            dataSourceBuilder.MapEnum<Role>("role");

            var dataSource = dataSourceBuilder.Build();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(dataSource)
                       .LogTo(Console.WriteLine, LogLevel.Information);
            });

            return services;
        }
    }
}
