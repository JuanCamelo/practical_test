using System;
using System.Collections.Generic;

namespace POO.Infraestructure.Entities;

public partial class AccountTransfer
{
    public Guid Id { get; set; }

    public double Amount { get; set; }

    public DateTime DateTransfer { get; set; }

    public Guid AccountId { get; set; }

    public string Status { get; set; } = null!;

    public virtual BankAccount Account { get; set; } = null!;
}
