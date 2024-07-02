﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderProcess.Data;

#nullable disable

namespace OrderProcess.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderProcess.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryCode")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OrderProcess.Core.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OrderProcess.Core.Entities.OrderEntities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("OrderCS")
                        .HasColumnType("float");

                    b.Property<string>("Packing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdNo")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("basePrice")
                        .HasColumnType("float");

                    b.Property<DateOnly>("poDate")
                        .HasColumnType("date");

                    b.Property<int>("poNo")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderProcess.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<double?>("OrderCS")
                        .HasColumnType("float");

                    b.Property<double?>("OrderPC")
                        .HasColumnType("float");

                    b.Property<string>("Packing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OrderProcess.Core.Entities.Products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("TaxRate")
                        .HasColumnType("float");

                    b.Property<double>("basePrice")
                        .HasColumnType("float");

                    b.Property<DateOnly>("basePriceEffDate")
                        .HasColumnType("date");

                    b.Property<int>("catcode")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("pricewtax")
                        .HasColumnType("float");

                    b.Property<string>("proddesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prodno")
                        .HasColumnType("int");

                    b.Property<double>("unitcost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RamProduct");
                });

            modelBuilder.Entity("OrderProcess.Core.Entities.categorygroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("groupdesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CategoryGroups");
                });

            modelBuilder.Entity("OrderProcess.Core.Entities.OrderEntities", b =>
                {
                    b.HasOne("OrderProcess.Core.Entities.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderProcess.Core.Entities.Product", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
