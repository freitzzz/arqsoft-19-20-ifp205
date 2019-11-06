# Available meal types

Retrieves available meal types as an array.

URI: `/mealtypes`

Verb: `GET`

## Success Responses

`200 OK` - One or more meal types have been retrieved

Example:

```

[
	{
		"id":1,
		"name":"Soup"
	},
	{
		"id":2,
		"name":"Main Course"
	},
	{
		"id":3,
		"name":"Dessert"
	}
]

```

## Error Responses

`404 Not Found` - No meal types are available

`500 Internal Server Error` - The server failed to resolve the request