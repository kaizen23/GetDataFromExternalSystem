//namespace OdataWebSerwis.Migrations
//{
//    using Models;
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<OdataWebSerwis.Models.OdataWebSerwisContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//        }

//        protected override void Seed(OdataWebSerwis.Models.OdataWebSerwisContext context)
//        {
//            //  This method will be called after migrating to the latest version.

//            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//            //  to avoid creating duplicate seed data. E.g.
//            //
//                context.Cars.AddOrUpdate(
//                  p => p.Marka,
//                  new Car { Marka = "BMW", Price = 150 },
//                  new Car { Marka = "Audi",Price = 0 },
//                  new Car { Marka = "Toyota",Price = 11 }
//                );
//            //
//        }
//    }
//}
