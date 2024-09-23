using System;
using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;

namespace rainfallapitesting.RainfallAPITesting.StepDefinitions
{

    [Binding]
    public class MeasurementsForStationSteps
    {

        private RestClient client;
        private RestRequest request;
        private RestResponse response;


        [Given(@"I have the rainfall API endpoint")]
        public void GivenIHaveTheRainfallAPIEndpoint()
        {
            client = new RestClient("http://environment.data.gov.uk/flood-monitoring/id/stations/{id}/readings");
        }

        [When(@"I request rainfall measurements for station ""(.*)"" with a limit of ""(.*)""")]
        public void WhenIRequestRainfallMeasurementsForStationWithALimitOf(string stationId, string limit)
        {
            
        }

        [Then(@"I should receive no more than ""(.*)"" measurements")]
        public void ThenIShouldReceiveNoMoreThanMeasurements(string limit)
        {

        }

        [When(@"I request rainfall measurements for station ""(.*)"" on date ""(.*)""")]
        public void WhenIRequestRainfallMeasurementsForStationOnDate(string stationId, string date)
        {

        }

        [Then(@"I should receive the rainfall measurements for that date only")]
        public void ThenIShouldReceiveTheRainfallMeasurementsForThatDateOnly()
        {

        }

    }


}