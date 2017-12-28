﻿// <auto-generated />
using AuBoulot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AuBoulot.Web.Migrations
{
    [DbContext(typeof(AuBoulotContext))]
    partial class AuBoulotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuBoulot.Web.Models.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActualDateTime");

                    b.Property<int?>("Direction");

                    b.Property<int?>("Duration");

                    b.Property<DateTime>("EstimatedDateTime");

                    b.Property<Guid>("JobOpportunityId");

                    b.Property<Guid?>("NextActivityId");

                    b.Property<string>("Notes");

                    b.Property<int?>("Rating");

                    b.Property<int>("State");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("JobOpportunityId");

                    b.HasIndex("NextActivityId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("AuBoulot.Web.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AuBoulot.Web.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("FullName")
                        .HasMaxLength(200);

                    b.Property<string>("SimpleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("AuBoulot.Web.Models.JobOpportunity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("MaxSalary");

                    b.Property<int?>("MinSalary");

                    b.Property<Guid>("ParentCompanyId");

                    b.Property<int?>("Rating");

                    b.Property<string>("Source");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("WorkAddressId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCompanyId");

                    b.HasIndex("WorkAddressId");

                    b.ToTable("JobOpportunity");
                });

            modelBuilder.Entity("AuBoulot.Web.Models.Activity", b =>
                {
                    b.HasOne("AuBoulot.Web.Models.JobOpportunity", "JobOpportunity")
                        .WithMany("ActivityList")
                        .HasForeignKey("JobOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AuBoulot.Web.Models.Activity", "NextActivity")
                        .WithMany()
                        .HasForeignKey("NextActivityId");
                });

            modelBuilder.Entity("AuBoulot.Web.Models.JobOpportunity", b =>
                {
                    b.HasOne("AuBoulot.Web.Models.Company", "ParentCompany")
                        .WithMany("JobOpportunityList")
                        .HasForeignKey("ParentCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AuBoulot.Web.Models.Address", "WorkAddress")
                        .WithMany()
                        .HasForeignKey("WorkAddressId");
                });
#pragma warning restore 612, 618
        }
    }
}
