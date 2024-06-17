﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Canhnamtest2.Migrations
{
    [DbContext(typeof(LTQLDb))]
    [Migration("20240614151924_Create_table_LopHoc")]
    partial class Create_table_LopHoc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Canhnamtest2.Models.LopHoc", b =>
                {
                    b.Property<int>("MaLop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("MaLop");

                    b.ToTable("LopHoc");
                });

            modelBuilder.Entity("Canhnamtest2.Models.SinhVien", b =>
                {
                    b.Property<string>("MaSinhVien")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("LopHocMaLop")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaLop")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaSinhVien");

                    b.HasIndex("LopHocMaLop");

                    b.ToTable("SinhVien");
                });

            modelBuilder.Entity("Canhnamtest2.Models.SinhVien", b =>
                {
                    b.HasOne("Canhnamtest2.Models.LopHoc", "LopHoc")
                        .WithMany("SinhVien")
                        .HasForeignKey("LopHocMaLop");

                    b.Navigation("LopHoc");
                });

            modelBuilder.Entity("Canhnamtest2.Models.LopHoc", b =>
                {
                    b.Navigation("SinhVien");
                });
#pragma warning restore 612, 618
        }
    }
}
