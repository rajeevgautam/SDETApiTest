using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using SDETApiTest.Configuration;
using SDETApiTest.DomainObjects;
using SDETApiTest.Utils;
using TechTalk.SpecFlow;

namespace SDETApiTest.Bindings
{
    [Binding]
    public class CarsDataValidationSteps
    {
        private readonly TestContext _apiTestContext;

        public CarsDataValidationSteps(TestContext apiTestContext)
        {
            _apiTestContext = apiTestContext;
        }

        [Then(@"response has the (.*) with type (.*)")]
        public void ThenResponseHasThe(string[] expectedCarMakers, string expectedCarType)
        {
            string responseContent = _apiTestContext.ApiResponse.Content;
            List<CarInfo> actualCarInfoList = JsonConvert.DeserializeObject<List<CarInfo>>(responseContent);
            actualCarInfoList.Count.Should().Be(expectedCarMakers.Length);
            actualCarInfoList.Count(car => car.type.Equals(expectedCarType, StringComparison.OrdinalIgnoreCase)).Should().Be(expectedCarMakers.Length);
            VerifyAllExpectedCarAreInResponse(expectedCarMakers, actualCarInfoList).Should().Be(true);
        }

        [StepArgumentTransformation]
        public string[] TransformStringToArrayOfStrings(string commaSeparatedStepArgumentValues)
        {
            string sourceString = commaSeparatedStepArgumentValues;
            string[] stringSeparators = new string[] {","};
            return sourceString.Split(stringSeparators, StringSplitOptions.None);
        }

        private bool VerifyAllExpectedCarAreInResponse(string[] expectedCarMakers, List<CarInfo> actualCarInfoList)
        {
            bool allCarInfoMatched = true; 
            foreach (var carmake in expectedCarMakers)
            {
                CarInfo expectedCarInfo = _apiTestContext.CarsRepository.Find(car => car.make.Equals(carmake));
                CarInfo actualCarInfo = actualCarInfoList.Find(car => car.make.Equals(carmake));
                allCarInfoMatched  = allCarInfoMatched && expectedCarInfo.Equals(actualCarInfo);
                if (!allCarInfoMatched)
                {
                    Console.WriteLine($"CarInfo Unmatched for Make {carmake}");
                }
            }

            return allCarInfoMatched;
        }
    }
}
