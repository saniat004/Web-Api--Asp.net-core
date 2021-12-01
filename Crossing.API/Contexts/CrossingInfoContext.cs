using Crossing.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crossing.API.Contexts
{
    public class CrossingInfoContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<BorderGates> BorderGates { get; set; }

        public CrossingInfoContext(DbContextOptions<CrossingInfoContext> options)
           : base(options)
        {
            //  Database.EnsureCreated();
        }


        //seeding datas to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                 .HasData(
                new Country()
                {
                    Id = 1,
                    Name = "CAN",

                },
                new Country()
                {
                    Id = 2,
                    Name = "USA",
                },
                new Country()
                {
                    Id = 3,
                    Name = "MEX"
                },
                new Country()
                {
                    Id = 4,
                    Name = "BLZ",
                },
                new Country()
                {
                    Id = 5,
                    Name = "GTM",
                },
                new Country()
                {
                    Id = 6,
                    Name = "SLV",
                },
                new Country()
                {
                    Id = 7,
                    Name = "HND",
                },
                new Country()
                {
                    Id = 8,
                    Name = "NIC",
                },
                new Country()
                {
                    Id = 9,
                    Name = "CRI",
                },
                new Country()
                {
                    Id = 10,
                    Name = "PAN",
                }

                );


            modelBuilder.Entity<BorderGates>()
              .HasData(
                new BorderGates()
                {

                    CountryId = 1,
                    Destination = "CAN",
                    List = "[USA]"

                },

                new BorderGates()
                {

                    CountryId = 2,
                    Destination = "USA",
                    List = "[CAN]"

                },
                 new BorderGates()
                 {

                     CountryId = 3,
                     Destination = "MEX",
                     List = "[USA]"

                 },
                  new BorderGates()
                  {

                      CountryId = 4,
                      Destination = "BLZ",
                      List = "[USA , MEX , BLZ ]"

                  },
                   new BorderGates()
                   {

                       CountryId = 5,
                       Destination = "GTM",
                       List = "[USA , MEX , GTM ]"

                   },
                    new BorderGates()
                    {

                        CountryId = 6,
                        Destination = "SLV",
                        List = "[USA , MEX , GTM , SLV ]"

                    },
                     new BorderGates()
                     {

                         CountryId = 7,
                         Destination = "HND",
                         List = "[USA , MEX , GTM , HND ]"

                     },
                      new BorderGates()
                      {

                          CountryId = 8,
                          Destination = "NIC",
                          List = "[USA , MEX , GTM , HND , NIC ]"

                      },
                       new BorderGates()
                       {

                           CountryId = 9,
                           Destination = "CRI",
                           List = "[ USA ,MEX , GTM , HND , NIC , CRI ]"

                       },
                        new BorderGates()
                        {

                            CountryId = 10,
                            Destination = "PAN",
                            List = "[ USA ,MEX , GTM , HND , NIC , CRI , PAN ]"

                        }



                );

            base.OnModelCreating(modelBuilder);
        }



    }
}
