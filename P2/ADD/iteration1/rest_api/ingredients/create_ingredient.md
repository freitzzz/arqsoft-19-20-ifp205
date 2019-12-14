# Create a new ingredient

Allows the creation of a new ingredient.

URI: `/ingredients`

Verb: `POST`

## Required data

The following fields are required in order to create an ingredient:

- `name` The name of the ingredient

Example:

```

{
    "name":"Quail"
}

```

### Success Responses

`201 Created` - The ingredient was successfully created, adding a resource to ingredients collection

Example:

```

{
    "id":1,
    "name":"Quail"
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the ingredient due to an invalid field

Example:

```

{
    "message":"The ingredient 'Quail' already exists"
}

```

`500 Internal Server Error` - The server failed to resolve the request