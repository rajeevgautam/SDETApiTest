using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using RestSharp;
using SDETApiTest.Configuration;
using SDETApiTest.Utils;
using TechTalk.SpecFlow;

namespace SDETApiTest.Bindings
{
    [Binding]
    class CarsApiSteps{
        private readonly TestContext _apiTestContext;

        public CarsApiSteps(TestContext apiTestContext)
        {
            _apiTestContext = apiTestContext;
        }

        [When(@"I request car information for a (.*)")]
        public void RequestCarInformationByType(string carType)
        {
            RestRequest carApiGetRequest = new RestRequest($"/api/Cars/{carType}");
            _apiTestContext.ApiResponse = _apiTestContext.ApiClient.Get(carApiGetRequest);
        }
    }
}

