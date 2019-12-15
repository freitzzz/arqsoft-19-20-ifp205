# Available user types

Retrieves available user types as an array.

URI: `/mealtypes`

Verb: `GET`

## Success Responses

`200 OK` - One or more user types have been retrieved

Example:

```

[
	{
		"id":1,
		"name":"external"
	},
	{
		"id":2,
		"name":"internal"
	},
	{
		"id":3,
		"name":"administrator"
	},
  {
		"id":4,
		"name":"kitchen worker"
	}
]

```

## Error Responses

`404 Not Found` - No user types are available

`500 Internal Server Error` - The server failed to resolve the request