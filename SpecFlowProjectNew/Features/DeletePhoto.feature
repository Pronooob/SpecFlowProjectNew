Feature: Delete Photo
	In order to Delete Photo in  Amazon account 
	As a portal user
	I want to access the dashboard and delete photo

Background:
	Given I have browser with Amazon homepage open

Scenario: Delete Photo in Account
	When I click on Signin button
	Then signin page opens up
	And I enter username as '8134933750'
	And I click on username continue button
	And I enter password as 'Pranab20@'
	And I click on password continue button
	Then I should get access to the homepage with text as 'Hello, Pranab'
	And I click on Account and Lists button
	And I click on Profile tab
	Then I should get a page with 'This is your private view of your public profile. See what others see'
	And I click on Profile Photo
	And I Delete the profile photo
	Then I should get a page with 'This is your private view of your public profile. See what others see'

