using System;
using System.Collections.Generic;

namespace POO.Infraestructure.Entities;

public partial class Client
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public bool? Status { get; set; }
    public int DocumentNumber { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime Update { get; set; }

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
}
