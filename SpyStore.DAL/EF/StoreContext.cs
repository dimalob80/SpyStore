using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyStore.DAL.EF
{
    public class StoreContext: DbContext
    {
        public StoreContext()
        {

        }
        public StoreContext(DbContextOptions options) :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source = DESKTOP - V0ME6CC; Initial Catalog = SpyStore; Integrated Security = True",
                    //options=>options.EnableRetryOnFailure()); //-default connection strategy
                    options => options.ExecutionStrategy(c => new MyExecutionStrategy(c))); // - custom connection strategy
                    //Data Source = DESKTOP - V0ME6CC; Initial Catalog = SpyStore; Integrated Security = True

            }
        }
    }
}
