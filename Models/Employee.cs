using System;
using System.Collections.Generic;

namespace demo_hard.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Role { get; set; } = null!;

    public string Fio { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? LastEnter { get; set; }

    public string? TypeEnter { get; set; }

    public string? Photo { get; set; }
}
