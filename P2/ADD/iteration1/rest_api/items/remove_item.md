# Remove item from inventory

Allows the removal of an item.

URI: `/items/:id`

Verb: `DELETE`

## Success Responses

`204 No Content` - The item was successfully removed from the inventory

## Error Responses

`404 Not Found` - No item with the specified resource identified was found

`500 Internal Server Error` - The server failed to resolve the request