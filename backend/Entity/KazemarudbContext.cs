using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Entity;

public partial class KazemarudbContext : DbContext
{
    public KazemarudbContext()
    {
    }

    public KazemarudbContext(DbContextOptions<KazemarudbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Notetag> Notetags { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Projectstatus> Projectstatuses { get; set; }

    public virtual DbSet<Projecttag> Projecttags { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Taskstatus> Taskstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Noteid).HasName("note_pkey");

            entity.ToTable("note");

            entity.Property(e => e.Noteid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("noteid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Project).HasColumnName("project");
            entity.Property(e => e.Task).HasColumnName("task");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.ProjectNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.Project)
                .HasConstraintName("note_project_fkey");

            entity.HasOne(d => d.TaskNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.Task)
                .HasConstraintName("note_task_fkey");
        });

        modelBuilder.Entity<Notetag>(entity =>
        {
            entity.HasKey(e => e.Noteid).HasName("notetag_pkey");

            entity.ToTable("notetag");

            entity.HasIndex(e => e.Name, "notetag_name_key").IsUnique();

            entity.Property(e => e.Noteid)
                .ValueGeneratedNever()
                .HasColumnName("noteid");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projectid).HasName("project_pkey");

            entity.ToTable("project");

            entity.HasIndex(e => e.Name, "project_name_key").IsUnique();

            entity.Property(e => e.Projectid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("projectid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'without description.'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("project_status_fkey");
        });

        modelBuilder.Entity<Projectstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("projectstatus_pkey");

            entity.ToTable("projectstatus");

            entity.HasIndex(e => e.Name, "projectstatus_name_key").IsUnique();

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Content)
                .HasMaxLength(50)
                .HasColumnName("content");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Projecttag>(entity =>
        {
            entity.HasKey(e => e.Projectid).HasName("projecttag_pkey");

            entity.ToTable("projecttag");

            entity.HasIndex(e => e.Name, "projecttag_name_key").IsUnique();

            entity.Property(e => e.Projectid)
                .ValueGeneratedNever()
                .HasColumnName("projectid");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Taskid).HasName("task_pkey");

            entity.ToTable("task");

            entity.Property(e => e.Taskid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("taskid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'without description.'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_projectid_fkey");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("task_status_fkey");
        });

        modelBuilder.Entity<Taskstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("taskstatus_pkey");

            entity.ToTable("taskstatus");

            entity.HasIndex(e => e.Name, "taskstatus_name_key").IsUnique();

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
