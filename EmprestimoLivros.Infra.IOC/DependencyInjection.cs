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
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            //repositories
            services.AddScoped<IClienteRepository,ClienteRepository>();

            //Services
            services.AddScoped<ICLienteServices, ClienteServices>();




            return services;
        }

    }
}
