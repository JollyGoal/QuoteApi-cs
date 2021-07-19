# "Quotes" REST API
I made this project with literally zero knowledge in both C# and .NET so let's see if Github Copilot can help me with my task.

### Functional requirements for the API:

- [x] Create a quote with following fields: author, quote, category.
- [x] Edit/Change quote: author, quote, category.
- [x] Delete a quote by ID.
- [x] Get all quotes.
- [x] Get all quotes by category.
- [x] Get a random quote.
- [x] Create a worker that wakes up every 5 minutes and deletes quotes that were created more than 24 hour ago.
- [ ] Create a feature where users can subscribe for receiving daily quotes by providing their email or phone number. 
- [ ] Create a worker that sends daily quotes via email or SMS based on users preference
- [x] Add Swagger documentation for the API

### Pins

  * Language of development C# on .NET Core
  * Data exchange format between client and server is JSON
  * All data is stored in an in-memory database.

### Launch Project

```shell
dotnet run
```
