# Meal ingredients

Retrieves the ingredients of a meal as an array.

URI: `/meals/:id/ingredients`

Verb: `GET`

## Success Responses

`200 OK` - Request was successfully processed

Example:

```

[
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
]

```

## Error Responses

`404 Not Found` - No meal was found by the given identifier

`500 Internal Server Error` - The server failed to resolve the request