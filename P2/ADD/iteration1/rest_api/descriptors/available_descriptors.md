# Available descriptors

Retrieves available descriptors as an array.

URI: `/descriptors`

Verb: `GET`

## Success Responses

`200 OK` - One or more descriptors have been retrieved

Example:

```

[
	{
		"id":1,
		"name":"Salt",
		"quantityUnits":["g","mg"]
	},
	{
		"id":2,
		"name":"Fibre",
		"quantityUnits":["g","mg"]
	},
	{
		"id":3,
		"name":"Fat",
		"quantityUnits":["g","mg"]
	},
	{
		"id":4,
		"name":"Calorie",
		"quantityUnits":["cal","kcal"]
	}
]

```

## Error Responses

`404 Not Found` - No descriptors are available

`500 Internal Server Error` - The server failed to resolve the request