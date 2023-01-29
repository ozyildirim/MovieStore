# Movie Store .NET Core Web API

Movie Store is an ASP.NET Core Web API which serves the domain of Customers, Movies, Directors and related actions.

## Domain

- Actor has Name, Surname and Movies.
- Director has Name and Surname.
- Customer has Name, Surname, Email and Password.
- Movie has Title, Year, Price, Actors and Director.
- Customer can have multiple Orders.

## Features

- CRUD operations for customers, movies, actors, directors and orders.
- Return customers and their orders.
- Return directors and their movies.
- Return actors and their movies.
- Add a new Movie Order for an existing Customer.
- JWT Authentication for Customers.

## Prerequirements

- .NET Core 7.0 SDK

## Frameworks/Tools used:

- .NET Core 7.0
- Entity Framework Core 7.0.2
- Npgsql
- AutoMapper
- xUnit
- FluentValidation
- Entity Framework Core InMemory DB
- Newtonsoft.JSON

### Database Configuration

The solution is configured to use a PostgreSQL DB.

<!-- ## Continuous Integration -->

### Testability

- Unit tests
