using System;
using System.Collections.Generic;

namespace ReoNet.Api.Models;

public partial class SecGroup
{
    public int Srl { get; set; }

    public string? GroupName { get; set; }

    public bool? UsersBlocked { get; set; }

    public bool? JoinBlocked { get; set; }
}
