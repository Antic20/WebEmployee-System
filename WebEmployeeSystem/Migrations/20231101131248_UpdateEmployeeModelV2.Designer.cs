﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebEmployeeSystem.Data;

#nullable disable

namespace WebEmployeeSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231101131248_UpdateEmployeeModelV2")]
    partial class UpdateEmployeeModelV2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebEmployeeSystem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HealthContribution")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("NetSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaySpecification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PensionContribution")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Position")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalTaxesAndContributions")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnemploymentContribution")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Address = "103rd Ave",
                            Email = "john@email.com",
                            FirstName = "John",
                            GrossSalary = 0m,
                            HealthContribution = 0m,
                            LastName = "Tenehel",
                            NetSalary = 10000m,
                            PensionContribution = 0m,
                            Position = "GM",
                            Tax = 0m,
                            TotalTaxesAndContributions = 0m,
                            UnemploymentContribution = 0m
                        },
                        new
                        {
                            EmployeeId = 2,
                            Address = "101rd Ave",
                            Email = "sarah@email.com",
                            FirstName = "Sarah",
                            GrossSalary = 0m,
                            HealthContribution = 0m,
                            LastName = "Picket",
                            NetSalary = 20000m,
                            PensionContribution = 0m,
                            Position = "CEO",
                            Tax = 0m,
                            TotalTaxesAndContributions = 0m,
                            UnemploymentContribution = 0m
                        },
                        new
                        {
                            EmployeeId = 3,
                            Address = "104rd Ave",
                            Email = "mark@email.com",
                            FirstName = "Mark",
                            GrossSalary = 0m,
                            HealthContribution = 0m,
                            LastName = "Ronson",
                            NetSalary = 30000m,
                            PensionContribution = 0m,
                            Position = "Director",
                            Tax = 0m,
                            TotalTaxesAndContributions = 0m,
                            UnemploymentContribution = 0m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
