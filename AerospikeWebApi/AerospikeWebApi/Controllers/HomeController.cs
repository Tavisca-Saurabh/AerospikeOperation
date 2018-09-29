using Aerospike.Client;
using AerospikeWebApi.DataAccess;
using AerospikeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Aerospike.Client.AsyncQueryValidate;

namespace AerospikeWebApi.Controllers
{
    public class HomeController : ApiController
    {

        [HttpPost]
        public List<Tweet> Get([FromBody] List<long> tweetId)
        {
            GetDataFromAerospike GetObject = new GetDataFromAerospike();
            List<Tweet> Data = GetObject.GetDataFromMultipleIDs(tweetId);
            if (Data.Count!=0)
            {
                return Data;
            }
            return null;
        }

        // PUT: api/Home/5
        [HttpPut]
        public IHttpActionResult Put([FromUri]long id, [FromBody]string content)
        {
            var isTrue = UpdateDataOfAerospike.UpdateDataByID(id, content);
            if (isTrue)
            {
                return Ok("Update Successfull");
            }
            return BadRequest("Due to some technical issue we cann't update it");
        }

        // DELETE: api/Home/5
        public IHttpActionResult Delete(long id)
        {
            var isTrue = DeleteDataFromAerospike.DeleteDataByID(id);
            if (isTrue)
            {
                return Ok("Delete Successfull");
            }
            return BadRequest("Due to some technical issue we cann't update it");
        }
    }
}
