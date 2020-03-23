using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using RestSharp;
using SDETApiTest.DomainObjects;

namespace SDETApiTest.Configuration
{
    public sealed class TestContext
    {
        public string ApiUrlHostName { get; set; }

        public RestClient ApiClient { get; set; }

        public RestRequest ApiRequest { get; set; }

        public IRestResponse ApiResponse { get; set; }

        public Dictionary<string, string> TestParameters { get; set; }

        public List<CarInfo> CarsRepository { get; set; }
    }
}
