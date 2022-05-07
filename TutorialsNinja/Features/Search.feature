Feature: Search

Searching of product should be possible


Scenario: Search for a valid product 
	Given I visit the website as a guest user
	When I enter the valid product into search box
	And I click on search button
	Then I should see the product in the search results
