﻿// <auto-generated />
using System;
using CustomerPOS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerPOS.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerPOS.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPurchase")
                        .HasColumnType("int");

                    b.Property<int>("purchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("purchaseId")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CustomerPOS.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("real");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CustomerPOS.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("CustomerPOS.Models.Customer", b =>
                {
                    b.HasOne("CustomerPOS.Models.Purchase", "purchase")
                        .WithOne("customer")
                        .HasForeignKey("CustomerPOS.Models.Customer", "purchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("purchase");
                });

            modelBuilder.Entity("CustomerPOS.Models.Product", b =>
                {
                    b.HasOne("CustomerPOS.Models.Purchase", "purchase")
                        .WithMany("Products")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("purchase");
                });

            modelBuilder.Entity("CustomerPOS.Models.Purchase", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
