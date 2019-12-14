# Available PoS items

Retrieves the available items in which a PoS handles as an array.

URI: `/pos/:id/items`

Verb: `GET`

## Success Responses

`200 OK` - The request was successfully processed

Example:

```

[
    {
        "id":1,
        "identificationNumber:942895,
        "label":"Stone-Soup::0942895::2019-10-31::2020-01-31"
    },
    {
        "id":2,
        "identificationNumber:5215123,
        "label":"Stone-Soup::5215123::2019-10-31::2020-01-31"
    },
]

```

## Error Responses

`404 Not Found` - No PoS was found by the given identifier

`500 Internal Server Error` - The server failed to resolve the request