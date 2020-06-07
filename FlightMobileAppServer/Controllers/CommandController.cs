using FlightMobileAppServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlightMobileAppServer.Controllers
{
    public class CommandController : ApiController
    {
        private FlightGear flightGear = new FlightGear();
        private static Command commandManager = new Command();
        // GET: api/Command
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Command/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Command
        public void Post([FromBody]Command value)
        {
            commandManager.SetValuesFromPost(value);
            // Call the methood that will update the values and update the flightGear.
            flightGear.setValues(value);
            if (!flightGear.checkSuccessInPost(value))
            {
                //return "Dont success".
            }

        }

        // PUT: api/Command/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Command/5
        public void Delete(int id)
        {
        }
    }
}
