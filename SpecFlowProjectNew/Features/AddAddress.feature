Feature: Add Address
	In order to Add Address to Amazon account 
	As a portal user
	I want to access the dashboard and add address

Background:
	Given I have browser with Amazon homepage open

Scenario: Add Address
	When I click on Signin button
	Then signin page opens up
	And I enter username as '8134933750'
	And I click on username continue button
	And I enter password as 'Pranab20@'
	And I click on password continue button
	Then I should get access to the homepage with text as 'Hello, Pranab'
	And I click on Account and Lists button
	And I click on Your Addresses
	And I click on Plus symbol to add new address
	And I fill address details
		| fullname  | mobno      | pin    | flat  | area       | landmark  |
		| Temporary | 8134933750 | 781006 | AK-47 | Kanaklata  | Mount Abu |
	And I click on add address
	Then I should get the new Address with name 'Temporary'