using Aerospike.Client;
using AerospikeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AerospikeWebApi.DataAccess
{
    public class GetDataFromAerospike
    {
        public List<Tweet> GetDataFromMultipleIDs(List<long> tweetId)
        {
            var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
            string nameSpace = "AirEngine";
            string setName = "Saurabh";
            List<Tweet> tweetData = new List<Tweet>();
            foreach (long tid in tweetId)
            {
                Record record = aerospikeClient.Get(new BatchPolicy(), new Key(nameSpace, setName, tid.ToString()));
                Tweet tweet = new Tweet();

                tweetData.Add(tweet);

                if (record != null)
                {
                    tweet.TweetId = Convert.ToInt64(record.GetValue("tweet_id").ToString());
                    tweet.TweetDescription = record.GetValue("content").ToString();
                }
                else
                {
                    tweet.TweetId = 0;
                    tweet.TweetDescription = "Doesn't exist";
                }
            }
            return tweetData;
        }
    }
}