# Available items

Retrieves available items as an array.

URI: `/items`

Verb: `GET`

## Optional Data

The following query parameters can be specified in order to filter items retrieval:

- `mealId` Specifies that the items being retrieved are of a specific meal

## Success Responses

`200 OK` - One or more items have been retrieved

Example:

```

[
    {
        "id":1,
        "identificationNumber":3019251152316
        "mealId":"Stone Soup",
        "availableToServeUntil":"2019-11-01T13:05:20"
        "productionDate":"2019-10-31",
        "expirationDate":"2020-01-31"
    },
    {
        "id":2,
        "identificationNumber":9062352390253
        "mealId":"Spanish Codfish",
        "availableToServeUntil":"2019-11-01T13:05:25"
        "productionDate":"2019-10-31",
        "expirationDate":"2020-01-31"
    }
]

```

## Error Responses

`404 Not Found` - No items are available

`500 Internal Server Error` - The server failed to resolve the request