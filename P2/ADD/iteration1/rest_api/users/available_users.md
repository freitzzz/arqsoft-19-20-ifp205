# Available users

Retrieves the available users as an array.

URI: `/users`

Verb: `GET`

## Success Responses

`200 OK` - One or more users have been retrieved

Example:

```

[
    {
        "id":1,
        "userType":"external"
    },
    {
        "id":2,
        "userType":"internal"
    },
    {
        "id":3,
        "userType":"administrator"
    }
]

```

## Error Responses

`404 Not Found` - No users are available

`500 Internal Server Error` - The server failed to resolve the request