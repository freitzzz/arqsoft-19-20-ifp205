#!/bin/bash
dotnet ef migrations add InitialCreate --context SQLite3DbContext --output-dir Migrations
dotnet ef database update --context SQLite3DbContext