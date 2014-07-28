using Mi9CodeChallenge.Models;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net;


using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System;

namespace Mi9CodeChallenge.Controllers
{
    public class PayloadController : ApiController
    {
        public string Get(string Name)
        {
            return "Welcome " + Name;
        }

        [Route("")]
        public IHttpActionResult Post(InputPayloadRoot inputPayload)
        {
            try
            {
                List<PayloadInfo> payloadInfos = new List<PayloadInfo>();

                PayloadBL payloadBL = new PayloadBL();
                if (payloadBL.ValidateData(inputPayload))
                {
                    payloadInfos = payloadBL.QueryData(inputPayload);
                    return Ok(payloadInfos);
                }
                else
                    return new ErrorResult("{\"Error\":\"Could not decode request: JSON parsing failed\"}", Request);
                //return BadRequest("Could not decode request: JSON parsing failed");
            }
            catch (Exception ex)
            {
                return new ErrorResult("{\"Error\":\"Could not decode request: JSON parsing failed\"}", Request);
                //return BadRequest("Could not decode request: JSON parsing failed");
            }
        }
    }
}