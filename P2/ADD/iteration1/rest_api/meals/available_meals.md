# Available meals

Retrieves available meals as an array.

URI: `/meals`

Verb: `GET`

## Success Responses

`200 OK` - One or more meals have been retrieved

Example:

```

[
    {
        "id":1,
        "designation":"Stone Soup",
        "type":"soup"
    },
    {
        "id":2,
        "designation":"Portuguese fish and fries",
        "type":"main course"
    },
]

```

## Error Responses

`404 Not Found` - No meals are available

`500 Internal Server Error` - The server failed to resolve the request