# Meal descriptors

Retrieves the descriptors of a meal as an array.

URI: `/meals/:id/descriptors`

Verb: `GET`

## Success Responses

`200 OK` - Request was successfully processed

Example:

```

[
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
    "id:3",
    "name":"Fat",
    "quantity":7.0,
    "quantityUnit":"g"
  }
]

```

## Error Responses

`404 Not Found` - No meal was found by the given identifier

`500 Internal Server Error` - The server failed to resolve the request