# Entrypoint

GFAB REST API entrypoint is located at the following URI `/api`


## Functionalities

Produced functionalities can be found in the table below. Consumers can only interact directly with two collections (`meals` and `items`) as they are both the existent root aggregators of all GFA.

-----------

|Verb|URI|Description|
|----|---|-----------|
|GET|[/meals](meals/available_meals.md)|Retrieves available meals|
|GET|[/meals/:id](meals/detailed_meal_information.md)|Retrieves detailed information of a meal|
|POST|[/meals](meals/create_meal.md)|Creates a meal|
|POST|[/items](items/add_item.md)|Add item to inventory|
|DELETE|[/items/:id](items/remove_item.md)|Remove item from inventory|

## Generic CRUD behaviour within the GFAB component

**Get**

  ![GetGFAB](diagrams/Get_GFAB.png)

**Post**

  ![PostGFAB](diagrams/Post_GFAB.png)

**Delete**

  ![DeleteGFAB](diagrams/Delete_GFAB.png)