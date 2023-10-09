using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Infrastructure.Persistence.Context;
using GestorDePacientes.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorDePacientes.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>),typeof(GenericRepositoryAsync<>));
            services.AddTransient<IUserRepository, UserRepositoryAsync>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IPatientReposity, PatientRepository>();

            #endregion
        }
    }
}