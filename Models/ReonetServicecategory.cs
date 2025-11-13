using System;
using System.Collections.Generic;

namespace ReoNet.Api.Models;

public partial class ReonetServicecategory
{
    public int Srl { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? Createdate { get; set; }

    public int? Createuser { get; set; }

    public int? Code { get; set; }
}
