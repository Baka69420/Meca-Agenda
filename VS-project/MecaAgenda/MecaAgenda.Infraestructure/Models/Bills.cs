using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Bills
{
    public int BillId { get; set; }

    public int? AppointmentId { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? PaidAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual Appointments? Appointment { get; set; }

    public virtual ICollection<BillItems> BillItems { get; set; } = new List<BillItems>();
}
