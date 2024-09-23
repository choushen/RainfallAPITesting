Feature: Rainfall API Testing for Measurements for a Station
    In order to test the new features of the Rainfall API
    I want to verify the measurements for a station.

Scenario: Test the limit parameter for rainfall measurements for an individual station
    Given I have the rainfall API endpoint
    When I request rainfall measurements for station "E7050" with a limit of "5"
    Then I should receive no more than "5" measurements

Scenario: Test the date parameter for rainfall measurements for an individual station
    Given I have the rainfall API endpoint
    When I request rainfall measurements for station "E7050" on date "01-01-2024"
    Then I should receive the rainfall measurements for that date only
