﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Testlacuoi.Migrations
{
    [DbContext(typeof(LTQLDb))]
    [Migration("20240616142227_Create_table_LopHoc")]
    partial class Create_table_LopHoc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Testlacuoi.Models.LopHoc", b =>
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
#pragma warning restore 612, 618
        }
    }
}
