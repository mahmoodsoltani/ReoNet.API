using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReoNet.Api.Models.Auth;

[Table("sec_user")]
public partial class SecUser
{
    [Key]
    public int Srl { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool? Enabled { get; set; }

    public string? RegisterDate { get; set; }

    public string? ExpirementDate { get; set; }

    [Column("Srl_Acc_Ashkhas")]
    public int? SrlAccAshkhas { get; set; }

    public byte[]? Salt { get; set; }

    public string? Email { get; set; }

    [Column("Srl_Customer")]
    public int? SrlCustomer { get; set; }

    [Column("Is_Active")]
    public bool? IsActive { get; set; }
}
