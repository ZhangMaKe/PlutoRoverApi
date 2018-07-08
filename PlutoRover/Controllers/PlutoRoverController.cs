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
        IPlutoRover _plutoRover;
        public PlutoRoverController(IPlutoRover plutoRover)
        {
            _plutoRover = plutoRover;
        }
        //POST api/plutorover
        public void MoveRover([FromBody]char[] moveCommands)
        {
            
        }
    }
}
