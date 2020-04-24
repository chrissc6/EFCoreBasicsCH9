using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreBasicsCH9.EfStructures
{
    //Design time factory "Only used in development"
    //Used for design and demo
    public class AwDbContextFactory : IDesignTimeDbContextFactory<AwDbContext>
    {
        //This is used during mirgrations
        //Only meant to used in design
        public AwDbContext CreateDbContext(string[] args)
        {
            //ContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<AwDbContext>();

            //connectionString & what provider to use "UseSqlServer"
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=Adventureworks2016;Trusted_Connection=true;";
            optionsBuilder
                .UseSqlServer(connectionString, options => options.EnableRetryOnFailure());

            //Console.WriteLine(connectionString);

            //then create a new instance of the dbcontext
            return new AwDbContext(optionsBuilder.Options);
        }
    }
}
