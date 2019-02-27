﻿// <auto-generated />
using System;
using DluznicyAPI.DAL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DluznicyAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DluznicyAPI.DAL.DAO.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("HouseNum");

                    b.Property<int>("PostCode");

                    b.Property<string>("Street");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DluznicyAPI.DAL.DAO.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Name");

                    b.HasKey("CompanyId");

                    b.HasIndex("AddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DluznicyAPI.DAL.DAO.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsEmployed");

                    b.Property<bool>("LendOnlyToEmployed");

                    b.Property<int>("MaxAmountOfMoney");

                    b.Property<int>("MoneyToBorrow");

                    b.Property<int>("MoneyToLend");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<bool>("RequiresAddress");

                    b.Property<string>("Surname");

                    b.Property<int>("WaitingTime");

                    b.HasKey("PersonID");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DluznicyAPI.DAL.DAO.Company", b =>
                {
                    b.HasOne("DluznicyAPI.DAL.DAO.Address", "Address")
                        .WithMany("Companies")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DluznicyAPI.DAL.DAO.Person", b =>
                {
                    b.HasOne("DluznicyAPI.DAL.DAO.Address", "Address")
                        .WithMany("Persons")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DluznicyAPI.DAL.DAO.Company", "Company")
                        .WithMany("Persons")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}