using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RpMan.Domain.Entities;
using RpMan.Persistence.Configurations;

namespace RpMan.Persistence
{
    public class RpManDbContext : DbContext
    {
        public RpManDbContext(DbContextOptions<RpManDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<LandlordsTenancyAgreement> LandlordsTenancyAgreements { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<TenancyAgreement> TenancyAgreements { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantsTenancyAgreement> TenantsTenancyAgreements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RpManDbContext).Assembly);
        }
    }
}
