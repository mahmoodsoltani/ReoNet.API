using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReoNet.Api.Models;

[Table("reonet_service")]

public partial class ReonetService
{
    [Key]
    public int Srl { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    [Column("srl_parent")]
    public int? SrlParent { get; set; }

    public double? Price { get; set; }

    public bool? Isactive { get; set; }

    public string? Description { get; set; }

    [Column("srl_unit")]
    public int? SrlUnit { get; set; }

    [Column("is_service")]
    public bool? IsService { get; set; }

    [Column("srl_servicecategory")]
    public int? SrlServicecategory { get; set; }
}
