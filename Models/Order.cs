using System;
using System.Collections.Generic;

namespace demo_hard.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? OrderCode { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public int? CodeClient { get; set; }

    public string? ServiceId { get; set; }

    public string? Status { get; set; }

    public DateOnly? DateClose { get; set; }

    public int? RentalTime { get; set; }
}
