using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace aspnetapi.Data
{
    public class StocksRepository
    {
        internal async static Task<List<Stock>> GetStocksAsync()
        {
            using (IDBContext db = DBContexFactory.GetContext())
            {
                return await db.Stocks.ToListAsync();
            }
        }

        internal async static Task<Stock> GetStockByIdAsync(int stockId)
        {
            using (var db=new StockContextDB())
            {
                return await db.Stocks.FirstOrDefaultAsync(stock => stock.StockId == stockId);
            }
        }

        internal async static Task<bool> CreateStockAsync(Stock stockToCreate)
        {
            using(var db=new StockContextDB())
                try
                {
                    await db.Stocks.AddAsync(stockToCreate);
                    return await db.SaveChangesAsync()>=1;
                }
                catch(Exception e)
                {
                    return false;
                }
        }
        internal async static Task<bool> UpdateStockAsync(Stock stockToUpdate)
        {
            using (var db = new StockContextDB())
                try
                {
                    db.Stocks.Update(stockToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
        }
        internal async static Task<bool> DeleteStockAsync(int stockId)
        {
            using (var db = new StockContextDB())
                try
                {
                    Stock stockToDelete = await GetStockByIdAsync(stockId);
                    db.Remove(stockToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
        }
    }
}
