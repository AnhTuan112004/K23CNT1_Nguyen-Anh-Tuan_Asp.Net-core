using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenAnhTuan_2310900113.Models;

public partial class NguyenAnhTuan2310900113Context : DbContext
{
    public NguyenAnhTuan2310900113Context()
    {
    }

    public NguyenAnhTuan2310900113Context(DbContextOptions<NguyenAnhTuan2310900113Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NatEmployee> NatEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AnhTuan\\MSSQLSERVER_DEV;Database=NguyenAnhTuan_2310900113;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NatEmployee>(entity =>
        {
            entity.HasKey(e => e.NatEmpId).HasName("PK__NatEmplo__CBDD9908C3C863EB");

            entity.ToTable("NatEmployee");

            entity.Property(e => e.NatEmpLevel).HasMaxLength(50);
            entity.Property(e => e.NatEmpName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
