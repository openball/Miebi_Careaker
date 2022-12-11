﻿// <auto-generated />
using Caretaker.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Caretaker.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220710070052_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Caretaker.Shared.Apartment", b =>
                {
                    b.Property<int>("ApartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentId"), 1L, 1);

                    b.Property<string>("ApartmentTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApartmentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("BillingCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int>("OccupiedBy")
                        .HasColumnType("int");

                    b.HasKey("ApartmentId");

                    b.HasIndex("ApartmentTypeId");

                    b.HasIndex("BillingCategoryId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Caretaker.Shared.ApartmentType", b =>
                {
                    b.Property<int>("ApartmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentTypeId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApartmentTypeId");

                    b.ToTable("ApartmentTypes");
                });

            modelBuilder.Entity("Caretaker.Shared.BillingCategory", b =>
                {
                    b.Property<int>("BillingCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillingCategoryId"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("BillingCategoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BillingCategoryId");

                    b.ToTable("BillingCategories");
                });

            modelBuilder.Entity("Caretaker.Shared.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"), 1L, 1);

                    b.Property<string>("BuildingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Caretaker.Shared.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"), 1L, 1);

                    b.Property<string>("GenderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Caretaker.Shared.NoticeBoard", b =>
                {
                    b.Property<int>("NoticeBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoticeBoardId"), 1L, 1);

                    b.Property<string>("MessageDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoticeBoardId");

                    b.ToTable("NoticeBoards");
                });

            modelBuilder.Entity("Caretaker.Shared.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonCategoryId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("GenderId");

                    b.HasIndex("PersonCategoryId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Caretaker.Shared.PersonCategory", b =>
                {
                    b.Property<int>("PersonCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonCategoryId"), 1L, 1);

                    b.Property<string>("CategoryDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonCategoryId");

                    b.ToTable("PersonCategories");
                });

            modelBuilder.Entity("Caretaker.Shared.TransactionDetail", b =>
                {
                    b.Property<int>("TransactionDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionDetailId"), 1L, 1);

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("TransactionDetailId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("Caretaker.Shared.Apartment", b =>
                {
                    b.HasOne("Caretaker.Shared.ApartmentType", "ApartmentType")
                        .WithMany()
                        .HasForeignKey("ApartmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Caretaker.Shared.BillingCategory", "BillingCategory")
                        .WithMany()
                        .HasForeignKey("BillingCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Caretaker.Shared.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApartmentType");

                    b.Navigation("BillingCategory");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Caretaker.Shared.Person", b =>
                {
                    b.HasOne("Caretaker.Shared.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Caretaker.Shared.PersonCategory", "PersonCategory")
                        .WithMany()
                        .HasForeignKey("PersonCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("PersonCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
