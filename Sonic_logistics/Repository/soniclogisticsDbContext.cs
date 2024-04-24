using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sonic_logistics.Repository.Models;
using Sonic_logistics.Models;

namespace Sonic_logistics.Repository;

public partial class soniclogisticsDbContext : DbContext
{
    public soniclogisticsDbContext()
    {
    }

    public soniclogisticsDbContext(DbContextOptions<soniclogisticsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rfq> Rfqs { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FV0R7R3;Initial Catalog=SonicLogistics1;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Po>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.ProdId).IsFixedLength();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProdId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rfq>(entity =>
        {
            entity.Property(e => e.RfqId).IsFixedLength();
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.SupId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Sonic_logistics.Models.Grn> Grn { get; set; } = default!;

public DbSet<Sonic_logistics.Models.Invoice> Invoice { get; set; } = default!;

public DbSet<Sonic_logistics.Models.SalesQuote> SalesQuote { get; set; } = default!;
}
