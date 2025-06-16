# Security Analysis Custom Instructions

## Project Reference
When conducting security analysis for this project, refer to the README.md which describes:
- A Clean Architecture-based ASP.NET Core Web API project targeting .NET 9.0
- Solution organized with Domain, Application, Infrastructure, and Presentation layers
- Entity Framework Core for data access using SQL Server
- NUnit, Moq and in-memory database for testing

## Security Analysis Framework

### OWASP Top 10 Vulnerabilities Focus
- **A01:2021 - Broken Access Control**: Analyze authorization mechanisms and permissions
- **A02:2021 - Cryptographic Failures**: Review data encryption in transit and at rest
- **A03:2021 - Injection**: Search for SQL injection, NoSQL injection, and command injection vulnerabilities
- **A04:2021 - Insecure Design**: Review architecture for security-by-design principles
- **A05:2021 - Security Misconfiguration**: Analyze configuration files and deployment settings
- **A06:2021 - Vulnerable and Outdated Components**: Scan NuGet packages for vulnerabilities
- **A07:2021 - Identification and Authentication Failures**: Review authentication mechanisms
- **A08:2021 - Software and Data Integrity Failures**: Review supply chain security
- **A09:2021 - Security Logging and Monitoring Failures**: Assess logging configuration
- **A10:2021 - Server-Side Request Forgery**: Review external resource requests

### API Security Focus (OWASP API Security Top 10)
- **API1:2023 - Broken Object Level Authorization**: Check authorization for data access
- **API2:2023 - Broken Authentication**: Review token handling and session management
- **API3:2023 - Broken Object Property Level Authorization**: Verify property-level access control
- **API4:2023 - Unrestricted Resource Consumption**: Check for rate limiting and quotas
- **API5:2023 - Broken Function Level Authorization**: Verify endpoint authorization
- **API6:2023 - Unrestricted Access to Sensitive Business Flows**: Analyze business logic exploits
- **API7:2023 - Server Side Request Forgery**: Check for vulnerable URL handling
- **API8:2023 - Security Misconfiguration**: Review API security headers and configurations
- **API9:2023 - Improper Inventory Management**: Check for API versioning and deprecation
- **API10:2023 - Unsafe Consumption of APIs**: Review third-party API integrations

## Code Analysis Methodology

### Static Analysis
- .NET-specific code patterns for security vulnerabilities
- Input validation and output encoding practices
- Authentication and authorization implementations
- Secure data access patterns and EF Core usage
- Secret management and configuration handling

### Dynamic Analysis Guidance
- API fuzzing recommendations
- Authentication bypass testing approaches
- Injection testing methodologies
- Error handling and information disclosure testing

## Findings and Reporting Format

### Vulnerability Report Structure
Each identified vulnerability should include:
1. **Title**: Concise description of the issue
2. **Severity**: Critical, High, Medium, Low (with CVSS scoring when applicable)
3. **Description**: Technical details of the vulnerability
4. **Location**: Specific file paths and line numbers
5. **Evidence**: Code snippets or logs demonstrating the issue
6. **Impact**: Potential security consequences
7. **Remediation**: Specific steps to fix the issue
8. **References**: OWASP or other security guidelines related to this issue

### Actionable Issue Templates
For each vulnerability category:
- **Issue Title**: [Severity] Security Issue Type - Affected Component
- **Issue Description**:
  ```
  ## Description
  Brief description of the security issue

  ## Affected Files/Components
  - Path to file 1
  - Path to file 2

  ## Technical Details
  Detailed explanation with code examples

  ## Business Impact
  Explanation of potential impact to the business

  ## Recommended Fix
  Code example or specific instructions for remediation

  ## Acceptance Criteria
  - [ ] Vulnerability has been patched
  - [ ] Test cases demonstrate the fix
  - [ ] Security scan confirms resolution
  ```

## Remediation Planning

### Prioritization Framework
- **P0**: Critical issues - Fix immediately (auth bypasses, RCE, data breaches)
- **P1**: High issues - Fix within sprint (injection vulnerabilities, broken access control)
- **P2**: Medium issues - Schedule fix within 30 days (most crypto issues, XSS)
- **P3**: Low issues - Address in backlog (minor info disclosure, outdated components without known CVEs)

### Task Breakdown Strategy
Convert each vulnerability into:
1. Investigation task (if needed)
2. Implementation task with specific acceptance criteria
3. Verification task to confirm fix
4. Documentation update task if applicable

When I analyze code for security vulnerabilities, I'll provide findings in this structured format with actionable GitHub issues or Azure DevOps work items ready for implementation.
