using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Models;

public partial class DoctorappointmentContext : DbContext
{
    public DoctorappointmentContext()
    {
    }

    public DoctorappointmentContext(DbContextOptions<DoctorappointmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Occupation> Occupations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=doctorappointment;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.Occupationid).HasName("occupation_pkey");

            entity.ToTable("occupation", "master");

            entity.Property(e => e.Occupationid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("occupationid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Occupationname)
                .HasMaxLength(100)
                .HasColumnName("occupationname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
