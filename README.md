
# Tax Calculator

A basic tax calculator to demonstrate application structure and design patterns.

## Overview

The has been application using the Clean Architecure (or an interpretation of it). The Application & Domain sproject live at the centre and other projects depend on these.

The Domain project contains just the entities used within the application (just TaxBand) and contains no business logic.

The **Application** project contaions the implementation of the actual logic required, in this case calculating tax based on multiple tax bands. This exposes interfaces for any external functionality it requires, for example, persisting data to a store.
In this case, the **Application** project exposes an `IPersistence` interface which the **Infrastructure** project implements with the help of Entity Framework.

In theory, the user interface project (Blazor) will only depend on the **Application** project. In practice, it also depends on **Infrastructure** so it can setup dependency injection.

```
Infrastructure       User Interface (Blazor)
      |                    |
      |        ┍-----------┙
      ↓        ↓
Application & Domain
      ↑
      |
      |
Other External Dependency (e.g. Email sender service)
```

## Testing

A test project **Application.Tests** has been created to test the application functionality (it depends only on **Application**, not on  **Infrastructure**).

Future improvements could include testing the infrastructure (integration tests) and user interface.

## Third Party Libraries Used

The following open source libraries were used as part of the application:

| Name | Licence | Purpose |
| --- | --- | --- |
| FluentValidation | Apache-2.0 | Create powerful and validation rules |
| Blazored.FluentValidation | MIT | Blazor extension for FluentValidation |
| MediatR | Apache-2.0 | Mediate requests from UI to application |
| Moq | BSD-3-Clause | Mocks classes/interfaces for testing |
| MockQueryable | MIT | Mocks IQueryable interface to emulate Entity Framework |
