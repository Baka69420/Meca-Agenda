﻿using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Bills
{
    public int BillId { get; set; }

    public int ClientId { get; set; }

    public int BranchId { get; set; }

    public DateOnly Date { get; set; }

    public decimal TotalAmount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public bool Paid { get; set; }

    public virtual ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();

    public virtual ICollection<BillItems> BillItems { get; set; } = new List<BillItems>();

    public virtual Branches Branch { get; set; } = null!;

    public virtual Users Client { get; set; } = null!;
}
