﻿// <auto-generated />
using CPW219_eCommerceSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CPW219_eCommerceSite.Migrations
{
    [DbContext(typeof(MenuItemContext))]
    [Migration("20240213200112_AddedMember")]
    partial class AddedMember
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CPW219_eCommerceSite.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CPW219_eCommerceSite.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemID"));

                    b.Property<string>("MenuItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MenuItemPrice")
                        .HasColumnType("float");

                    b.HasKey("MenuItemID");

                    b.ToTable("MenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}