﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Data.HangHoa", b =>
                {
                    b.Property<Guid>("Mahh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Dongia")
                        .HasColumnType("float");

                    b.Property<byte>("Giamgia")
                        .HasColumnType("tinyint");

                    b.Property<int?>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenhh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Mahh");

                    b.HasIndex("MaLoai");

                    b.ToTable("HangHoas");
                });

            modelBuilder.Entity("WebApplication1.Data.Loaihh", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("Loaihhs");
                });

            modelBuilder.Entity("WebApplication1.Data.HangHoa", b =>
                {
                    b.HasOne("WebApplication1.Data.Loaihh", "Loaihh")
                        .WithMany("HangHoa")
                        .HasForeignKey("MaLoai");

                    b.Navigation("Loaihh");
                });

            modelBuilder.Entity("WebApplication1.Data.Loaihh", b =>
                {
                    b.Navigation("HangHoa");
                });
#pragma warning restore 612, 618
        }
    }
}
