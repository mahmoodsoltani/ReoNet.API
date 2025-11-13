using System;
using System.Collections.Generic;

namespace ReoNet.Api.Models;

public partial class ReonetPostcode
{
    public int Srl { get; set; }

    public string? Code { get; set; }

    public int? SrlCity { get; set; }
}
