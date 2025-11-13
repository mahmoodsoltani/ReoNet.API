using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReoNet.Api.Models;

[Table("reonet_orderdetail")]

public partial class ReonetOrderDetail
{
    [Key] 
    [Column("srl")]
    public int Srl { get; set; }

    public string? Barcode { get; set; }

    [Column("srl_subservice")]
    public int? SrlSubservice { get; set; }

    public double? Width { get; set; }

    public double? Length { get; set; }

    public double? Area { get; set; }

    public int? Itemcount { get; set; }

    public double? Price { get; set; }

    public double? Totalprice { get; set; }

    public string? Imageaddress { get; set; }

    [Column("srl_ordermaster")]
    public int? SrlOrdermaster { get; set; }

    public string? Description { get; set; }

    [Column("srl_orderStatus")]
    public int? SrlOrderstatus { get; set; }

    public bool? Iscash { get; set; }

    public double? Discount { get; set; }

    public string? Deliverydate { get; set; }


     [ForeignKey("SrlOrdermaster")]
     [JsonIgnore]
    public ReonetOrderMaster? ReonetMaster { get; set; } // Navigation به Master

    [ForeignKey("SrlSubservice")]
    public ReonetService? Service { get; set; } // Navigation به Service
      [ForeignKey("SrlOrderstatus")]
    public ReonetOrderStatus? Status { get; set; } // Navigation به Service
}
