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

                UpsertContact(client, new Contacts(1,"Andrew Kagwa", "Uganda"));
                Console.WriteLine("Indexing Successfull");
            }
            else
            {

            }



            Console.ReadKey();

            QueryContainer query = new TermQuery
            {
                Field = "Name",
                Value = "Andrew",
                 
                
            };

            var searchReq = new SearchRequest
            {

                From = 0,
                Size = 10,
                Query = query,
            };

            var result = client.Search<Contacts>(searchReq);



        }

       

        public class Contacts
        {
            public int id { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public Contacts(int Id, string Name, string Country)
            {
                id = Id; name = Name; country = Country;
            }
        }

     
        public static void UpsertContact(ElasticClient client, Contacts contact)
        {
            var RecordInserted = client.Index(contact);
            

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