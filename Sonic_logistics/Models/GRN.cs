using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sonic_logistics.Models;

[Table("GRN")]
public partial class Grn
{
    [Key]
    [Column("GRN ID")]
    public int GrnId { get; set; }

    [Column("GRN Date", TypeName = "datetime")]
    public DateTime GrnDate { get; set; }

    [Column("Supplier Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string SupplierName { get; set; } = null!;

    [Column("PO ID")]
    public int PoId { get; set; }

    [Column("PO Date", TypeName = "datetime")]
    public DateTime PoDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Warehouse { get; set; } = null!;

    [Column("Product ID")]
    public int ProductId { get; set; }

    [Column("Product Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductName { get; set; } = null!;

    [Column("Batch No")]
    public int BatchNo { get; set; }

    [Column("Approved Warehouse")]
    public int ApprovedWarehouse { get; set; }

    [Column("Unapproved Warehouse")]
    public int UnapprovedWarehouse { get; set; }
}
