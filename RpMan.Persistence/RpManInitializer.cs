using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RpMan.Domain.Entities;
using RpMan.Persistence.Infrastructure;

namespace RpMan.Persistence
{
    public class RpManInitializer
    {
        private readonly Dictionary<int, Property> _properties = new Dictionary<int, Property>();


        public static void Initialize(RpManDbContext context)
        {
            var initializer = new RpManInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(RpManDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tenants.Any())
                return; // Db has been seeded

            SeedProperties(context);
            SeedLandlords(context);
            SeedTenants(context);
            SeedTenancyAgreements(context);
        }

        private void SeedProperties(RpManDbContext context)
        {
            var startId = 1;
            var endId = 10;

            for (var i = startId; i <= endId; i++)
            {
                var rec = new Property {Id = i, AddressLine1 = i + " Easterly Road", AddressLine2 = "Roundhay"};
                _properties.Add(i, rec);
            }

            foreach (var property in _properties.Values)
                context.Properties.Add(property);

            saveChangesWithIdentityInsertOn(context, "Properties");
        }

        private void SeedLandlords(RpManDbContext context)
        {
            var Landlords = new[]
            {
                new Landlord {Id = 1, Firstname = "Lenny1", Middlenames = "Landlord1", Lastname = "Littlewood1"},
                new Landlord {Id = 2, Firstname = "Lenny2", Middlenames = "Landlord2", Lastname = "Littlewood2"},
                new Landlord {Id = 3, Firstname = "Lenny3", Middlenames = "Landlord3", Lastname = "Littlewood3"},
                new Landlord {Id = 4, Firstname = "Lenny4", Middlenames = "Landlord4", Lastname = "Littlewood4"},
                new Landlord {Id = 5, Firstname = "Lenny5", Middlenames = "Landlord5", Lastname = "Littlewood5"},
            };

            context.Landlords.AddRange(Landlords);

            saveChangesWithIdentityInsertOn(context, "Landlords"); // context.SaveChanges();
        }

        private void SeedTenants(RpManDbContext context)
        {
            var startId = 1;
            var endId = 10;

            var tenantList = new List<Tenant>();
            for (var i = startId; i <= endId; i++)
            {
                var rec = new Tenant
                {
                    Id = i,
                    Firstname = "Trevor" + i,
                    Middlenames = "Tenant" + i,
                    Lastname = "Tanner" + i
                };
                tenantList.Add(rec);
            }

            context.Tenants.AddRange(tenantList);

            saveChangesWithIdentityInsertOn(context, "Tenants");
        }

        private void SeedTenancyAgreements(RpManDbContext context)
        {
            var ta = new List<TenancyAgreement>();

            ta.Add(new TenancyAgreement
                {
                    Id = 1,
                    // Property = _properties[1]
                    PropertyId = 1
                }
                .AddTenantsTenancyAgreements(
                    new TenantsTenancyAgreement {TenantId = 1}
                )
                .AddLandlordsTenancyAgreements( new LandlordsTenancyAgreement() { LandlordId = 1 })
                );
            ta.Add(new TenancyAgreement
                {
                    Id = 2,
                // Property = _properties[2]
                    PropertyId = 2
            }
                .AddTenantsTenancyAgreements(
                    new TenantsTenancyAgreement {TenantId = 2},
                    new TenantsTenancyAgreement {TenantId = 3}
                )
                .AddLandlordsTenancyAgreements(new LandlordsTenancyAgreement() { LandlordId = 1 })
                );
            ta.Add(new TenancyAgreement
                {
                    Id = 3,
                // Property = _properties[3]
                    PropertyId = 3
            }
                .AddTenantsTenancyAgreements(
                    new TenantsTenancyAgreement { TenantId = 4 },
                    new TenantsTenancyAgreement { TenantId = 5 },
                    new TenantsTenancyAgreement { TenantId = 6 }
                )
                .AddLandlordsTenancyAgreements(new LandlordsTenancyAgreement() { LandlordId = 2 })
                );

            context.TenancyAgreements.AddRange(ta);
            saveChangesWithIdentityInsertOn(context, "TenancyAgreements");
        }

        private void saveChangesWithIdentityInsertOn(RpManDbContext context, string tablename)
        {
            context.Database.BeginTransaction();

            var sql = $"SET IDENTITY_INSERT {tablename} ON;";
            context.Database.ExecuteSqlCommand(sql);

            context.SaveChanges();

            sql = $"SET IDENTITY_INSERT {tablename} OFF;";
            context.Database.ExecuteSqlCommand(sql);

            context.Database.CommitTransaction();
        }
    }
}