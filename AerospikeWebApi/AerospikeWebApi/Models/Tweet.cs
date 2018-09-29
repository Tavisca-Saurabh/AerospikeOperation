using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AerospikeWebApi.Models
{
    public class Tweet
    {
        public long TweetId { get; set; }
        public string TweetDescription { get; set; }
    }
}