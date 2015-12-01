Feature: VisualizeData
	In order to see the weather data
	As a user
	I want to see the collected data

@changeLocation
Scenario: Change location of shown data
	Given I see the location selection menu
	And I see the timeframe selection menu
	When I select the timeframe "7 Tage"
	And I click on the location "DHBW"
	Then the data of "DHBW" should be shown

@changeTimeframe
Scenario: Change timeframe of shown data
	Given I see the location selection menu
	And I see the timeframe selection menu
	When I select the timeframe "7 Tage"
	And I click on the location "DHBW"
	And I select the timeframe "3 Minuten"
	And I click on the button "Refresh"
	And I click on the location "DHBW"
	Then the data of the last week is shown
