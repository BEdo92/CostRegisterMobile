using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CostRegisterMobile.EntityModels
{
    public class CostPlansContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<PlanCost> PlanCosts { get; set; }
        public DbSet<Costs> Costs { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Settings> Settings { get; set; }

        public string ConnectionString
        {
            get
            {
                var sqlitePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var dataBaseName = "CostPlans.db";
                return $"Data Source={Path.Combine(sqlitePath, dataBaseName)}";
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
              new Category { CategoryID = 1, CategoryName = AppResources.Overhead },
              new Category { CategoryID = 2, CategoryName = AppResources.Rental },
              new Category { CategoryID = 3, CategoryName = AppResources.FoodAndOtherHousehold },
              new Category { CategoryID = 4, CategoryName = AppResources.Clothes },
              new Category { CategoryID = 5, CategoryName = AppResources.Sports },
              new Category { CategoryID = 6, CategoryName = AppResources.Hobbies },
              new Category { CategoryID = 7, CategoryName = AppResources.Health },
              new Category { CategoryID = 8, CategoryName = AppResources.HouseholdAppliancesAndMaintenance },
              new Category { CategoryID = 9, CategoryName = AppResources.Extra },
              new Category { CategoryID = 10, CategoryName = AppResources.Others });

            modelBuilder.Entity<Shops>().HasData(
              new Shops { ShopID = 1, ShopName = AppResources.ShopAldi },
              new Shops { ShopID = 2, ShopName = AppResources.ShopAuch },
              new Shops { ShopID = 3, ShopName = AppResources.ShopBersh },
              new Shops { ShopID = 4, ShopName = AppResources.ShopCA },
              new Shops { ShopID = 5, ShopName = AppResources.ShopCoop },
              new Shops { ShopID = 6, ShopName = AppResources.ShopDM },
              new Shops { ShopID = 7, ShopName = AppResources.ShopLidl },
              new Shops { ShopID = 8, ShopName = AppResources.ShopMM },
              new Shops { ShopID = 9, ShopName = AppResources.ShopPenny },
              new Shops { ShopID = 10, ShopName = AppResources.ShopRM },
              new Shops { ShopID = 11, ShopName = AppResources.ShopTesc },
              new Shops { ShopID = 12, ShopName = AppResources.CostNotInShop });

            modelBuilder.Entity<Settings>().HasData(
             new Settings { ID = 1, SettingType = "IncludePlans", SettingMode = 1 });
        }
    }
}
