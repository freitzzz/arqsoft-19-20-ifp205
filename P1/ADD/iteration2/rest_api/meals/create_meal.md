# Create a new meal

Allows the creation of a new meal.

URI: `/meals`

Verb: `POST`

## Required data

The following fields are required in order to create a meal:

- `designation` The meal designation which is its unique identifier
- `type` The meal type
- `ingredients` An array of strings which represents the meal ingredients
- `descriptors` An array of descriptors which represents the meal nutritional data

## Additional Data

The following fields can also be added while creating the meal but are not mandatory:

- `allergens` An array of strings which represents the meal allergens

Example:

```

{
    "designation":"Stone Soup",
    "type":"soup",
    "ingredients":["Olive Oil", "Red Lentils", "Milk"],
    "allergens":["Celery", "Nuts"],
    "descriptors":[
        {
          "name":"Salt",
          "quantity":0.25,
          "quantityUnit":"g"
        },
        {
          "name":"Fibre",
          "quantity":5.0,
          "quantityUnit":"g"
        },
        {
          "name":"Fat",
          "quantity":7.0,
          "quantityUnit":"g"
        }
    ]
}

```

### Success Responses

`201 Created` - The meal was successfully created, adding a resource to meals collection

Example:

```

{
    "id":1,
    "designation":"Stone Soup",
    "type":"soup",
    "allergens":[
        {
          "name":"Celery"
        },
        {
          "name":"Nuts"
        }
    ],
    "ingredients":[
        {
          "name":"Olive Oil"
        },
        {
          "name":"Red Lentils"
        },
        {
          "name":"Milk"
        }
    ],
    "descriptors":[
        {
          "name":"Salt",
          "quantity":0.25,
          "quantityUnit":"g"
        },
        {
          "name":"Fibre",
          "quantity":5.0,
          "quantityUnit":"g"
        },
        {
          "name":"Fat",
          "quantity":7.0,
          "quantityUnit":"g"
        }
    ]
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the meal due to an invalid field

Example:

```

{
    "message":"The meal 'Stone Soup' already exists"
}

```

`500 Internal Server Error` - The server failed to resolve the request