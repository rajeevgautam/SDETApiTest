using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using SDETApiTest.Configuration;
using TechTalk.SpecFlow;

namespace SDETApiTest.Hooks
{
    [Binding]
    public sealed class ApiScenarioSetup
    {
        [BeforeScenario()]
        public static void BeforeApiScenario(TestContext testContext)
        {
            testContext.ApiResponse = null;
        }
    }
}
