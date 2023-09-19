namespace POO.Infraestructure.Entities;

public partial class AccountWithdrawal
{
    public Guid Id { get; set; }

    public double Amount { get; set; }

    public DateTime RetirementDate { get; set; }

    public Guid AccountId { get; set; }

    public virtual BankAccount Account { get; set; } = null!;
}
