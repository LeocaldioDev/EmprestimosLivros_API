using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Application.Mappings;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EmprestimoLivros.Domain.Account;
using EmprestimoLivros.Infra.Data.Identity;

namespace EmprestimoLivros.Infra.IOC
{
   public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDBContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName));
            });

            services.AddAuthentication(opt =>
            {

                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            }

            ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:secretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };


                });

            //AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            //repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository,ClienteRepository>();
            services.AddScoped<ILivroRepository,LivroRepository>();
            services.AddScoped<IEmprestimoRepository,EmprestimoRepository>();
            services.AddScoped<ISistemaRepository,SistemaRepository>();
            

            //Services
            services.AddScoped<ICLienteServices, ClienteServices>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IAuthenticate, AuthenticateServices>();
            services.AddScoped<ILivroServices, LivroServices>();
            services.AddScoped<IEmprestimoServices, EmprestimoServices>();
            services.AddScoped<ISistemaServices, SistemaServices>();



            return services;
        }

    }
}
