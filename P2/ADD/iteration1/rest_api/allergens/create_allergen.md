# Create a new allergen

Allows the creation of a new allergen.

URI: `/allergens`

Verb: `POST`

## Required data

The following fields are required in order to create an allergen:

- `name` The name of the allergen

Example:

```

{
    "name":"Mustard"
}

```

### Success Responses

`201 Created` - The allergen was successfully created, adding a resource to allergens collection

Example:

```

{
    "id":1,
    "name":"Mustard"
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the allergen due to an invalid field

Example:

```

{
    "message":"The allergen 'Mustard' already exists"
}

```

`500 Internal Server Error` - The server failed to resolve the request