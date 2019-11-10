# Entrypoint

GFAB REST API entrypoint is located at the following URI `/api`


## Functionalities

Produced functionalities can be found in the table below. Consumers can interact directly with two collections (`meals` and `items`) as they are both the existent root aggregators of all GFA. Collections `allergens`, `descriptors`, `ingredients` and `mealtypes` are also available and allow the consume of the available valid data that can be specified on meals creation.

-----------

|Verb|URI|Description|
|----|---|-----------|
|GET|[/meals](meals/available_meals.md)|Retrieves available meals|
|GET|[/meals/:id](meals/detailed_meal_information.md)|Retrieves detailed information of a meal|
|POST|[/meals](meals/create_meal.md)|Creates a meal|
|GET|[/items](items/available_items.md)|Retrieves available items|
|POST|[/items](items/add_item.md)|Add item to inventory|
|DELETE|[/items/:id](items/remove_item.md)|Remove item from inventory|
|DELETE|[/items/:id?userType](items/purchase_item.md)|Register an item purchase|
|GET|[/allergens](allergens/available_allergens.md)|Retrieves available allergens that a meal may contain|
|POST|[/allergens](allergens/create_allergen.md)|Creates an allergen|
|GET|[/ingredients](ingredients/available_ingredients.md)|Retrieves available ingredients that can be composed by a meal|
|POST|[/ingredients](ingredients/create_ingredient.md)|Creates an ingredient|
|GET|[/descriptors](descriptors/available_descriptors.md)|Retrieves available descriptors that can be applied to a meal|
|POST|[/descriptors](descriptors/create_descriptor.md)|Creates a descriptor|
|GET|[/mealtypes](mealtypes/available_mealtypes.md)|Retrieves available meal types|
|POST|[/mealtypes](mealtypes/create_mealtype.md)|Creates a meal type|
|GET|[/logs](logs/all_logs.md)|Retrieves all user activity logs|
|GET|[/logs/:id](logs/detailed_log_information.md)|Retrieves detailed information of a log|

## Generic CRUD behaviour within the GFAB component

**Get**

  ![GetGFAB](diagrams/Get_GFAB.png)

**Post**

  ![PostGFAB](diagrams/Post_GFAB.png)

**Delete**

  ![DeleteGFAB](diagrams/Delete_GFAB.png)