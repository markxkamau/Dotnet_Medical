
using MedicalTrack.src.Drug.Model;
using MedicalTrack.src.Patient.Model;
using MedicalTrack.src.Schedule.Model;
using MedicalTrack.src.Test.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalTrack.Data;

public partial class MedicalContext : DbContext
{
    public MedicalContext()
    {
    }

    public MedicalContext(DbContextOptions<MedicalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Drug> Drugs => Set<Drug>();

    public virtual DbSet<Patient> Patients => Set<Patient>();

    public virtual DbSet<Schedule> Schedules => Set<Schedule>();

    public virtual DbSet<Test> Tests => Set<Test>();

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseNpgsql("Host=localhost; Database=medical; Username=mark; Password=root;");

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.HasPostgresExtension("hstore");

//         modelBuilder.Entity<Drug>(entity =>
//         {
//             entity.HasKey(e => e.DrugId).HasName("drug_pkey");

//             entity.ToTable("drug");

//             entity.Property(e => e.DrugId)
//                 .ValueGeneratedNever()
//                 .HasColumnName("drug_id");
//             entity.Property(e => e.DrugCount).HasColumnName("drug_count");
//             entity.Property(e => e.DrugInfo).HasColumnName("drug_info");
//             entity.Property(e => e.DrugPurpose).HasColumnName("drug_purpose");
//         });

//         modelBuilder.Entity<Patient>(entity =>
//         {
//             entity.HasKey(e => e.PatientId).HasName("patient_pkey");

//             entity.ToTable("patient");

//             entity.Property(e => e.PatientId).HasColumnName("patient_id");
//             entity.Property(e => e.PatientAge).HasColumnName("patient_age");
//             entity.Property(e => e.PatientCondition).HasColumnName("patient_condition");
//             entity.Property(e => e.PatientName).HasColumnName("patient_name");
//         });

//         modelBuilder.Entity<Schedule>(entity =>
//         {
//             entity.HasKey(e => e.ScheduleId).HasName("schedule_pkey");

//             entity.ToTable("schedule");

//             entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
//             entity.Property(e => e.ScheduleConfirm).HasColumnName("schedule_confirm");
//             entity.Property(e => e.ScheduleDay).HasColumnName("schedule_day");
//             entity.Property(e => e.ScheduleDrugId).HasColumnName("schedule_drug_id");
//             entity.Property(e => e.SchedulePatientId)
//                 .ValueGeneratedOnAdd()
//                 .HasColumnName("schedule_patient_id");
//             entity.Property(e => e.ScheduleTime).HasColumnName("schedule_time");

//             entity.HasOne(d => d.ScheduleDrug).WithMany(p => p.Schedules)
//                 .HasForeignKey(d => d.ScheduleDrugId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("schedule_schedule_drug_id_fkey");

//             entity.HasOne(d => d.SchedulePatient).WithMany(p => p.Schedules)
//                 .HasForeignKey(d => d.SchedulePatientId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("schedule_schedule_patient_id_fkey");
//         });

//         modelBuilder.Entity<Test>(entity =>
//         {
//             entity.HasKey(e => e.TestId).HasName("test_pkey");

//             entity.ToTable("test");

//             entity.Property(e => e.TestId).HasColumnName("test_id");
//             entity.Property(e => e.TestPatientId)
//                 .ValueGeneratedOnAdd()
//                 .HasColumnName("test_patient_id");
//             entity.Property(e => e.TestResultBp).HasColumnName("test_result_bp");
//             entity.Property(e => e.TestResultOxygen).HasColumnName("test_result_oxygen");
//             entity.Property(e => e.TestResultSugars).HasColumnName("test_result_sugars");
//             entity.Property(e => e.TestResultWeight).HasColumnName("test_result_weight");

//             entity.HasOne(d => d.TestPatient).WithMany(p => p.Tests)
//                 .HasForeignKey(d => d.TestPatientId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("test_test_patient_id_fkey");
//         });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
