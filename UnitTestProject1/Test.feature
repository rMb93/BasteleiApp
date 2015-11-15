Feature: VisualizeData
	In order to see the weather data
	As a user
	I want to see the collected data

@changeLocation
Scenario: Change location of shown data
	Given I see the location selection menu
	When I click on the location "toilet"
	Then the data of "toilet" should be shown

@changeTimeframe
Scenario: Change timeframe of shown data
	Given I have selected the location "toilet"
	When I click on the ComboBox arrow
	And I click on the timeframe "last week"
	Then the data of the last week is shown
