using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Mi9CodeChallenge.Models;

namespace Mi9CodeChallenge.Controllers
{
    public class PayloadController : ApiController
    {
        public IHttpActionResult Post(InputPayloadRoot inputPayload)
        {
            List<PayloadInfo> payloadInfos = new List<PayloadInfo>();
            
            PayloadBL payloadBL = new PayloadBL();
            if (payloadBL.ValidateData(inputPayload))
            {
                payloadInfos = payloadBL.QueryData(inputPayload);
                return Ok(payloadInfos);
            }
            else
                return BadRequest("Could not decode request: JSON parsing failed");
           
        }
    }
}