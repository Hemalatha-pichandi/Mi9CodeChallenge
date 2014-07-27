using Mi9CodeChallenge.Models;
using System.Collections.Generic;
using System.Web.Http;

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