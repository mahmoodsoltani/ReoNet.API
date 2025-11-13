using System;
using System.Collections.Generic;

namespace ReoNet.Api.Models;

public partial class ReonetSubservice
{
    public int Srl { get; set; }

    public int? Code { get; set; }

    public string? Title { get; set; }

    public int? SrlService { get; set; }

    public int? SrlServicetype { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public DateTime? Createdate { get; set; }

    public int? Createuser { get; set; }
}
