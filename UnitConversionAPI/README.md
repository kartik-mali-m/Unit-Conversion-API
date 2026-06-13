# Unit Conversion API

## Overview

Unit Conversion API is an ASP.NET Core Web API developed using .NET 8. It allows users to convert values between different measurement units.

### Supported Categories

- Length
- Temperature
- Weight

## Technologies Used

- C#
- ASP.NET Core Web API (.NET 8)
- Swagger/OpenAPI
- Dependency Injection
- Middleware for Global Exception Handling

## Project Structure

```text
UnitConversionAPI
│
├── Constants
├── Controllers
├── Enums
├── Exceptions
├── Middleware
├── Models
│   ├── Request
│   └── Response
├── Service
│   ├── Implementations
│   └── Interfaces
├── Program.cs
├── appsettings.json
└── UnitConversionAPI.csproj
```

## Features

- Length Conversion (Meter ↔ Feet)
- Temperature Conversion (Celsius ↔ Fahrenheit)
- Weight Conversion (Kilogram ↔ Pound)
- Global Exception Handling
- Swagger API Documentation

## Running the Application

### 1. Clone the repository

```bash
git clone <repository-url>
```

### 2. Open the solution in Visual Studio

Open the `UnitConversionAPI.sln` file.

### 3. Run the application

Press:

```text
F5
```

or execute:

```bash
dotnet run
```

### 4. Open Swagger UI

```text
https://localhost:xxxx/swagger
```

## API Endpoint

### POST

```text
/api/Conversion
```

## Sample Request

```json
{
  "category": "Temperature",
  "fromUnit": "Celsius",
  "toUnit": "Fahrenheit",
  "value": 25
}
```

## Sample Response

```json
{
  "category": "Temperature",
  "fromUnit": "Celsius",
  "toUnit": "Fahrenheit",
  "inputValue": 25,
  "convertedValue": 77
}
```

## Design Decisions

- Used a Service Layer to separate business logic from controllers.
- Implemented Global Exception Handling using middleware.
- Added XML documentation to improve API documentation.
- Organized the project into separate folders for better maintainability and readability.
- Designed the application to support future enhancements and additional conversion categories.

## Future Improvements

- Add support for more conversion categories.
- Store conversion factors in a database.
- Add unit tests using xUnit.
- Add request validation using FluentValidation.
