Feature: Add to Cart
	In order to Add Product to Amazon account 
	As a portal user
	I want to access the dashboard and add product to cart

Background:
	Given I have browser with Amazon homepage open

Scenario: Add Product To Cart
	When I click on Signin button
	Then signin page opens up
	And I enter username as '8134933750'
	And I click on username continue button
	And I enter password as 'Pranab20@'
	And I click on password continue button
	Then I should get access to the homepage with text as 'Hello, Pranab'
	And I enter product name in search bar as 'Apple Iphone 13 pro'
	And I click on Search symbol
	And I select the respective product
	And I should redirect to new Tab
	Then I should get the product name as 'Apple iPhone 13 Pro (128GB) - Sierra Blue'
	And I should get the availability of product as 'Usually dispatched in 3 days.'
	And I click on Add to Cart button
	Then I should get Cart Addition Confirmation as 'Added to Cart'

