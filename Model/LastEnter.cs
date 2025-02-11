using System;
using System.Collections.Generic;

namespace demo_hard.Model;

public partial class LastEnter
{
    public int EmployeId { get; set; }

    public DateTime EnterDatetime { get; set; }

    public string EnterType { get; set; } = null!;

    public string? Login { get; set; }
}
