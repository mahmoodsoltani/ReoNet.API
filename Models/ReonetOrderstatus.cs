using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReoNet.Api.Models;
[Table ("reonet_orderstatus")]
public partial class ReonetOrderStatus
{
    [Key]
    public int Srl { get; set; }

    public string? Title { get; set; }

    public int? Code { get; set; }

    [Column("srl_servicecategory")]
    public int? SrlServicecategory { get; set; }
}
