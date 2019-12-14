# Create a new PoS

Allows the specification of a new PoS.

URI: `/pos`

Verb: `POST`

## Required data

The following fields are required in order to create a PoS :

- `roomId` The identifier of the room in which the PoS is available

Example:

```

{
    "roomId":1
}

```

### Success Responses

`201 Created` - The PoS was successfully created, adding a resource to PoS collection

Example:

```

{
    "id":1,
    "roomId":1
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the PoS due to an invalid field

Example:

```

{
    "message":"The room with the identifier '1' does not exist"
}

```

`500 Internal Server Error` - The server failed to resolve the request