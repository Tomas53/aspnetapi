using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;

namespace aspnetapi.Data
{
    public interface IDBContext : ICurrentDbContext, IDisposable
    {
        DbSet<Stock> Stocks { get; set; }
    }
}
