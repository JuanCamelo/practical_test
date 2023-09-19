using POO.Application.Helpers;

namespace POO.Application.DTOs.Request
{
    public class ModelAccountClient
    {
        public string Client { get; set; }
        public string Document { get; set; }
        public string TypeAccount { get; set; }
        public double Balance { get; set; }
    }
}
