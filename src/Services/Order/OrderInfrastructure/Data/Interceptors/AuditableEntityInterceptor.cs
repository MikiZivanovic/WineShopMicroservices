﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OrderDomain.Abstractions;

namespace OrderInfrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }


        private async Task UpdateEntities(DbContext? dbContext) {

            if (dbContext == null) {
                return;
            }

            foreach (var entry in dbContext.ChangeTracker.Entries<IEntity>()) {


                if (entry.State == EntityState.Added) { 
                    
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "miki";
                }

                if (entry.State  == EntityState.Added  || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities()) {

                    entry.Entity.LastModifiedBy = "miki";
                    entry.Entity.LastModified = DateTime.UtcNow;
                
                }
            }
        
        }
    }

    public static class Extensions
    {

        public static bool HasChangedOwnedEntities(this EntityEntry entry) => entry.References.Any(
            r => r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified)

            );


    }
}

