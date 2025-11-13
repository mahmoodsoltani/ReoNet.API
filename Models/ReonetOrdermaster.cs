using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReoNet.Api.Models;

[Table("reonet_ordermaster")]
public class ReonetOrderMaster
{
    [Key]

    public int Srl { get; set; }
    public string? OrderDate { get; set; }

    [Column("srl_customer")]
    public int? SrlCustomer { get; set; }
    public string? DeliveryDate { get; set; }
    public double? TotalPrice { get; set; }
    public double? DeliveryPrice { get; set; }
    public string? Description { get; set; }
    public string? CreateDate { get; set; }
    public int? CreateUser { get; set; }
    public int? OrderNumber { get; set; }

    public ICollection<ReonetOrderDetail> OrderDetails { get; set; } =
        new List<ReonetOrderDetail>();
}
