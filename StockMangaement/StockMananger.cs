using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class StockManager
    {
        public List<StockReport> report = new List<StockReport>();
        public List<StockReport> customer = new List<StockReport>();
        int amount = 1000;
        public void ReadStockJsonFile(string filepath)
        {
            var jason=File.ReadAllText(filepath);
            this.report= JsonConvert.DeserializeObject<List<StockReport>>(jason);
            foreach(var content in report)
            {
                Console.WriteLine(content.stockName+" "+content.stockPrice+" "+content.totalShare);
            }
        }
        public void ReadCustomerJasonFile(string filepath)
        {
            var jason = File.ReadAllText(filepath);
            this.customer = JsonConvert.DeserializeObject<List<StockReport>>(jason);
            foreach (var content in report)
            {
                Console.WriteLine(content.stockName + " " + content.stockPrice + " " + content.totalShare);
            }
        }
        public void BuyStock(string name)
        {
            foreach(var data in report)
            {
                if (data.stockName.Equals(name))
                {
                    Console.WriteLine("Enter the number of Stocks to Buy");
                    int noOfStock = int.Parse(Console.ReadLine());
                    int Count = 0;
                    if(noOfStock*data.stockPrice<=amount && noOfStock <=data.totalShare)
                    {
                        StockReport stock = new StockReport();
                        {
                            stock.stockName = data.stockName;
                            stock.stockPrice = data.stockPrice;
                            stock.totalShare = data.totalShare;
                        }
                        data.totalShare -= noOfStock;
                        amount -= data.stockPrice * noOfStock;
                        foreach(var account in customer)
                        {
                            if(account.stockName.Equals(name))
                            {
                                account.totalShare += noOfStock;
                                Count++;
                            }
                        }
                        if(Count==1)
                        {
                            data.totalShare += noOfStock;
                        }
                        else
                        {
                            customer.Add(data);
                        }
                    }
                }
            }
        }

        public void WriteToStockJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(report);
            File.WriteAllText(filepath,json);
        }
        public void WriteToCustomerJsonFile(string filepath)
        {
            var json=JsonConvert.SerializeObject(customer);
            File.WriteAllText(filepath, json);
        }
        
    }
}
