using BE100.Services;
using BE100.Services.ExamService;
using BE100.Services.Question;
using Microsoft.Extensions.DependencyInjection;

namespace BEProject4.DependencyInjection
{
    //service moi o day dang ky moi co the dung
    public static class ServiceDependency
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddScoped<AuthService>();
            services.AddScoped<TokenService>();


            services.AddScoped<RandoomExam>();            
            services.AddScoped<GetAllQuestion>();
            services.AddScoped<ListQuestionDangerous>();
            services.AddScoped<ExambyQuestionCategory>();



            return services;
        }
    }
}
