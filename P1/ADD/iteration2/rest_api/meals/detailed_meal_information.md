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
          "id":1,
          "name":"Celery"
        },
        {
          "id":2,
          "name":"Nuts"
        }
    ],
    "ingredients":[
        {
          "id":1,
          "name":"Olive Oil"
        },
        {
          "id":2,
          "name":"Red Lentils"
        },
        {
          "id":3,
          "name":"Milk"
        }
    ],
    "descriptors":[
        {
          "id":1,
          "name":"Salt",
          "quantity":0.25,
          "quantityUnit":"g"
        },
        {
          "id":2,
          "name":"Fibre",
          "quantity":5.0,
          "quantityUnit":"g"
        },
        {
          "id":3,
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