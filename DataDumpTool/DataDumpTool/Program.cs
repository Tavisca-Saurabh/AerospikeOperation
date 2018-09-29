using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerospike.Client;
using Microsoft.VisualBasic.FileIO;

namespace DataDumpTool
{
    class Program
    {
        static void Main(string[] args)
        {
            DumpData();
        }
        public static void DataStoreInAerospike(string[] fields)
        {
            // Establish connection the server
            AerospikeClient aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
            string nameSpace = "AirEngine";
            string setName = "Saurabh";

            var key = new Key(nameSpace, setName, fields[15]);

            aerospikeClient.Put(new WritePolicy(), key, new Bin[] { new Bin("author",fields[0]), new Bin("content", fields[1]), new Bin("region",fields[2]), new Bin("language", fields[3]),
                       new Bin("tweet_date",fields[4]),new Bin("tweet_time",fields[5]),new Bin("year",fields[6]),new Bin("month",fields[7]),new Bin("hour",fields[8]),new Bin("minutes",fields[9]),new Bin("following",fields[10]),new Bin("followers",fields[11]),new Bin("post_url",fields[12]),
                        new Bin("post_type",fields[13]),new Bin("retweet",fields[14]),new Bin("tweet_id",fields[15]),new Bin("author_id",fields[16]),new Bin("Category",fields[17]),new Bin("june_data",fields[18])});
        }
        public static void DumpData()
        {
            var path = @"C:\Users\smanchanda\Downloads\2018-08-charlottesville-twitter-trolls-master\data\tweets1.csv";
            var reader = new StreamReader(File.OpenRead(path));
            List<string> Data = new List<string>();
            List<string> Header = new List<string>();
            int entry = 0;
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                while (!csvParser.EndOfData && entry != 20000)
                {
                    string[] fields = csvParser.ReadFields();
                    DataStoreInAerospike(fields);
                    entry++;
                }
            }
        }
    }
}
