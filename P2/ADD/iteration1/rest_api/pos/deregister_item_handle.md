# Deregister item handle

Allows the deregister of the handle of an items

URI: `/pos/:id/items/:id`

Verb: `DELETE`

## Success Responses

`204 No Content` - The item handle was successfully deregistered

## Error Responses

`404 Not Found` - No PoS or item with the specified resource identified was found

`500 Internal Server Error` - The server failed to resolve the request