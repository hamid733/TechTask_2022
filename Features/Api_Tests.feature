Feature: Api_Tests

A short summary of the feature

@functional @Orders
Scenario: Verify the order fields received from the api
	When I call the orders api
	Then the following order items should be displayed against a single order
	| Field       |
	| createdAt   |
	| cakeName    |
	| price       |
	| clientEmail |
	| id          |

@functional @Orders
Scenario: Verify the order details for a specific order id
When I request the order details by passing the order id '2'
Then the correct order record should be recieved matching the id
| orderid | createdAt            | cakeName                  | price  | clientEmail      |
| 2       | 8/15/2022 9:55:05 AM | reiciendis accusamus quam | 352.00 | Gina36@yahoo.com |

Scenario: Verify the api response is a well-formed json schema
When I call the orders api
Then the reponse should be a valid json

