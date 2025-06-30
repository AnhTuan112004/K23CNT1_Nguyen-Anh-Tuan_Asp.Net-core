using System;
using System.Collections.Generic;

namespace NguyenAnhTuan_2310900113.Models;

public partial class NatEmployee
{
    public int NatEmpId { get; set; }

    public string? NatEmpName { get; set; }

    public string? NatEmpLevel { get; set; }

    public DateOnly? NatEmpStartDate { get; set; }

    public bool? NatEmpStatus { get; set; }
}
