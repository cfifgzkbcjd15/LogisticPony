using System;
using System.Collections.Generic;
using Logistic.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistic.Data;

public partial class VipPonyContext : DbContext
{
    public VipPonyContext()
    {
    }

    public VipPonyContext(DbContextOptions<VipPonyContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public virtual DbSet<DataPony> DataPonies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VipPony;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataPony>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Data_pkey");

            entity.ToTable("DataPony");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CategoryWork).HasColumnName("category_work");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitde).HasColumnName("longitde");
            entity.Property(e => e.OrderNum).HasColumnName("order_num");
            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.SubareaId).HasColumnName("subarea_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
