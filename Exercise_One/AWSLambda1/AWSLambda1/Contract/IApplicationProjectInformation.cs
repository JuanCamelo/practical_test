namespace AWSLambda1.Contract
{
    public interface IApplicationProjectInformation
    {
        Task<object> GetProjectInformation(string options);
    }
}
