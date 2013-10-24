using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DistrictCheck1
{
    [Binding]
    public class DistrictCheck1Steps
    {
        private string theUrl;
        private string _theResponse;

        [Given(@"the alteryx service is running at ""(.*)""")]

        public void GivenTheAlteryxServiceIsRunningAt(string p0)
        {
            theUrl = p0;
        }

        [When(@"I invoke the GET at ""(.*)""")]

        public void WhenIInvokeTheGETAt(string p0)
        {
            string fullUrl = theUrl + "/" + p0;
            WebRequest request = WebRequest.Create(fullUrl);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            _theResponse = responseFromServer;
        }

        [Then(@"I see at least (.*) active districts")]

        public void ThenISeeTheActiveDistricts(int expectedDistrict)
        {
            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<ArrayList>(_theResponse);
            int count = json.Count;
       
            Assert.That(count, Is.AtLeast(expectedDistrict));
            testing
        }
    }
}
