using System.Collections.Generic;
using System.Linq;

namespace Mi9CodeChallenge.Models
{
    public class PayloadBL
    {
        public bool ValidateData(InputPayloadRoot inputPayload)
        {
            if (inputPayload != null && inputPayload.payload != null)
            {
                return true;
            }
            return false;
        }

        //public List<PayloadInfo> QueryData(InputPayloadRoot inputPayload)
        public Response QueryData(InputPayloadRoot inputPayload)
        {
            var result = inputPayload.payload
                .Where(p => p.drm.HasValue && p.drm.Value && p.episodeCount.HasValue && p.episodeCount > 0)
                .Select(r => new PayloadInfo
                {
                    image = r.image == null ? null : r.image.showImage,
                    slug = r.slug,
                    title = r.title
                });

            var output = new Response();
            output.response = result.ToList();            
            return output;
        }
    }
}