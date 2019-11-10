# Register item purchase

Allows the register of an item purchase.

URI: `/items/:id`

Verb: `DELETE`

## Required data

The following query parameters are required in order to register an item purchase:

- `userType` The type of the user that purchased the meal

## Success Responses

`204 No Content` - The item was successfully marked as purchased

## Error Responses

`400 Bad Request` - An error occurred while registering the item purchase due to an invalid field

Example:

```

{
    "message":"The user type is not valid"
}

```

`404 Not Found` - No item with the specified resource identified was found

`500 Internal Server Error` - The server failed to resolve the request