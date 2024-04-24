using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sonic_logistics.Models;

public partial class Sales_quote : DbContext
{
    public Sales_quote()
    {
    }

    public Sales_quote(DbContextOptions<Sales_quote> options)
        : base(options)
    {
    }

    public virtual DbSet<SalesQuote> SalesQuotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FV0R7R3;Initial Catalog=SonicLogistics1;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesQuote>(entity =>
        {
            entity.Property(e => e.SqId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
