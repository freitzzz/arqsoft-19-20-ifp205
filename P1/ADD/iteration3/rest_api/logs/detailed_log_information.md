# Detailed log information

Retrieves detailed information of a log using its resource identifier.

URI: `/logs/:id`

Verb: `GET`

## Success Responses

`200 OK` - The log was found

Example:

```

{
    "id":1,
    "activity":"Meal",
    "action":"Meal Creation",
    "userType":"Kitchen Worker",
    "occurrenceDateTime":"2019-11-10T20:24:32"
}

```

## Error Responses

`404 Not Found` - No log with the specified resource identifier was found

`500 Internal Server Error` - The server failed to resolve the request