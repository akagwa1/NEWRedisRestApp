using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nest;
using Nest.Domain;
using Nest.SerializationExtensions;

namespace RestClientIndexer
{
    public class ElasticSearch
    {
       
        public void elasticSearch() {


            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri).SetDefaultIndex("contacts");
            var client = new ElasticClient(settings);

            if (client.IndexExists("contacts").Exists)
            {

                UpsertContact(client, new Contacts("Andrew Kagwa", "Uganda"), "contacts", "contacts", 2);
                Console.WriteLine("Indexing Successfull");
            }
            else
            {

            }



            Console.ReadKey();
        
        
        }

       

        public class Contacts
        {
            public string name { get; set; }
            public string country { get; set; }
            public Contacts(string Name, string Country)
            {
                name = Name; country = Country;
            }
        }

     
        public static void UpsertContact(ElasticClient client, Contacts contact, string index, string type, int id)
        {
            var RecordInserted = client.Index(contact, index, type, id).Id;
            

            if (RecordInserted.ToString() != "")
            {
                Console.WriteLine("Indexing Successful !");
            }
            else
            {
                Console.WriteLine("Transaction Failed");
            }
        }
    }
}