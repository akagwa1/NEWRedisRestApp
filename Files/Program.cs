using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Threading;

namespace RestClientIndexer
{
     class Program  
{
       
    static void Main(string[] args)  
    {
        while (true)
        {
            TimeSpan sleepTime = new TimeSpan(0, 0, 10);
            try
            {
                var program = new Program();
                ElasticSearch elasticSearch = new ElasticSearch();

                elasticSearch.elasticSearch();

                Console.WriteLine("Saving A Name In Memory");
                program.SaveBigData();

                Console.WriteLine("Reading Name from cache");
                program.ReadData();

                Thread.Sleep(sleepTime);
               
            }catch(Exception ex){}
        }
    }  
  
    public void ReadData()  
    {  
        var cache = RedisConnector.Connection.GetDatabase();  
        
        var value = cache.StringGet("Names:{i}");  
       
    }  
  
    public void SaveBigData()  
    {  
        
        var value ="Andrew Kagwa";  
        var cache = RedisConnector.Connection.GetDatabase();  
        cache.StringSet("Names:{i}", value);  
            
         
    }  
}
}
