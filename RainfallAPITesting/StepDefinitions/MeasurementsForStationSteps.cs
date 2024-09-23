using System;
using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace rainfallapitesting.RainfallAPITesting.StepDefinitions
{

    [Binding]
    public class MeasurementsForStationSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private RestClient? client;
        private RestRequest? request;
        private RestResponse? response;


        // Inject ScenarioContext via constructor
        public MeasurementsForStationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"I have the rainfall API endpoint")]
        public void GivenIHaveTheRainfallAPIEndpoint()
        {
            client = new RestClient("http://environment.data.gov.uk/flood-monitoring/id/stations");
        }


        [When(@"I request rainfall measurements for station ""(.*)"" with a limit of ""(.*)""")]
        public void WhenIRequestRainfallMeasurementsForStationWithALimitOf(string stationId, string limit)
        {
            // Building the request
            var endpoint = $"/{stationId}/readings";
            request = new RestRequest(endpoint, Method.Get);
            request.AddQueryParameter("_limit", $"{limit}");
        }


        [Then(@"I should receive no more than ""(.*)"" measurements")]
        public void ThenIShouldReceiveNoMoreThanMeasurements(string limit)
        {
            response = client.Execute(request);

            // Check if the response status code is 200
            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            // Parse the response to a JObject to work with JSON
            JObject jsonResponse = JObject.Parse(response.Content);

            // Cast the "items" field to JArray for counting the items
            JArray items = jsonResponse["items"] as JArray;

            // Check if the number of items matches the expected limit
            Assert.That(items.Count, Is.EqualTo(int.Parse(limit)));
        }


        [When(@"I request rainfall measurements for station ""(.*)"" on date ""(.*)""")]
        public void WhenIRequestRainfallMeasurementsForStationOnDate(string stationId, string date)
        {
            // Store the date in the ScenarioContext
            _scenarioContext["date"] = date;

            // Building the request
            var endpoint = $"/{stationId}/readings";
            request = new RestRequest(endpoint, Method.Get);
            request.AddQueryParameter("date", $"{date}");
        }


        [Then(@"I should receive the rainfall measurements for that date only")]
        public void ThenIShouldReceiveTheRainfallMeasurementsForThatDateOnly()
        {
            response = client.Execute(request);

            // Check if the response status code is 200
            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            // Parse the JSON response content
            var jsonResponse = JObject.Parse(response.Content);

            // Access the "items" array and ensure it is correctly formatted
            var items = jsonResponse["items"] as JArray;

            // Loop through items to validate the date format
            foreach (var item in items)
            {
                string dateTimeString = item["dateTime"].ToString();

                // Parse the date string using DateTime.Parse to handle system's default format
                DateTime parsedDateTime = DateTime.Parse(dateTimeString);

                // Convert both dates to the desired format (yyyy-MM-dd)
                string formattedParsedDate = parsedDateTime.ToString("yyyy-MM-dd");

                string expectedDate = _scenarioContext["date"].ToString();

                // Compare the item date to the expected date
                Assert.That(formattedParsedDate, Is.EqualTo(expectedDate), $"Unexpected date found: {formattedParsedDate}");
            }

        }

    } // end of class

} // end of namespace
