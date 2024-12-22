using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using prepearingtoexam.Models;

namespace prepearingtoexam.Context;

public partial class MarsyBaseContext : DbContext
{
    public MarsyBaseContext()
    {
    }

    public MarsyBaseContext(DbContextOptions<MarsyBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacture> Manufactures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productphoto> Productphotos { get; set; }

    public virtual DbSet<Productsale> Productsales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87;Port=5522;Database=marsy_base;Username=marsy;password=jona");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("manufacture_pk");

            entity.ToTable("manufacture", "Marsyy_2");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Startday).HasColumnName("startday");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pk");

            entity.ToTable("product", "Marsyy_2");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Mainphotopath)
                .HasColumnType("character varying")
                .HasColumnName("mainphotopath");
            entity.Property(e => e.Manufactureid).HasColumnName("manufactureid");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.Manufacture).WithMany(p => p.Products)
                .HasForeignKey(d => d.Manufactureid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_manufacture_fk");

            entity.HasMany(d => d.Attacehedproducts).WithMany(p => p.Mainproducts)
                .UsingEntity<Dictionary<string, object>>(
                    "Attachedofproduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("Attacehedproductid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("attachedofproduct_product_fk_1"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("Mainproductid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("attachedofproduct_product_fk"),
                    j =>
                    {
                        j.HasKey("Mainproductid", "Attacehedproductid").HasName("attachedofproduct_pk");
                        j.ToTable("attachedofproduct", "Marsyy_2");
                        j.IndexerProperty<int>("Mainproductid").HasColumnName("mainproductid");
                        j.IndexerProperty<int>("Attacehedproductid").HasColumnName("attacehedproductid");
                    });

            entity.HasMany(d => d.Mainproducts).WithMany(p => p.Attacehedproducts)
                .UsingEntity<Dictionary<string, object>>(
                    "Attachedofproduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("Mainproductid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("attachedofproduct_product_fk"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("Attacehedproductid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("attachedofproduct_product_fk_1"),
                    j =>
                    {
                        j.HasKey("Mainproductid", "Attacehedproductid").HasName("attachedofproduct_pk");
                        j.ToTable("attachedofproduct", "Marsyy_2");
                        j.IndexerProperty<int>("Mainproductid").HasColumnName("mainproductid");
                        j.IndexerProperty<int>("Attacehedproductid").HasColumnName("attacehedproductid");
                    });
        });

        modelBuilder.Entity<Productphoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productphoto_pk");

            entity.ToTable("productphoto", "Marsyy_2");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Photopath)
                .HasColumnType("character varying")
                .HasColumnName("photopath");
            entity.Property(e => e.Productid).HasColumnName("productid");

            entity.HasOne(d => d.Product).WithMany(p => p.Productphotos)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productphoto_product_fk");
        });

        modelBuilder.Entity<Productsale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productsale_pk");

            entity.ToTable("productsale", "Marsyy_2");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Saledate).HasColumnName("saledate");

            entity.HasOne(d => d.Product).WithMany(p => p.Productsales)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productsale_product_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
