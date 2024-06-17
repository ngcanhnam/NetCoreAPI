﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NCN_2121050710_2324.Migrations
{
    [DbContext(typeof(NCN017))]
    [Migration("20240617061708_Create_table_Person")]
    partial class Create_table_Person
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("NCN_2121050710_2324.Person", b =>
                {
                    b.Property<string>("HoTen")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tuoi")
                        .HasColumnType("INTEGER");

                    b.HasKey("HoTen");

                    b.ToTable("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
