using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sonic_logistics.Repository.Models;

[Table("PO")]
public partial class Po
{
    [Column("cus_id")]
    public int CusId { get; set; }

    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("Sup_id")]
    public int SupId { get; set; }

    [Column("prod_ID")]
    [StringLength(10)]
    public string ProdId { get; set; } = null!;

    [Column("order_date/time", TypeName = "datetime")]
    public DateTime OrderDateTime { get; set; }

    [Column("shipped_date")]
    public DateOnly ShippedDate { get; set; }

    [Column("address")]
    [StringLength(50)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("city")]
    [StringLength(50)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [Column("country")]
    [StringLength(50)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("user_id")]
    public int UserId { get; set; }
}
