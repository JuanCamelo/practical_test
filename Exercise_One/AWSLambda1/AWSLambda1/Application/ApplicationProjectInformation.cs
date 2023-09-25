using AWSLambda1.Contract;
using AWSLambda1.Repository.Contract;
using POO.Infraestructure.Entities;

namespace AWSLambda1.Application
{
    public class ApplicationProjectInformation : IApplicationProjectInformation
    {
        private readonly IRepository _repository;

        public ApplicationProjectInformation(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> GetProjectInformation(string options)
        {
            try
            {
                if (options == "informacionProyectosDepartamento")
                { 
                    return await _repository.GetInformacionProyectosDepartamento<VistaInformacionProyectosDepartamento>();
                };

                if (options == "cantidadProyectosDepartamento")
                { 
                    return await _repository.GetInformacionProyectosDepartamento<VistaCantidadProyectosDepartamento>();
                };

                if (options == "departamentosProyecto")
                { 
                    return await _repository.GetInformacionProyectosDepartamento<VistaDepartamentosProyecto>(); 
                };

                if (options == "empleadoAsignadosProyecto")
                { 
                    return await _repository.GetInformacionProyectosDepartamento<VistaEmpleadoAsignadosProyecto>();
                };
                return new object();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
