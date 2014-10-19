using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Common.Contracts;
using TradingSystem.Business.Entities;
using System.Runtime.Serialization;
namespace TradingSystem.Data
{
    public class TradingSystemContext : DbContext
    {
        public TradingSystemContext() : base("name=TradingSystem")
        {
            Database.SetInitializer<TradingSystemContext>(null);
        }

        // one per table

        public DbSet<Order> OrderSet { get; set; }
        public DbSet<OrderRequest> OrderRequestSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Order>().HasKey<int>(e => e.OrderId).Ignore(e => e.EntityId);
            modelBuilder.Entity<OrderRequest>().HasKey<int>(e => e.OrderRequestId).Ignore(e => e.EntityId); 

            base.OnModelCreating(modelBuilder);

            // ignore properties which should not be part of database ops.
            // note explicit interface member implementations are not stored by ef.

        }
    }
}
