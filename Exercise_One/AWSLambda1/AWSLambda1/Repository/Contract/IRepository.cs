namespace AWSLambda1.Repository.Contract
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetInformacionProyectosDepartamento<T>() where T : class;
    }
}
