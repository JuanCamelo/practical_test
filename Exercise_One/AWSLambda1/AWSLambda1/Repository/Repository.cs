using AWSLambda1.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using POO.Infraestructure.Context;

namespace AWSLambda1.Repository
{
    public class Repository : IRepository
    {
        public async Task<IEnumerable<T>> GetInformacionProyectosDepartamento<T>() where T : class
        {
            var connectionString = "Server=database.clfyixnbaq8f.us-east-1.rds.amazonaws.com,1433;Database=Application;User=adminj;Password=Pruebas1; TrustServerCertificate=True";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var _dbContext = new ApplicationContext(optionsBuilder.Options))
            {
                IQueryable<T> query = _dbContext.Set<T>().AsNoTracking();

                return await query.ToListAsync();
            }
        }

    }
}
