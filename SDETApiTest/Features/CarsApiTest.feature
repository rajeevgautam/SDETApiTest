Feature: CarsApi
In order to provide available car information by car type
As a Product Owner 
I want to provide an api which will take a cartype as input and provide available cars information

Scenario Outline: Valid car types returns car details
	When I request car information for a <validCarType>
	Then Api returns a response code 200
	And Api response's contentType is application/json; charset=utf-8
	And response has the <expectedCarsMake> with type <validCarType>

	Examples:
		| validCarType | expectedCarsMake  |
		| Saloon       | BMW,Audi,Mercedes |
		| saloon       | BMW,Audi,Mercedes |
		| SALOON       | BMW,Audi,Mercedes |
		| SUV          | Toyota            |
		| Hatchback    | Ford,Volkswagen   |

Scenario Outline: Invalid car types returns 404 not found status
	When I request car information for a <inValidCarType>
	Then Api returns a response code 404

	Examples:
		| inValidCarType |
		|                |
		| xyz            |
		| 123            |
		| suva           |
		| saloona        |