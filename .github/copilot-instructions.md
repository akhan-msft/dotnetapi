## Architecture & Design
- Follow Clean Architecture principles with separate layers for domain, application, infrastructure, and presentation
- Use SOLID principles in all code suggestions, especially focusing on dependency injection
- Prefer interface-based programming for better testability and modularity

## Coding Standards
- Follow Microsoft's .NET coding conventions including PascalCase for public members and camelCase for parameters
- Use nullable reference types and proper null checking
- Use string interpolation instead of string concatenation
- Add XML documentation comments for public APIs
- Implement proper exception handling with custom exceptions when appropriate

## Testing
- Generate unit tests using NUnit with proper Arrange-Act-Assert pattern
- Use Moq for mocking dependencies in tests
- Use an in-memory database for database related unit tests
- Write tests that validate one behavior at a time with clear assertions
- Use test data builders or factory methods for complex test arrangements

## Async Programming
- Prefer async/await patterns when dealing with I/O operations
- Implement proper async error handling

## Configuration & Logging
- Use IOptions pattern for configuration management
- Implement logging using Microsoft.Extensions.Logging with appropriate log levels
- Use structured logging for better searchability

## Data & Validation
- Use Entity Framework Core best practices including DbContext design and migration patterns
- Implement repository pattern for data access when appropriate

## API Development
- Implement minimal APIs for REST endpoints when appropriate
- Use proper HTTP status codes and response formats
- Implement proper API versioning

## Security
- Follow OWASP guidelines for secure coding
- Use secure connection strings and credential management 
