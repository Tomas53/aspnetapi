namespace aspnetapi.Data
{
    public class DBContexFactory
    {
        public static IDBContext GetContext()
        {
            // If (testing){ return new TestBdCOntext;
            // if (production) {
            return new StockContextDB();
        }
    }
}
