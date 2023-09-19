namespace POO.Application.DTOs.Response
{
    public class ViewHistoryMovements
    {
        public string DateTransfer { get; set; }
        public string DateRetirement { get; set; }
        public double? Ammount { get; set; }
        public double? BeginningBalance { get; set; }
        public double? EndingBalance { get; set; }
    }
}
