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

    public virtual DbSet<Tag> Tags { get; set; }

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
                .HasColumnName("createdat");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Taskid).HasColumnName("taskid");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Project).WithMany(p => p.Notes)
                .HasForeignKey(d => d.Projectid)
                .HasConstraintName("note_projectid_fkey");

            entity.HasOne(d => d.Task).WithMany(p => p.Notes)
                .HasForeignKey(d => d.Taskid)
                .HasConstraintName("note_taskid_fkey");
        });

        modelBuilder.Entity<Notetag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("notetag");

            entity.HasIndex(e => e.Tagid, "notetag_tagid_key").IsUnique();

            entity.Property(e => e.Noteid).HasColumnName("noteid");
            entity.Property(e => e.Tagid).HasColumnName("tagid");

            entity.HasOne(d => d.Note).WithMany()
                .HasForeignKey(d => d.Noteid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notetag_noteid_fkey");

            entity.HasOne(d => d.Tag).WithOne()
                .HasForeignKey<Notetag>(d => d.Tagid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notetag_tagid_fkey");
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
                .HasColumnName("createdat");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'without description.'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Statusid)
                .HasDefaultValue(1)
                .HasColumnName("statusid");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_statusid_fkey");
        });

        modelBuilder.Entity<Projectstatus>(entity =>
        {
            entity.HasKey(e => e.Projectstatusid).HasName("projectstatus_pkey");

            entity.ToTable("projectstatus");

            entity.HasIndex(e => e.Name, "projectstatus_name_key").IsUnique();

            entity.Property(e => e.Projectstatusid).HasColumnName("projectstatusid");
            entity.Property(e => e.Backgroundcolor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(50, 50, 50, 0.9)'::character varying")
                .HasColumnName("backgroundcolor");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Namecolor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(75, 75, 75, 0.9)'::character varying")
                .HasColumnName("namecolor");
        });

        modelBuilder.Entity<Projecttag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("projecttag");

            entity.HasIndex(e => e.Tagid, "projecttag_tagid_key").IsUnique();

            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Tagid).HasColumnName("tagid");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projecttag_projectid_fkey");

            entity.HasOne(d => d.Tag).WithOne()
                .HasForeignKey<Projecttag>(d => d.Tagid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projecttag_tagid_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Tagid).HasName("tag_pkey");

            entity.ToTable("tag");

            entity.Property(e => e.Tagid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("tagid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdat");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnName("updatedat");
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
                .HasColumnName("createdat");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'without description.'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Statusid)
                .HasDefaultValue(1)
                .HasColumnName("statusid");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_projectid_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_statusid_fkey");
        });

        modelBuilder.Entity<Taskstatus>(entity =>
        {
            entity.HasKey(e => e.Taskstatusid).HasName("taskstatus_pkey");

            entity.ToTable("taskstatus");

            entity.HasIndex(e => e.Name, "taskstatus_name_key").IsUnique();

            entity.Property(e => e.Taskstatusid).HasColumnName("taskstatusid");
            entity.Property(e => e.Backgroundcolor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(50, 50, 50, 0.9)'::character varying")
                .HasColumnName("backgroundcolor");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Namecolor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(75, 75, 75, 0.9)'::character varying")
                .HasColumnName("namecolor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
