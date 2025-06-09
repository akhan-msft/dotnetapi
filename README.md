# dotnetapi

## Overview

This repository contains a Clean Architecture-based ASP.NET Core Web API project targeting .NET 9.0. The solution is organized for maintainability, testability, and scalability, following SOLID principles and best practices for modern .NET development.

---

## Projects

### 1. webapi
- **Type:** ASP.NET Core Web API
- **Target Framework:** .NET 9.0
- **Key Features:**
  - Clean Architecture: Domain, Application, Infrastructure, and Presentation layers
  - Entity Framework Core for data access (SQL Server)
  - OpenAPI/Swagger for API documentation
  - Newtonsoft.Json for advanced JSON serialization

### 2. tests.webapi
- **Type:** Unit Test Project
- **Target Framework:** .NET 9.0
- **Key Features:**
  - Uses NUnit for unit testing
  - Moq for mocking dependencies
  - In-memory database for EF Core tests
  - Test data builders/factories for complex arrangements

---

## Runtimes
- **.NET 9.0** (cross-platform: Windows, Linux, macOS)

---

## Build & Run Instructions

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (if using a real database; in-memory is used for tests)

### Build the Solution
```powershell
# From the root directory
dotnet build dotnetapi.sln
```

### Run the Web API
```powershell
dotnet run --project webapi/webapi.csproj
```
- The API will be available at `https://localhost:5001` or `http://localhost:5000` by default.

### Run the Tests
```powershell
dotnet test tests/tests.webapi/tests.webapi.csproj
```

---

## High-Level Project Directory Structure

```
dotnetapi/
│   dotnetapi.sln
│   README.md
│
├── app-user-prompts/
├── mockups/
├── tests/
│   └── tests.webapi/
└── webapi/
```

## Additional Notes
- For configuration, see `webapi/appsettings.json` and `appsettings.Development.json`.
- For database migrations, use EF Core CLI tools.
- For API documentation, Swagger UI is enabled by default.

---

## License
This project is licensed under the MIT License.
