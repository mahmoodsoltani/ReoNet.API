using System;
using System.Collections.Generic;

namespace ReoNet.Api.Models;

public partial class AccAshkha
{
    public int Srl { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Adres1 { get; set; }

    public string? Adres2 { get; set; }

    public string? Mobile { get; set; }

    public double? Eshterak { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? Fax { get; set; }

    public int? SrlAccAshkhasOnvan { get; set; }

    public double? SaghfEtebar { get; set; }

    public int? SrlCompany { get; set; }

    public int? SrlSubmitUser { get; set; }

    public DateTime? SubmitDate { get; set; }

    public bool? ShakhsType { get; set; }

    public string? Tavalod { get; set; }

    public string? Ezdevaj { get; set; }

    public string? EconomicCode { get; set; }

    public string? Email { get; set; }

    public string? Site { get; set; }

    public string? CodeMelli { get; set; }

    public string? RegisterNomber { get; set; }

    public string? JavazKasbNomber { get; set; }

    public string? Ostan { get; set; }

    public string? Shahr { get; set; }

    public string? Shahrestan { get; set; }

    public bool? IsActive { get; set; }
}
