using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace In_Mgmt.Models
{
    public class In_MgmtContext : DbContext
    {
        public DbSet<Container> Containers { get; set; }
        public DbSet<UOM> UOMs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UOM_Type> UOM_Types { get; set; }
        public DbSet<KPI> KPIs { get; set; }
        public DbSet<Item> Items { get; set; }
        
        public DbSet<ConsumptionUOM> ConsumptionUOMs { get; set; }
        public DbSet<InventoryUOM> InventoryUOMs { get; set; }
        public DbSet<StoredUOM> StoredUOMs { get; set; }
        public DbSet<DisplayUOM> DisplayUOMs { get; set; }
                

        // many to many
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KPI>()
                        .HasMany<Container>(k => k.Containers)
                        .WithMany(m => m.KPIs)
                        .Map(m =>
                        {
                            m.MapLeftKey("ContainerID");
                            m.MapRightKey("KPIID");
                            m.ToTable("ContainerKPI");
                        });
        }

    }


}