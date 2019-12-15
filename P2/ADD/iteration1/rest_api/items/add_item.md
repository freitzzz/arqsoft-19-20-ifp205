# Add Item to Inventory

Allows the creation of a new item.

URI: `/items`

Verb: `POST`

## Required data

The following fields are required in order to create a item:

- `mealId` The meal which the item corresponds to
- `location` The item location
- `productionDate` The item production date (YYYY-MM-DD format)
- `expirationDate` The item expiration date (YYYY-MM-DD format)

Example:

```

{
    "mealId":1,
    "productionDate":"2019-10-31",
    "expirationDate":"2020-01-31"
}

```

### Success Responses

`201 Created` - The item was successfully created, adding a resource to items collection

Example:

```

{
    "id":1,
    "mealId":1
    "identificationNumber:942895
    "availableToServeUntil":"2019-11-01T13:43:31"
    "productionDate":"2019-10-31",
    "expirationDate":"2020-01-31",
}

```

### Error Responses

`400 Bad Request` - An error occurred while creating the item due to an invalid field

Example:

```

{
    "message":"The item production date is after todays date"
}

```

`500 Internal Server Error` - The server failed to resolve the request