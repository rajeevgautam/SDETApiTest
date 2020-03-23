using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestContext = SDETApiTest.Configuration.TestContext;


namespace SDETApiTest.Bindings
{
    [Binding]
    class ApiResponseValidationSteps
    {
        private readonly TestContext _apiTestContext;

        public ApiResponseValidationSteps(TestContext apiTestContext)
        {
            _apiTestContext = apiTestContext;
        }

        [Then(@"Api returns a response code (.*)")]
        public void ApiReturnsAnExpectedResponseCode(int expectedResponseCode)
        {
            _apiTestContext.ApiResponse.StatusCode.Should().Be(expectedResponseCode);
        }

        [Then(@"Api response's contentType is (.*)")]
        public void ApiReturnsExpectedContentType(string expectedContentType)
        {
            _apiTestContext.ApiResponse.ContentType.Should().Be(expectedContentType);
        }
    }
}