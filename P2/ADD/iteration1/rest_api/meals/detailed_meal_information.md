# Detailed meal information

Retrieves detailed information of a meal using its resource identifier.

URI: `/meals/:id`

Verb: `GET`

## Success Responses

`200 OK` - The meal was found

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

## Error Responses

`404 Not Found` - No meal with the specified resource identifier was found

`500 Internal Server Error` - The server failed to resolve the request