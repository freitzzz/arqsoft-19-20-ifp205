# Create a new meal type

Allows the creation of a new meal type.

URI: `/mealtypes`

Verb: `POST`

## Required data

The following fields are required in order to create a meal type:

- `name` The name of the meal type

Example:

```

{
    "name":"Fish"
}

```

### Success Responses

`201 Created` - The meal type was successfully created, adding a resource to meal types collection

Example:

```

{
    "id":1,
    "name":"Fish"
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the meal type due to an invalid field

Example:

```

{
    "message":"The meal type 'Fish' already exists"
}

```

`500 Internal Server Error` - The server failed to resolve the request