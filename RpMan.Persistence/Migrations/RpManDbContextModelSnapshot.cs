﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpMan.Persistence;

namespace RpMan.Persistence.Migrations
{
    [DbContext(typeof(RpManDbContext))]
    partial class RpManDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RpMan.Domain.Entities.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Firstname")
                        .HasMaxLength(60);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Middlenames")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Landlords");
                });

            modelBuilder.Entity("RpMan.Domain.Entities.LandlordsTenancyAgreement", b =>
                {
                    b.Property<int>("TenancyAgreementId");

                    b.Property<int>("LandlordId");

                    b.Property<string>("Dummy");

                    b.HasKey("TenancyAgreementId", "LandlordId");

                    b.HasIndex("LandlordId");

                    b.ToTable("LandlordsTenancyAgreements");
                });

            modelBuilder.Entity("RpMan.Domain.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RpMan.Domain.Entities.TenancyAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("FixedTermEndDate");

                    b.Property<int?>("PropertyId");

                    b.Property<decimal>("RentAmount");

                    b.Property<int>("RentPeriod");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("TenancyAgreements");
                });

            modelBuilder.Entity("RpMan.Domain.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Firstname")
                        .HasMaxLength(60);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Middlenames")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("RpMan.Domain.Entities.TenantsTenancyAgreement", b =>
                {
                    b.Property<int>("TenancyAgreementId");

                    b.Property<int>("TenantId");

                    b.Property<string>("Dummy")
                        .HasColumnType("char")
                        .IsFixedLength(true)
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.HasKey("TenancyAgreementId", "TenantId");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantsTenancyAgreements");
                });

            modelBuilder.Entity("RpMan.Domain.Entities.LandlordsTenancyAgreement", b =>
                {
                    b.HasOne("RpMan.Domain.Entities.Landlord")
                        .WithMany("LandlordsTenancyAgreements")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RpMan.Domain.Entities.TenancyAgreement")
                        .WithMany("LandlordsTenancyAgreements")
                        .HasForeignKey("TenancyAgreementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RpMan.Domain.Entities.TenancyAgreement", b =>
                {
                    b.HasOne("RpMan.Domain.Entities.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("RpMan.Domain.Entities.TenantsTenancyAgreement", b =>
                {
                    b.HasOne("RpMan.Domain.Entities.TenancyAgreement")
                        .WithMany("TenantsTenancyAgreements")
                        .HasForeignKey("TenancyAgreementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RpMan.Domain.Entities.Tenant")
                        .WithMany("TenantsTenancyAgreements")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
