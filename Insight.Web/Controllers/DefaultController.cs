using Infra.IO;
using Infra.IO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insight.Web.Controllers
{
    public class DefaultController : ApiController
    {   
        [HttpGet]
        [Route]
        public string Get()
        {
            return "OK";
        }
    }
}
