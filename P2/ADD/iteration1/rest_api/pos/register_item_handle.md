# Register item handle

Allows the register of the handle of a new item in the PoS.

URI: `/pos/:id/items`

Verb: `POST`

## Required data

The following fields are required in order to create a PoS :

- `itemId` The identifier of the item

Example:

```

{
    "itemId":1
}

```

### Success Responses

`201 Created` - The item handle was successfully registered, adding a resource to items collection

Example:

```

{
  "id":1,
  "identificationNumber:942895,
  "label":"Stone-Soup::0942895::2019-10-31::2020-01-31"
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the PoS due to an invalid field

Example:

```

{
    "message":"The item with the identifier '1' does not exist"
}

```

`404 Not Found` - The PoS with the given resource identifier was not found

`500 Internal Server Error` - The server failed to resolve the request