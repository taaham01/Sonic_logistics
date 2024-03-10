using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sonic_logistics.Repository.Models;

[Table("RFQ")]
public partial class Rfq
{
    [Key]
    [Column("rfq_id")]
    [StringLength(10)]
    public string RfqId { get; set; } = null!;

    [Column("operational_unit")]
    [StringLength(50)]
    [Unicode(false)]
    public string OperationalUnit { get; set; } = null!;

    [Column("Shipping_address")]
    [StringLength(100)]
    [Unicode(false)]
    public string ShippingAddress { get; set; } = null!;

    [Column("due_date", TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    [Column("create_date", TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("buyer")]
    [StringLength(50)]
    [Unicode(false)]
    public string Buyer { get; set; } = null!;

    [Column("currency")]
    public int Currency { get; set; }

    [Column("prod_ID")]
    public int ProdId { get; set; }

    [Column("product_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductName { get; set; } = null!;

    [Column("category")]
    [StringLength(50)]
    [Unicode(false)]
    public string Category { get; set; } = null!;

    [Column("UOM")]
    [StringLength(50)]
    [Unicode(false)]
    public string Uom { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("Item_discription")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ItemDiscription { get; set; }

    [Column("price_per_unit")]
    public int PricePerUnit { get; set; }

    [Column("total_price")]
    public int TotalPrice { get; set; }
}
