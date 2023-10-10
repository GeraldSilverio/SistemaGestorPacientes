using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GestorDePacientes.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDoctorServices, DoctorService>();
            #endregion
        }
    }
}