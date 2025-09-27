using System;
using System.Collections.Generic;
using DoctorAppointmentScheduler.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Data;

public partial class DoctorappointmentContext : DbContext
{
    public DoctorappointmentContext(DbContextOptions<DoctorappointmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Maritalstatus> Maritalstatuses { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Countryid).HasName("country_pkey");

            entity.Property(e => e.Countryid).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Isdeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Maritalstatus>(entity =>
        {
            entity.HasKey(e => e.Maritalstatusid).HasName("maritalstatus_pkey");

            entity.Property(e => e.Maritalstatusid).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Isdeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.Occupationid).HasName("occupation_pkey");

            entity.Property(e => e.Occupationid).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Isdeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.Religionid).HasName("religion_pkey");

            entity.Property(e => e.Religionid).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Isdeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Titleid).HasName("title_pkey");

            entity.Property(e => e.Titleid).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Isdeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.Property(e => e.Userid).HasDefaultValueSql("gen_random_uuid()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
