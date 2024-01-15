Feature: Login
	In order to Login to Amazon e-commerce website 
	As a portal user
	I want to access the dashboard and perform login 

Background:
	Given I have browser with Amazon homepage open

Scenario Outline: Valid Credential
	When I click on Signin button
	Then signin page opens up
	And I enter username as '8134933750'
	And I click on username continue button
	And I enter password as 'Pranab20@'
	And I click on password continue button
	Then I should get access to the homepage with text as 'Hello, Pranab'

Scenario Outline: Invalid Username
	When I click on Signin button
	Then signin page opens up
	And I enter username as '<username>'
	And I click on username continue button
	Then I should get the username error message as 'We cannot find an account with that email address'

	Examples:
		| username |
		| balaji   |
		| john     |
		| peter    |

Scenario Outline: Invalid Password
	When I click on Signin button
	Then signin page opens up
	And I enter username as '<username>'
	And I click on username continue button
	And I enter password as '<password>'
	And I click on password continue button
	Then I should get the password error message as 'Your password is incorrect'

	Examples:
		| username   | password |
		| 8134933750 | balaji   |
		| 8134933750 | john     |
		| 8134933750 | peter    |
