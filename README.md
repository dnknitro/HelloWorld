# HelloWorld

## Description

An interview task project with one business requirement: write "Hello World" to the console.

## Projects

-   `HelloWorldResService` - REST service which provides greeting message. Supports Swagger documentation: http://localhost:52289/swagger/index.html
-   `HelloWorldApp` - console application which prints greeting message obtained from API to the console.
-   `HelloWorldDomain` - business/domain layer.
-   `HelloWorldDomain.Tests` - unit tests

## Launching

-   Start `HelloWorldResService` first
-   Verify `HelloWorldApp` \ `appsettings.Development.json` \ `HelloWorldServiceBaseAddress` configuration key has correct domain / port value pointing to `HelloWorldResService`
-   Launch `HelloWorldApp`

## Unit tests

Just use standard `dotnet test` command line.
