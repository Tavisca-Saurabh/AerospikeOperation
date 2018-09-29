using Aerospike.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AerospikeWebApi.DataAccess
{
    public class DeleteDataFromAerospike
    {
        public static bool DeleteDataByID(long id)
        {
            try
            {
                var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string setName = "Saurabh";
                aerospikeClient.Delete(new WritePolicy(), new Key(nameSpace, setName, id.ToString()));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}