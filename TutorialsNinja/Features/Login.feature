Feature: Login

User should be able to login to the account with proper credentials


Scenario Outline: Login with valid credentials
	Given I visit to website as a non-registred user 
	And I navigate to Login Page
    When I enter <username> username and <password> password
	And I click on Login button
	Then I should get logged in
Examples: 
        | username                     | password  |
        | kaustubhwankhade25@gmail.com | Kmw018@00 |
        | amotooricap5@gmail.com       | 12345     |
        | amotooricap1@gmail.com       | 12345     |
