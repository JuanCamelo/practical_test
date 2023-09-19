using POO.Domain.Interfaces;


namespace POO.Infraestructure.Interfaces
{
    public interface IUnitOfWork 
    {
        Task<int> SaveChangesAsync();
    }
}
