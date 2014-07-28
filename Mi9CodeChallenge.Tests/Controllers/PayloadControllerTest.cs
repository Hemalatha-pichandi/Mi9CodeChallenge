using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mi9CodeChallenge;
using Mi9CodeChallenge.Controllers;
using System.Web.Http.Results;
using Mi9CodeChallenge.Models;
using System.Net;

namespace Mi9CodeChallenge.Tests.Controllers
{
    [TestClass]
    public class PayloadControllerTest
    {
        private PayloadController payloadController;
        [TestInitialize]
        public void InitializeTest()
        {
            payloadController = new PayloadController();
        }

        [TestMethod]
        public void PostReturn400withNull()
        {
            IHttpActionResult actionResult = payloadController.Post(null);
            //var contentResult = actionResult as NegotiatedContentResult<InputPayloadRoot>;

            Assert.IsInstanceOfType(actionResult, typeof(ErrorResult));
        }

        [TestMethod]
        public void PostReturn400withNullPayload()
        {
            IHttpActionResult actionResult = payloadController.Post(new InputPayloadRoot { payload = null });
            //var contentResult = actionResult as NegotiatedContentResult<InputPayloadRoot>;

            Assert.IsInstanceOfType(actionResult, typeof(ErrorResult));
        }

        [TestMethod]
        public void PostReturnContentwithValidPayload()
        {
            InputPayloadRoot payload = SetTestData();
            IHttpActionResult actionResult = payloadController.Post(payload);

            StatusCodeResult statusCodeResult = actionResult as StatusCodeResult;
            var negotiatedResult = actionResult as OkNegotiatedContentResult<List<PayloadInfo>>;
            Assert.IsNotNull(negotiatedResult);
            Assert.AreEqual<int>(3, negotiatedResult.Content.Count);

        }
        
        private static InputPayloadRoot SetTestData()
        {
            var input = new InputPayloadRoot();
            input.payload = new List<Payload>
            {
                new Payload { drm = false, episodeCount = 0},
                new Payload { drm = false, episodeCount = 1},
                new Payload { drm = true, episodeCount = 0}, 
                new Payload { slug="show/seapatrol", title="Sea Patrol", tvChannel="Channel 9"},               
                new Payload { country="UK", description="What's life like when you have enough children to field your own football team?", 
                    drm = true, episodeCount = 0, slug = "show/16kidsandcounting", title="16 Kids and Counting", 
                              image = new Image
                              { 
                                  showImage = "http://catchup.ninemsn.com.au/img/jump-in/shows/16KidsandCounting1280.jpg"
                              }},
                new Payload { country="USA", description="What's life like when you have enough children to field your own football team?", 
                    drm = true, episodeCount = 1, slug = "show/16kidsandcounting", title="16 Kids and Counting", 
                              image = new Image
                              { 
                                  showImage = "http://catchup.ninemsn.com.au/img/jump-in/shows/16KidsandCounting1280.jpg"
                              }},
                new Payload { slug="show/seapatrol", title="Sea Patrol"},               
                new Payload { drm = true, episodeCount = 0, slug = "show/16kidsandcounting", title="16 Kids and Counting", 
                              image = new Image
                              { 
                                  showImage = "http://catchup.ninemsn.com.au/img/jump-in/shows/16KidsandCounting1280.jpg"
                              }},
                new Payload { drm = true, episodeCount = 1, slug = "show/16kidsandcounting", title="16 Kids and Counting", 
                              image = new Image
                              { 
                                  showImage = "http://catchup.ninemsn.com.au/img/jump-in/shows/16KidsandCounting1280.jpg"
                              }},
                new Payload { drm = true, episodeCount = 5, slug = "Slug02", title="Title02", 
                              image = new Image
                              { 
                                  showImage = null
                              }},
                 new Payload { drm = true, episodeCount = 5}
            };
            return input;
        }
    }
}