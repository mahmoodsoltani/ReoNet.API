using System;
using System.Collections.Generic;

namespace ReoNet.Api.Models;

public partial class SecSetting
{
    public int Srl { get; set; }

    public int? SrlSecFrom { get; set; }

    public int? SrlSecGroups { get; set; }

    public int? SrlSecUsers { get; set; }

    public string? ObjectName { get; set; }

    public string? ObjectType { get; set; }

    public string? PropName { get; set; }

    public string? PropValue { get; set; }

    public string? Dis { get; set; }

    public bool? Visible { get; set; }

    public bool? Active { get; set; }

    public int? SrlSherkatName { get; set; }

    public string? SubmitDate { get; set; }

    public int? SrlSubmitUser { get; set; }
}
