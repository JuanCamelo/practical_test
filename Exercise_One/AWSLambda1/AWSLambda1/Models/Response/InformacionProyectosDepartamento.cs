namespace AWSLambda1.Models.Response
{
    public class InformacionProyectosDepartamento : BaseModel
    {
        public string Project { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public decimal Budget { get; set; } 
    }
}
