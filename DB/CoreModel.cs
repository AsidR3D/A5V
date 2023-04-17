using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace A5V.DB;

public partial class CoreModel : DbContext
{
    private static CoreModel Core;
    public static CoreModel init()
    {
        if (Core == null)
            Core = new CoreModel();
        return Core;
    }
    public CoreModel()
    {
    }

    public CoreModel(DbContextOptions<CoreModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Medkomissiya> Medkomissiyas { get; set; }

    public virtual DbSet<Priizvnik> Priizvniks { get; set; }

    public virtual DbSet<Rabotnik> Rabotniks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr23-36_VoronyanskijAV;password=ISPr23-36_VoronyanskijAV;database=ISPr23-36_VoronyanskijAV_voenkomat;character set=utf8", ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Medkomissiya>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("medkomissiya");

            entity.HasIndex(e => e.PriizvnikId, "medkomissiya_ibfk_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BloodType)
                .HasMaxLength(50)
                .HasColumnName("blood_type");
            entity.Property(e => e.ChronicDiseases)
                .HasMaxLength(50)
                .HasColumnName("chronic_diseases");
            entity.Property(e => e.HearingLeft)
                .HasMaxLength(50)
                .HasColumnName("hearing_left");
            entity.Property(e => e.HearingRight)
                .HasMaxLength(50)
                .HasColumnName("hearing_right");
            entity.Property(e => e.Height)
                .HasMaxLength(50)
                .HasColumnName("height");
            entity.Property(e => e.MentalHealth)
                .HasMaxLength(50)
                .HasColumnName("mental_health");
            entity.Property(e => e.PriizvnikId).HasColumnName("priizvnik_id");
            entity.Property(e => e.VisionLeft)
                .HasMaxLength(50)
                .HasColumnName("vision_left");
            entity.Property(e => e.VisionRight)
                .HasMaxLength(50)
                .HasColumnName("vision_right");
            entity.Property(e => e.Weight)
                .HasMaxLength(50)
                .HasColumnName("weight");

            entity.HasOne(d => d.Priizvnik).WithMany(p => p.Medkomissiyas)
                .HasForeignKey(d => d.PriizvnikId)
                .HasConstraintName("medkomissiya_ibfk_1");
        });

        modelBuilder.Entity<Priizvnik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("priizvnik");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate)
                .HasMaxLength(50)
                .HasColumnName("birthdate");
            entity.Property(e => e.CriminalRecord)
                .HasMaxLength(50)
                .HasColumnName("criminal_record");
            entity.Property(e => e.Education)
                .HasMaxLength(50)
                .HasColumnName("education");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(50)
                .HasColumnName("marital_status");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Profession)
                .HasMaxLength(50)
                .HasColumnName("profession");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Rabotnik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rabotnik");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
