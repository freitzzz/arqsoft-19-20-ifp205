# Entrypoint

REST API entrypoint is located at the following URI `/api`


## Functionalities

Produced functionalities can be found in the table below. Consumers can interact directly with two collections (`meals` and `items`) as they are both the existent root aggregators of all GFA. Collections `allergens`, `descriptors`, `ingredients` and `mealtypes` are also available and allow the consume of the available valid data that can be specified on meals creation.

-----------

|Verb|URI|Description|
|----|---|-----------|
|GET|[/meals](meals/available_meals.md)|Retrieves available meals|
|GET|[/meals/:id](meals/detailed_meal_information.md)|Retrieves detailed information of a meal|
|GET|[/meals/:id/allergens](meals/meal_allergens.md)|Retrieves meal allergens|
|GET|[/meals/:id/descriptors](meals/meal_descriptors.md)|Retrieves meal descriptors|
|GET|[/meals/:id/ingredients](meals/meal_ingredients.md)|Retrieves meal ingredients|
|POST|[/meals](meals/create_meal.md)|Creates a meal|
|GET|[/items](items/available_items.md)|Retrieves available items|
|POST|[/items](items/add_item.md)|Add item to inventory|
|DELETE|[/items/:id](items/remove_item.md)|Remove item from inventory|
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
|POST|[/pos](pos/create_pos.md)|Creates a PoS|
|POST|[/pos/:id/items](pos/register_item_handle.md)|Registers that an item needs to be handled by the PoS|
|GET|[/pos/:id/items](pos/available_items.md)|Retrieves available items which the PoS handles|
|DELETE|[/pos/:id/items/:id](pos/deregister_item_handle.md)|Deregisters the handle of an item|
|DELETE|[/pos/:id/items/:id?userType](pos/purchase_item.md)|Register an item purchase|
|GET|[/users](users/available_users.md)|Retrieves existing users|
|GET|[/usertypes](usertypes/available_usertypes.md)|Retrieves existing types of user|

## Generic CRUD behaviour within the GFAB component

**Get**

  ![GetGFAB](diagrams/Get_GFAB.png)

**Post**

  ![PostGFAB](diagrams/Post_GFAB.png)

**Delete**

  ![DeleteGFAB](diagrams/Delete_GFAB.png)