using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlutoRover.Controllers
{
    public class PlutoRoverController : ApiController
    {
        //POST api/plutorover
        public void MoveRover([FromBody]string[] moveCommands)
        {
            
        }
    }
}
