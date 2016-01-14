using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientIndexer
{
    public class RedisConnector
    {
         static RedisConnector()
        {
            RedisConnector.lazyConnection = new  Lazy<RedisConnector>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");

            });  


             
    }

         private static Lazy<ConnectionMultiplexer> lazyConnection;

         public static ConnectionMultiplexer Connection  
    {  
        get  
        {  
            return lazyConnection.Value;  
        }  
    }  
    }
}
