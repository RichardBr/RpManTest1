using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RpMan.Domain.Entities;
using RpMan.Persistence.Infrastructure;

namespace RpMan.Persistence
{
    public class RpManInitializer
    {
        private readonly Dictionary<int, Tenant> Tenants = new Dictionary<int, Tenant>();
        private readonly Dictionary<int, Landlord> Landlords = new Dictionary<int, Landlord>();


        public static void Initialize(RpManDbContext context)
        {
            var initializer = new RpManInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(RpManDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tenants.Any())
            {
                return; // Db has been seeded
            }

            SeedTenants(context);
            SeedLandlords(context);
        }

        private void SeedTenants(RpManDbContext context)
        {
            int startId = 1;
            int endId = 10;

            var tenantList = new List<Tenant>();
            for (int i = startId; i <= endId; i++)
            {
                var rec = new Tenant { Id = i, Firstname = "Trevor"+i, Middlenames = "Tenant"+i, Lastname = "Tanner"+i };
                tenantList.Add(rec);
            }

            context.Tenants.AddRange(tenantList);

            saveChangesWithIdentityInsertOn(context, "Tenants");
        }

        private void SeedLandlords(RpManDbContext context)
        {
            var Landlords = new[]
            {
                new Landlord {Id = 1, Firstname = "Lenny1", Middlenames="Landlord1", Lastname = "Littlewood1"},
                new Landlord {Id = 2, Firstname = "Lenny2", Middlenames="Landlord2", Lastname = "Littlewood2"},
                new Landlord {Id = 3, Firstname = "Lenny3", Middlenames="Landlord3", Lastname = "Littlewood3"},
                new Landlord {Id = 4, Firstname = "Lenny4", Middlenames="Landlord4", Lastname = "Littlewood4"},
                new Landlord {Id = 5, Firstname = "Lenny5", Middlenames="Landlord5", Lastname = "Littlewood5"},
                new Landlord {Id = 6, Firstname = "Lenny6", Middlenames="Landlord6", Lastname = "Littlewood6"},
                new Landlord {Id = 7, Firstname = "Lenny7", Middlenames="Landlord7", Lastname = "Littlewood7"},
                new Landlord {Id = 8, Firstname = "Lenny8", Middlenames="Landlord8", Lastname = "Littlewood8"},
                new Landlord {Id = 9, Firstname = "Lenny9", Middlenames="Landlord9", Lastname = "Littlewood9"},
                new Landlord {Id = 10, Firstname = "Lenny10", Middlenames="Landlord10", Lastname = "Littlewood10"}
            };

            context.Landlords.AddRange(Landlords);

            saveChangesWithIdentityInsertOn(context, "Landlords");   // context.SaveChanges();
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
