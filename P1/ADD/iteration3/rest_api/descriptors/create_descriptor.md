# Create a new descriptor

Allows the creation of a new descriptor.

URI: `/descriptors`

Verb: `POST`

## Required data

The following fields are required in order to create a descriptor:

- `name` The name of the descriptor
- `quantityUnits` The quantity units accepted by the descriptor

Example:

```

{
    "name":"Refined Salt",
    "quantityUnits":["mg", "g"]
}

```

### Success Responses

`201 Created` - The descriptor was successfully created, adding a resource to descriptors collection

Example:

```

{
    "id":1,
    "name":"Refined Salt",
    "quantityUnits":["mg", "g"]
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the descriptor due to an invalid field

Example:

```

{
    "message":"The descriptor 'Refined Salt' already exists"
}

```

`500 Internal Server Error` - The server failed to resolve the request