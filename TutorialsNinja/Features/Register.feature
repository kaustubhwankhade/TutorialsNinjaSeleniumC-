Feature: Register

User should be able to create an account in the application


Scenario: Regiter an account with valid details
	Given I visit to website
	And I navigate to register account page
	When I enter valid details into the fields
	    | firstname | lastname | telephone		| password   |
	    | kaustubh  | wankhade | "1234567890"   | "123456"   |
	And I select yes for subscription 
	And I select Privacy Policy
	And I click on Continue button
	Then Account should be created

Scenario: Regiter an account with valid details by filling only mandatory fields
	Given I visit to website
	And I navigate to register account page
	When I enter valid details into the fields
	    | firstname | lastname | telephone		| password   |
	    | kaustubh  | wankhade | "1234567890"   | "123456"   |
	And I select Privacy Policy
	And I click on Continue button
	Then Account should be created

Scenario:Regiter an account with providing any fields
	Given I visit to website
	And I navigate to register account page
	When I select Privacy Policy
	And I click on Continue button
	Then Account should not be created
	And Proper warning messages shouls be displayed