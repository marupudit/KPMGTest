Feature: Create a user journey test from scratch in an automation framework of your choice for the John Lewis website(https://www.johnlewis.com/), which;
1)	accepts the cookie banner
2)	browses for any product or products(s) of your choice
3)	selects multiple quantities of that product or product(s)
4)	adds the selected product to the basket
5)	deletes product or products(s) quantities from the basket
6)	clears cookies at the end of the test.
We will be looking for how the web components are interacted with, any comments used to describe your code, the simpler the solution the better.
Additional bonus points for; How can we analyse the performance of the test? 
And how do we ensure our tests don’t stop working if a product is removed from the site i.e. the test isn’t linked with a specific product.

@Test1
Scenario: User journey of purchasing flow for a particular item on the John Lewis site.
	Given I launch the John Lewis site using the "https://www.johnlewis.com/" URL
	And I accept the cookie banner on site
	When I browse for the "Laptop" product using the search functionality
	And I selected '2' quantities of the above product
	And I added the selected product to the basket
	Then I go to the basket and delete the products from the basket
	And I verified "Your basket is empty." text
	And I clear the cookies

@Test2
Scenario: User journey of purchasing flow for a random item on the John Lewis site.
	Given I launch the John Lewis site using the "https://www.johnlewis.com/" URL
	And I accept the cookie banner on site
	When I browse for a random product under the Gift section
	And I selected '2' quantities of the above product
	And I added the selected product to the basket
	Then I go to the basket and delete the products from the basket
	And I verified "Your basket is empty." text
	And I clear the cookies


