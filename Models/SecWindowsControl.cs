using System;
using System.Collections.Generic;

namespace ReoNet.Api.Models;

public partial class SecWindowsControl
{
    public int Srl { get; set; }

    public string? ControlName { get; set; }

    public bool? Disable { get; set; }

    public bool? Invisible { get; set; }

    public string? Type { get; set; }

    public string? FormName { get; set; }

    public int? SrlRole { get; set; }
}
