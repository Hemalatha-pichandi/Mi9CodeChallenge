using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public List<PayloadInfo> QueryData(InputPayloadRoot inputPayload)
        {
            var result = inputPayload.payload
                .Where(p => p.drm && p.episodeCount > 0)
                .Select(r => new PayloadInfo
                {
                    image = r.image == null ? null : r.image.showImage,
                    slug = r.slug,
                    title = r.title
                });

            return result.ToList();
        }
    }
}