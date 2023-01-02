namespace StockManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            StockManager manager = new StockManager();
            string stockfilepath = @"E:\C#\StockManagement\StockMangaement\Stock.json";
            string customerfilepath = @"E:\C#\StockManagement\StockMangaement\Customer.json";
            manager.ReadStockJsonFile(stockfilepath);
            manager.ReadCustomerJasonFile(customerfilepath);
            //manager.BuyStock("Dmart");
            manager.SellStock("BridgeLabz");
            manager.WriteToStockJsonFile(stockfilepath);
            manager.WriteToCustomerJsonFile(customerfilepath);
            
        }
    }
}
