using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace bkd_utileria_centralizada.Models
{
    public partial class utileriadbContext : DbContext
    {
        public utileriadbContext()
        {
        }

        public utileriadbContext(DbContextOptions<utileriadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatCountry> CatCountries { get; set; } = null!;
        public virtual DbSet<CatDistribution> CatDistributions { get; set; } = null!;
        public virtual DbSet<CatRegion> CatRegions { get; set; } = null!;
        public virtual DbSet<CatRoute> CatRoutes { get; set; } = null!;
        public virtual DbSet<MenuUtileriaCentralizacion> MenuUtileriaCentralizacions { get; set; } = null!;
        public virtual DbSet<ScheduleService> ScheduleServices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatCountry>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__cat_coun__294318F4FCADEBB3");

                entity.ToTable("cat_country");

                entity.Property(e => e.IdCountry).HasColumnName("id_country");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<CatDistribution>(entity =>
            {
                entity.HasKey(e => e.IdDistribution)
                    .HasName("PK__cat_dist__865145B36AB8B8A9");

                entity.ToTable("cat_distribution");

                entity.Property(e => e.IdDistribution).HasColumnName("id_distribution");

                entity.Property(e => e.DistributionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("distribution_name");

                entity.Property(e => e.IdRegion).HasColumnName("id_region");

                entity.HasOne(d => d.oRegion)
                    .WithMany(p => p.CatDistributions)
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK__cat_distr__id_re__3F466844");
            });

            modelBuilder.Entity<CatRegion>(entity =>
            {
                entity.HasKey(e => e.IdRegion)
                    .HasName("PK__cat_regi__3CEC6B52C4114BC6");

                entity.ToTable("cat_region");

                entity.Property(e => e.IdRegion).HasColumnName("id_region");

                entity.Property(e => e.IdCountry).HasColumnName("id_country");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("region_name");

                entity.HasOne(d => d.oCountry)
                    .WithMany(p => p.CatRegions)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK__cat_regio__id_co__3C69FB99");
            });

            modelBuilder.Entity<CatRoute>(entity =>
            {
                entity.HasKey(e => e.IdRoute)
                    .HasName("PK__cat_rout__3C8882D0D7940CCA");

                entity.ToTable("cat_route");

                entity.Property(e => e.IdRoute).HasColumnName("id_route");

                entity.Property(e => e.IdDistribution).HasColumnName("id_distribution");

                entity.Property(e => e.RouteName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("route_name");

                entity.HasOne(d => d.oDistribution)
                    .WithMany(p => p.CatRoutes)
                    .HasForeignKey(d => d.IdDistribution)
                    .HasConstraintName("FK__cat_route__id_di__4222D4EF");
            });

            modelBuilder.Entity<MenuUtileriaCentralizacion>(entity =>
            {
                entity.ToTable("menu_utileria_centralizacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IconoOpcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("icono_opcion");

                entity.Property(e => e.IconoSiguiente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("icono_siguiente");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.NombreOpcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_opcion");
            });

            modelBuilder.Entity<ScheduleService>(entity =>
            {
                entity.HasKey(e => e.IdScheduleService)
                    .HasName("PK__schedule__EA280309D205453F");

                entity.ToTable("schedule_services");

                entity.Property(e => e.IdScheduleService).HasColumnName("id_schedule_service");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IdCountry).HasColumnName("id_country");

                entity.Property(e => e.IdDistribution).HasColumnName("id_distribution");

                entity.Property(e => e.IdRegion).HasColumnName("id_region");

                entity.Property(e => e.IdRoute).HasColumnName("id_route");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.ScheduleServices)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK__schedule___id_co__44FF419A");

                entity.HasOne(d => d.IdDistributionNavigation)
                    .WithMany(p => p.ScheduleServices)
                    .HasForeignKey(d => d.IdDistribution)
                    .HasConstraintName("FK__schedule___id_di__46E78A0C");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.ScheduleServices)
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK__schedule___id_re__45F365D3");

                entity.HasOne(d => d.IdRouteNavigation)
                    .WithMany(p => p.ScheduleServices)
                    .HasForeignKey(d => d.IdRoute)
                    .HasConstraintName("FK__schedule___id_ro__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
