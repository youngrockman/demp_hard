using System;
using System.Collections.Generic;

namespace demo_hard.Models;

public partial class Service
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string ServiceCode { get; set; } = null!;

    public int ServiceCost { get; set; }
}
