# Available items

Retrieves available items as an array.

URI: `/items`

Verb: `GET`

## Success Responses

`200 OK` - One or more items have been retrieved

Example:

```

[
    {
        "id":1,
        "mealId":"Stone Soup",
        "location":"ISEP",
        "availableToServeUntil":"2019-11-01T13:05:20"
        "productionDate":"2019-10-31",
        "expirationDate":"2020-01-31"
    },
    {
        "id":2,
        "mealId":"Spanish Codfish",
        "location":"ISEP",
        "availableToServeUntil":"2019-11-01T13:05:25"
        "productionDate":"2019-10-31",
        "expirationDate":"2020-01-31"
    }
]

```

## Error Responses

`404 Not Found` - No items are available

`500 Internal Server Error` - The server failed to resolve the request