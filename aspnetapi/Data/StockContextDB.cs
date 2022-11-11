using Microsoft.EntityFrameworkCore;

using System.Diagnostics.Metrics;

namespace aspnetapi.Data
{
    internal sealed class StockContextDB: DbContext, IDBContext
    {
        public DbSet<Stock> Stocks { get; set; }

        public DbContext Context => this;

        //protected override void OnConfiguring(DbContext)ss

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/ApiDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Stock[] stocksToFill = new Stock[6];
            for (int i = 1;i<=6; i++)
            {
                stocksToFill[i - 1] = new Stock
                {
                    StockId = i,
                    StockName = $"Stock {i} name",
                    Country = $"Stock {i} country",
                    Price = $"Stock {i} price",
                    Data= $"Stock {i} was bought on 2022.11.11"

                };
            }
            modelBuilder.Entity<Stock>().HasData(stocksToFill);
        }
    }
}
