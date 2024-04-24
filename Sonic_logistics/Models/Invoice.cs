using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sonic_logistics.Models;

[Table("Invoice")]
public partial class Invoice
{
    [Key]
    [Column("Invoice ID")]
    public int InvoiceId { get; set; }

    [Column("Operating Unit")]
    [StringLength(50)]
    [Unicode(false)]
    public string OperatingUnit { get; set; } = null!;

    [Column("Invoice Date", TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Column("Supplier ID")]
    public int SupplierId { get; set; }

    [Column("Supplier Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string SupplierName { get; set; } = null!;

    [Column("Invoice Currency")]
    [StringLength(50)]
    [Unicode(false)]
    public string InvoiceCurrency { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Discription { get; set; } = null!;

    [Column("Payment Method")]
    [StringLength(50)]
    [Unicode(false)]
    public string PaymentMethod { get; set; } = null!;

    [Column("Product Type")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductType { get; set; } = null!;

    public int Quantity { get; set; }

    [Column("Total Amount")]
    public int TotalAmount { get; set; }
}
