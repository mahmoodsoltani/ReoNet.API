using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReoNet.Api.Models;

public partial class ReonetCustomer
{
    [Key]
    public int Srl { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public string Code { get; set; } = null!;

    /// <summary>
    /// 0,1,2
    /// </summary>
    public int? SrlGender { get; set; }

    public string? Tell1 { get; set; }

    public string? Tell2 { get; set; }

    public string? Address { get; set; }

    public string? Postcode { get; set; }

    public int? SrlCity { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createdate { get; set; }

    public int? Createuser { get; set; }

    public bool? IsCompany { get; set; }

    public string? Companyname { get; set; }

    public double? Commission { get; set; }
}
