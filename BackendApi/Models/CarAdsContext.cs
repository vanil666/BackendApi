using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Models;

public partial class CarAdsContext : DbContext
{
    public CarAdsContext()
    {
    }

    public CarAdsContext(DbContextOptions<CarAdsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarCategory> CarCategories { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Listing> Listings { get; set; }

    public virtual DbSet<ListingCategory> ListingCategories { get; set; }

    public virtual DbSet<ListingImage> ListingImages { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserReview> UserReviews { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Cars__68A0340E987F0CA0");

            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.Condition).HasMaxLength(20);
            entity.Property(e => e.FuelType).HasMaxLength(20);
            entity.Property(e => e.ListingId).HasColumnName("ListingID");
            entity.Property(e => e.Make).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Transmission).HasMaxLength(20);

            entity.HasOne(d => d.Listing).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ListingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cars__ListingID__403A8C7D");
        });

        modelBuilder.Entity<CarCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__CarCateg__19093A2B04FC472C");

            entity.HasIndex(e => e.CategoryName, "UQ__CarCateg__8517B2E010E38D26").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK__CarCatego__Paren__59FA5E80");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__CE74FAF5E442F3AA");

            entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ListingId).HasColumnName("ListingID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Listing).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ListingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__Listi__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__UserI__4CA06362");
        });

        modelBuilder.Entity<Listing>(entity =>
        {
            entity.HasKey(e => e.ListingId).HasName("PK__Listings__BF3EBEF04AC97539");

            entity.Property(e => e.ListingId).HasColumnName("ListingID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsExchangeable).HasDefaultValue(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Listings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Listings__UserID__3D5E1FD2");
        });

        modelBuilder.Entity<ListingCategory>(entity =>
        {
            entity.HasKey(e => e.ListingCategoryId).HasName("PK__ListingC__CEC5D22908B635D0");

            entity.Property(e => e.ListingCategoryId).HasColumnName("ListingCategoryID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ListingId).HasColumnName("ListingID");

            entity.HasOne(d => d.Category).WithMany(p => p.ListingCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListingCa__Categ__5DCAEF64");

            entity.HasOne(d => d.Listing).WithMany(p => p.ListingCategories)
                .HasForeignKey(d => d.ListingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListingCa__Listi__5CD6CB2B");
        });

        modelBuilder.Entity<ListingImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__ListingI__7516F4ECDFB0D065");

            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.ListingId).HasColumnName("ListingID");

            entity.HasOne(d => d.Listing).WithMany(p => p.ListingImages)
                .HasForeignKey(d => d.ListingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListingIm__Listi__4316F928");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477E1DBAD69");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.ListingId).HasColumnName("ListingID");
            entity.Property(e => e.Region).HasMaxLength(100);

            entity.HasOne(d => d.Listing).WithMany(p => p.Locations)
                .HasForeignKey(d => d.ListingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Locations__Listi__5629CD9C");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C037C1C003C8E");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.ListingId).HasColumnName("ListingID");
            entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Listing).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ListingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__Listin__48CFD27E");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__Receiv__47DBAE45");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__Sender__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC714EEAE8");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F47513C1").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__UserRevi__74BC79AEAA5E7EED");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewedUserId).HasColumnName("ReviewedUserID");
            entity.Property(e => e.ReviewerId).HasColumnName("ReviewerID");

            entity.HasOne(d => d.ReviewedUser).WithMany(p => p.UserReviewReviewedUsers)
                .HasForeignKey(d => d.ReviewedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRevie__Revie__534D60F1");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.UserReviewReviewers)
                .HasForeignKey(d => d.ReviewerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRevie__Revie__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
