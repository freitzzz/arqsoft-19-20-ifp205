# Available allergens

Retrieves available allergens as an array.

URI: `/allergens`

Verb: `GET`

## Success Responses

`200 OK` - One or more allergens have been retrieved

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

`404 Not Found` - No allergens are available

`500 Internal Server Error` - The server failed to resolve the request