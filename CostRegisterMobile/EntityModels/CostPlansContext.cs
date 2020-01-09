using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Xamarin.Forms;

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
                string sqlitePath;
                if (Device.RuntimePlatform.Equals(Device.Android))
                {
                    sqlitePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                }
                else if (Device.RuntimePlatform.Equals(Device.iOS))
                {
                    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    sqlitePath = Path.Combine(documentsPath, "..", "Library");
                }
                else
                {
                    sqlitePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                }

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
              new Category { CategoryID = 1, CategoryName = "Rezsi" },
              new Category { CategoryID = 2, CategoryName = "Lakbér" },
              new Category { CategoryID = 3, CategoryName = "Háztartás és élelmiszer" },
              new Category { CategoryID = 4, CategoryName = "Ruházat" },
              new Category { CategoryID = 5, CategoryName = "Sport" },
              new Category { CategoryID = 6, CategoryName = "Hobbik" },
              new Category { CategoryID = 7, CategoryName = "Egészségügyi" },
              new Category { CategoryID = 8, CategoryName = "Háztartási gépek és karbantartás" },
              new Category { CategoryID = 9, CategoryName = "Extra" },
              new Category { CategoryID = 10, CategoryName = "Egyéb" });

            modelBuilder.Entity<Shops>().HasData(
              new Shops { ShopID = 1, ShopName = "Lidl" },
              new Shops { ShopID = 2, ShopName = "Aldi" },
              new Shops { ShopID = 3, ShopName = "Penny Market" },
              new Shops { ShopID = 4, ShopName = "Reál" },
              new Shops { ShopID = 5, ShopName = "Tesco" },
              new Shops { ShopID = 6, ShopName = "Auchan" },
              new Shops { ShopID = 7, ShopName = "CBA" },
              new Shops { ShopID = 8, ShopName = "COOP" },
              new Shops { ShopID = 9, ShopName = "Decathlon" },
              new Shops { ShopID = 10, ShopName = "Obi" },
              new Shops { ShopID = 11, ShopName = "IKEA" },
              new Shops { ShopID = 12, ShopName = "KIKA" },
              new Shops { ShopID = 13, ShopName = "Praktiker" },
              new Shops { ShopID = 14, ShopName = "DM" },
              new Shops { ShopID = 15, ShopName = "Rossmann" },
              new Shops { ShopID = 16, ShopName = "Fressnapf" },
              new Shops { ShopID = 17, ShopName = "Bershka" },
              new Shops { ShopID = 18, ShopName = "New Yorker" },
              new Shops { ShopID = 19, ShopName = "C&A" },
              new Shops { ShopID = 20, ShopName = "Egyéb/nem üzlet" });

            modelBuilder.Entity<Settings>().HasData(
             new Settings { ID = 1, SettingType = "IncludePlans", SettingMode = 1 });
        }
    }
}
