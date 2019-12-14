# Available ingredients

Retrieves available ingredients as an array.

URI: `/ingredients`

Verb: `GET`

## Success Responses

`200 OK` - One or more ingredients have been retrieved

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

`404 Not Found` - No ingredients are available

`500 Internal Server Error` - The server failed to resolve the request