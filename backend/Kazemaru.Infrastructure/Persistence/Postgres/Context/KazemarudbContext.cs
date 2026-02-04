using Kazemaru.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Kazemaru.Domain.Entities.Task;

namespace Kazemaru.Infrastructure.Persistence.Postgres.Context;

public partial class KazemaruDbContext : DbContext
{
    public KazemaruDbContext()
    {
    }

    public KazemaruDbContext(DbContextOptions<KazemaruDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<NotesTag> NotesTags { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsBlacklist> ProjectsBlacklists { get; set; }

    public virtual DbSet<ProjectsMember> ProjectsMembers { get; set; }

    public virtual DbSet<ProjectsSharedLink> ProjectsSharedLinks { get; set; }

    public virtual DbSet<ProjectsStatus> ProjectsStatuses { get; set; }

    public virtual DbSet<ProjectsTag> ProjectsTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TasksStatus> TasksStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("notes_pkey");

            entity.ToTable("notes");

            entity.Property(e => e.NoteId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("note_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Project).WithMany(p => p.Notes)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("notes_project_id_fkey");

            entity.HasOne(d => d.Task).WithMany(p => p.Notes)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("notes_task_id_fkey");
        });

        modelBuilder.Entity<NotesTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("notes_tags");

            entity.HasIndex(e => e.TagId, "notes_tags_tag_id_key").IsUnique();

            entity.Property(e => e.NoteId).HasColumnName("note_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Note).WithMany()
                .HasForeignKey(d => d.NoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notes_tags_note_id_fkey");

            entity.HasOne(d => d.Tag).WithOne()
                .HasForeignKey<NotesTag>(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notes_tags_tag_id_fkey");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.HasIndex(e => e.Name, "projects_name_key").IsUnique();

            entity.Property(e => e.ProjectId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("project_id");
            entity.Property(e => e.Banner)
                .HasMaxLength(255)
                .HasColumnName("banner");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("without_description()")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.StatusId)
                .HasDefaultValue(1)
                .HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Owner).WithMany(p => p.Projects)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_owner_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_status_id_fkey");
        });

        modelBuilder.Entity<ProjectsBlacklist>(entity =>
        {
            entity.HasKey(e => e.ProjectBlacklistId).HasName("projects_blacklists_pkey");

            entity.ToTable("projects_blacklists");

            entity.Property(e => e.ProjectBlacklistId).HasColumnName("project_blacklist_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsBlacklists)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_blacklists_project_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectsBlacklists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_blacklists_user_id_fkey");
        });

        modelBuilder.Entity<ProjectsMember>(entity =>
        {
            entity.HasKey(e => e.ProjectMemberId).HasName("projects_members_pkey");

            entity.ToTable("projects_members");

            entity.Property(e => e.ProjectMemberId).HasColumnName("project_member_id");
            entity.Property(e => e.JoinedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("joined_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsMembers)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_members_project_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectsMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_members_user_id_fkey");
        });

        modelBuilder.Entity<ProjectsSharedLink>(entity =>
        {
            entity.HasKey(e => e.ProjectSharedLinkId).HasName("projects_shared_links_pkey");

            entity.ToTable("projects_shared_links");

            entity.Property(e => e.ProjectSharedLinkId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("project_shared_link_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .HasColumnName("value");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsSharedLinks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_shared_links_project_id_fkey");
        });

        modelBuilder.Entity<ProjectsStatus>(entity =>
        {
            entity.HasKey(e => e.ProjectStatusId).HasName("projects_statuses_pkey");

            entity.ToTable("projects_statuses");

            entity.HasIndex(e => e.Name, "projects_statuses_name_key").IsUnique();

            entity.Property(e => e.ProjectStatusId).HasColumnName("project_status_id");
            entity.Property(e => e.BackgroundColor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(20, 20, 20, 0.9)'::character varying")
                .HasColumnName("background_color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasDefaultValueSql("without_description()")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.NameColor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(150, 150, 150, 0.9)'::character varying")
                .HasColumnName("name_color");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProjectsTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("projects_tags");

            entity.HasIndex(e => e.TadId, "projects_tags_tad_id_key").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.TadId).HasColumnName("tad_id");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_tags_project_id_fkey");

            entity.HasOne(d => d.Tad).WithOne()
                .HasForeignKey<ProjectsTag>(d => d.TadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_tags_tad_id_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.Property(e => e.TagId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("tag_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasDefaultValueSql("without_description()")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("tasks_pkey");

            entity.ToTable("tasks");

            entity.Property(e => e.TaskId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("task_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("without_description()")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.StatusId)
                .HasDefaultValue(1)
                .HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_project_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_status_id_fkey");
        });

        modelBuilder.Entity<TasksStatus>(entity =>
        {
            entity.HasKey(e => e.TaskStatusId).HasName("tasks_statuses_pkey");

            entity.ToTable("tasks_statuses");

            entity.HasIndex(e => e.Name, "tasks_statuses_name_key").IsUnique();

            entity.Property(e => e.TaskStatusId).HasColumnName("task_status_id");
            entity.Property(e => e.BackgroundColor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(50, 50, 50, 0.9)'::character varying")
                .HasColumnName("background_color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasDefaultValueSql("without_description()")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.NameColor)
                .HasMaxLength(30)
                .HasDefaultValueSql("'rgba(75, 75, 75, 0.9)'::character varying")
                .HasColumnName("name_color");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.DisplayName, "users_display_name_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .HasColumnName("display_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PasswordHint)
                .HasMaxLength(255)
                .HasColumnName("password_hint");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}