using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReoNet.Api.Models;

public class ReonetOrderImage
{
    public int Srl { get; set; }
    public int Srl_OrderDetail { get; set; }
    public string Media_Type { get; set; }  // image / video
    public string File_Path { get; set; }
    public string Stage { get; set; }       // before / washing / drying / after
    public DateTime Created_At { get; set; }
        [ForeignKey("Srl_OrderDetail")]
    public virtual ReonetOrderDetail? OrderDetail { get; set; }
}
