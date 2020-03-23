using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using SDETApiTest.Configuration;
using SDETApiTest.DomainObjects;
using SDETApiTest.Utils;
using TechTalk.SpecFlow;
using Utf8Json.Resolvers;


namespace SDETApiTest.Hooks
{
    [Binding]
    public sealed class ApiClientSetup
    {
        [BeforeTestRun(Order = 0)]
        public static void OneTimeApiSetup(TestContext testContext)
        {
            testContext.TestParameters = JsonFileReader<Dictionary<string,string>>.LoadJson("testParameters.json");
            testContext.CarsRepository= JsonFileReader<List<CarInfo>>.LoadJson("TestData\\CarsRepository.json");
            testContext.ApiUrlHostName = testContext.TestParameters["apiHostName"];
            testContext.ApiClient = new RestClient(testContext.ApiUrlHostName);
        }
    }
}
