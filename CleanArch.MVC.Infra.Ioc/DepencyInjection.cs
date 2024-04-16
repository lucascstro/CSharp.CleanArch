using CleanArch.MVC.Application.Interfaces;
using CleanArch.MVC.Application.Mappings;
using CleanArch.MVC.Application.Services;
using CleanArch.MVC.Domain.Account;
using CleanArch.MVC.Domain.Interfaces;
using CleanArch.MVC.Infra.Data.Context;
using CleanArch.MVC.Infra.Data.Identity;
using CleanArch.MVC.Infra.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArch.MVC.Infra.Ioc
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //necessário injetar a dependencia para o funcionamento do identity corretamente.
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); // adicionado para fazer o gerenciamento de tokens para ações do usuario(recuperação de senha, alteração de email, alteração de dados pessoas e auth 2 fatores)

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IProductServices, ProductServices>();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("CleanArch.MVC.Application")));

            return services;
        }
    }
}