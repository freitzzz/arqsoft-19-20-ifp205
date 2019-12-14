# Available logs

Retrieves all logs as an array.

URI: `/logs`

Verb: `GET`

## Optional Data

The following query parameters can be specified in order to filter logs retrieval:

- `userType` The type of the user in which the log was recorded
- `ocurrence` The date time in which a log has occurred. This value can either specify a date time, a full date, a date with years and months and a date with only years
- `activity` The activity in which the log was recorded
- `action` The action in which the log was recorded
- `startDateTime` Specifies that the logs being retrieved should start after a specific date time or date.
- `endDateTime` Specifies that the logs being retrieved should start before a specific date time or date.

## Success Responses

`200 OK` - One or more logs have been retrieved

Example:

```

[
    {
        "id":1,
        "activity":"Meal",
        "action":"Meal Creation",
        "userType":"Kitchen Worker",
        "occurrenceDateTime":"2019-11-10T20:24:32"
    },
    {
        "id":2,
        "activity":"Meal",
        "action":"Meal Details Retrieval",
        "userType":"Kitchen Worker",
        "occurrenceDateTime":"2019-11-10T20:24:35"
    }
]

```

## Error Responses

`404 Not Found` - No logs are available

`500 Internal Server Error` - The server failed to resolve the request