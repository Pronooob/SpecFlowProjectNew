Feature: PrimeVideologin
	In order to Login to Prime Video
	I want to access Amazon.in using valid credentials

Background: 
	Given I have browser with Amazon homepage open


Scenario: Login to Prime Video
	When I click on Signin button
	Then signin page opens up
	And I enter username as '8134933750'
	And I click on username continue button
	And I enter password as 'Pranab20@'
	And I click on password continue button
	Then I should get access to the homepage with text as 'Hello, Pranab'
	And I enter in the search bar as 'Prime Video'
	And I click on Search Button
	Then I click on Prime Video tab
	Then I click on Join Prime to Watch tab
	Then I click on Search Icon
	And I enter movie name as 'Batman'
	And I click on SearchButton
	Then I should get confirmation as 'Results for "Batman".'
