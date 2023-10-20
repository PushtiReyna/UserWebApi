using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class UserApidbContext : DbContext
{
    public UserApidbContext()
    {
    }

    public UserApidbContext(DbContextOptions<UserApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryMst> CategoryMsts { get; set; }

    public virtual DbSet<SubcategoryMst> SubcategoryMsts { get; set; }

    public virtual DbSet<UserMst> UserMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=UserAPIDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryMst>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B35D53E45");

            entity.ToTable("CategoryMst");

            entity.Property(e => e.Categoryname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubcategoryMst>(entity =>
        {
            entity.HasKey(e => e.SubcategoryId).HasName("PK__Subcateg__9C4E705DD2FFF99E");

            entity.ToTable("SubcategoryMst");

            entity.Property(e => e.Subcategoryname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserMst__3214EC072A72AD15");

            entity.ToTable("UserMst");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Createddate).HasColumnType("datetime");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Mobilenumber).HasMaxLength(30);
            entity.Property(e => e.Percentage).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Updateddate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
