# Meal allergens

Retrieves the allergens of a meal as an array.

URI: `/meals/:id/allergens`

Verb: `GET`

## Success Responses

`200 OK` - Request was successfully processed

Example:

```

[
	{
		"id":1,
		"name":"Celery"
	},
	{
		"id":2,
		"name":"Nuts"
	},
	{
		"id":3,
		"name":"Oat"
	}
]

```

## Error Responses

`404 Not Found` - No meal was found by the given identifier

`500 Internal Server Error` - The server failed to resolve the request