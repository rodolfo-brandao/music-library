

# Music Library

![Workflow: .NET](https://github.com/rodolfo-brandao/music-library/actions/workflows/dotnet-ci.yml/badge.svg)
![dotnet version](https://img.shields.io/badge/.NET-7_STS-blue)
![MIT License](https://img.shields.io/github/license/rodolfo-brandao/music-library)

## About
This is a *simple* portfolio project that I develop in my spare time (and which is still ongoing) that aims to provide a **REST API** built in [.NET](https://dotnet.microsoft.com/), to manage music-related content.

The intention of this project is not to present an application rich in business rules, but to expose a series of good practices, conventions and patterns that I am aware of.

## Setup
As this project was built using **.NET 7 Standard Term Support**, its [SDK](https://dotnet.microsoft.com/en-us/download) is required to run this application.

After installing it, just:

1. Clone the repository
```bash
$ git clone https://github.com/rodolfo-brandao/music-library
```

2. Enter the `src` directory
```bash
cd music-library/src
```

3. Restore, build and test the application
```bash
$ dotnet restore && dotnet build --no-restore && dotnet test --no-build --verbosity normal
```

4. Run locally
```bash
$ dotnet run --project MusicLibrary.Presentation/MusicLibrary.Presentation.csproj
```

After that, the application's Swagger will be available via HTTPS at `localhost:7233` ([here](https://localhost:7233/swagger/index.html)).

## Frameworks
- [x] .NET 7 STS
- [x] Entity Framework

## Concepts & Patterns
- [x] Code-First
- [x] Domain-driven Design
- [x] Fluent API
- [x] Repository
- [x] Unit of Work

## Notable Features
- [x] Bogus
- [x] FluentValidation
- [x] Fluent Assertions
- [x] MediatR
- [x] Moq
- [x] Serilog
- [x] SQLite
- [x] xUnit

## Data Model

<img src="assets/data-model.png" witdh="500" />

## Disclaimers
1. Despite having no relationship with the other entities in the data model, the **User** table was created only to allow the control of actions over the application's [CRUD](https://pt.wikipedia.org/wiki/CRUD). Where, to create and delete an entity, only users with `admin` access level can do such actions. As for queries, execution by any user is allowed.
	
	Furthermore, in order to demonstrate how a simple API authorization scheme can be implemented, such entity was elaborated.

2. Although not recommended, the configuration file `appsettings.development.json`, located in the *Presentation* layer, was kept in the repository only to illustrate the idea of a portfolio project, where the concept of this project does not represent any usability in the real world.

	Besides the fact that no sensitive or relevant information is exposed.

*PS: Feel free to disagree and provide counterpoints by contacting me or opening a pull-request.*

## Postman Collections
[music-library](postman-collections/music-library.json)

## License
[MIT License](LICENSE)
