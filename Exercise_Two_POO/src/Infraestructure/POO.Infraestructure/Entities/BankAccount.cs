using System;
using System.Collections.Generic;

namespace POO.Infraestructure.Entities;

public partial class BankAccount
{
    public Guid Id { get; set; }

    public string TypeAccount { get; set; }

    public double Balance { get; set; }

    public DateTime OpeningDate { get; set; }

    public Guid ClientId { get; set; }

    public virtual ICollection<AccountTransfer> AccountTransfers { get; set; } = new List<AccountTransfer>();

    public virtual ICollection<AccountWithdrawal> AccountWithdrawals { get; set; } = new List<AccountWithdrawal>();

    public virtual Client Client { get; set; } = null!;
}
