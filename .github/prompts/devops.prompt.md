# DevOps Engineering Custom Instructions

## Project Reference
When providing DevOps solutions for this project, refer to the README.md which describes:
- A Clean Architecture-based ASP.NET Core Web API project targeting .NET 9.0
- Solution organized with Domain, Application, Infrastructure, and Presentation layers
- Entity Framework Core for data access using SQL Server
- NUnit, Moq and in-memory database for testing

## CI/CD Pipeline Guidance

### Azure DevOps Pipeline Best Practices
- Use YAML-based pipelines with templates for reusability
- Implement multi-stage pipelines (Build → Test → Deploy)
- Use service connections for secure access to resources
- Store secrets in Azure Key Vault or Azure DevOps variable groups
- Implement branch policies requiring successful builds before merging
- Use Azure Artifacts for NuGet package management
- Implement automated testing with published test results
- Configure environment approvals for production deployments

### GitHub Actions Best Practices
- Use composite actions and reusable workflows to avoid duplication
- Implement workflow dispatch triggers for manual operations
- Use repository secrets for sensitive information
- Implement environment protection rules for production
- Use matrix builds for cross-platform testing (.NET on Windows/Linux/macOS)
- Cache NuGet packages and build outputs for faster builds
- Use GitHub Packages as artifact repository when appropriate
- Create dependency review and security scanning workflows
- Use GitHub CodeQL for static code analysis when building a GH Actions pipeline
- When building containers from Dockerfiles, use Trivy or similar tools for vulnerability scanning

## Container and Dockerfile Best Practices

### Container Best Practices
- Use multi-stage builds to minimize image size
- Use specific base image tags (not 'latest') for reproducible builds
- Run containers as non-root users for enhanced security
- Use environment variables for configuration
- Use read-only file systems where possible
- Use container registries with image scanning capabilities

### Security Best Practices
- Scan dependencies for vulnerabilities as part of CI process
- Implement least privilege principle in all infrastructure
- Use infrastructure as code with secure defaults
- Rotate credentials and access keys regularly
- Implement network segmentation in cloud deployments
- Use Web Application Firewalls for API protection
- Implement proper logging and monitoring
- Scan container images for security vulnerabilities
- Implement RBAC (Role-Based Access Control) for all services

## Infrastructure as Code
- Use Bicep, or Terraform for Azure resources
- Implement environment-specific configuration
- Use modules and templates for reusable components
- Follow immutable infrastructure patterns
- Implement infrastructure testing

When I generate DevOps solutions for you, I'll follow these guidelines while keeping implementations simple, secure, and maintainable.
