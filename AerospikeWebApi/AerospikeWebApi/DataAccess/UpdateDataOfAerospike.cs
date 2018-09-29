using Aerospike.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AerospikeWebApi.DataAccess
{
    public class UpdateDataOfAerospike
    {
        public static bool UpdateDataByID(long id,string Content)
        {
            try
            {
                var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string setName = "Saurabh";
                aerospikeClient.Put(new WritePolicy(), new Key(nameSpace, setName, id.ToString()), new Bin[] { new Bin("content", Content) });
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}