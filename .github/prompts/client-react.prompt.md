# React Client App Generation from Figma Designs

## Overview
This prompt creates a complete React SPA client application based on Figma designs, integrated with an existing .NET API backend. The process includes design analysis, component generation, API integration, and mock authentication implementation.

## Prerequisites
- Existing .NET API project with customer management endpoints
- Access to Figma designs via MCP server (user should have Figma designs selected)
- VS Code workspace with the backend API project

## Prompt

```
I need you to create a complete React SPA client application based on my Figma designs. Here's what I need:

### 1. Figma Design Analysis
- Analyze my currently selected Figma designs (should include registration and enrollment pages)
- Extract design tokens, colors, typography, and component patterns
- Get the company logo and any other visual assets from Figma
- Understand the user flow and page structure

### 2. React Project Setup
- Create a new React TypeScript project in a `customer-portal-spa` directory under the current workspace
- Set up the project with:
  - React Router v6 for navigation
  - Axios for API calls
  - TypeScript configuration
  - CSS variables matching Figma design tokens
  - Clean component architecture following React best practices

### 3. Component Architecture
Create the following components based on the Figma designs:
- **Header Component**: Company branding with logo and multi-level fallback system
- **InputField Component**: Reusable form input with validation styling
- **Button Component**: Styled button matching design system
- **Dropdown Component**: Styled select dropdown for forms

### 4. Page Components
Implement these main pages based on Figma designs:
- **RegistrationPage**: User registration form with email/password
- **EnrollmentPage**: Customer enrollment form with comprehensive fields
- **SuccessPage**: Confirmation page after successful enrollment

### 5. Services Layer
Create API integration services:
- **apiClient.ts**: Axios configuration with base URL and interceptors
- **customerService.ts**: Customer-related API calls with TypeScript interfaces
- Include auth service for token management

### 6. Mock Authentication Implementation
Since the backend registration API isn't fully implemented:
- Create a client-side mock registration that accepts any valid email/password
- Generate mock customer ID and JWT token
- Store auth data locally and navigate to enrollment page
- Include proper validation and error handling
- Add console logging for debugging

### 7. API Integration Setup
- Configure CORS in the existing .NET API to allow the React app
- Add a placeholder registration endpoint in the .NET CustomerController
- Ensure the React app can communicate with the API on the correct port

### 8. Styling and Assets
- Implement CSS design system matching Figma tokens
- Download and integrate company logo from Figma
- Create fallback system for logo loading (local → Figma → SVG fallback)
- Style all components to match the Figma designs exactly

### 9. Navigation and Routing
- Set up React Router with proper route structure
- Implement navigation flow: Registration → Enrollment → Success
- Handle authentication state and protected routes

### 10. Error Handling and Validation
- Client-side form validation for all inputs
- Proper error states and user feedback
- Loading states during API calls
- TypeScript interfaces for all data structures

### 11. Development Setup
- Ensure the React dev server starts without conflicts
- Configure proper build scripts
- Include development-friendly logging and debugging

### Requirements:
- Use TypeScript throughout
- Follow React best practices and hooks patterns
- Implement responsive design matching Figma
- Create reusable components
- Include proper error boundaries and loading states
- Generate comprehensive README documentation
- Mock authentication should work seamlessly without backend dependency

### Expected Deliverables:
1. Complete React project structure in `customer-portal-spa/` directory
2. All components styled to match Figma designs
3. Working registration flow with mock authentication
4. API service layer ready for backend integration
5. Proper TypeScript types and interfaces
6. Documentation explaining the mock implementation
7. Working development server
8. Logo integration with fallback system

Please start by analyzing my Figma designs and then proceed with the complete implementation.
```

## Technical Specifications

### Project Structure
```
customer-portal-spa/
├── public/
│   ├── index.html
│   ├── company-logo.png (from Figma)
│   └── logo-fallback.svg
├── src/
│   ├── App.tsx (main app with routing)
│   ├── index.tsx
│   ├── index.css (design system variables)
│   ├── components/
│   │   └── common/
│   │       ├── Header.tsx
│   │       ├── InputField.tsx
│   │       ├── Button.tsx
│   │       └── Dropdown.tsx
│   ├── pages/
│   │   ├── RegistrationPage.tsx
│   │   ├── EnrollmentPage.tsx
│   │   └── SuccessPage.tsx
│   └── services/
│       ├── apiClient.ts
│       └── customerService.ts
├── package.json
└── MOCK_REGISTRATION_README.md
```

### Key Dependencies
- React 18+
- TypeScript
- React Router v6
- Axios
- CSS custom properties

### Mock Registration Behavior
- Accepts any valid email format and password ≥8 characters
- Generates random customer ID (1000-9999)
- Creates mock JWT token with timestamp
- Simulates 1-second API delay for realistic UX
- Stores auth data in localStorage/sessionStorage
- Navigates to enrollment page on success
- Includes proper error handling and validation

### Integration Points
- React app runs on port 3001 (or next available)
- API backend expected on port 5012
- CORS configured to allow React app domain
- Placeholder registration endpoint in .NET API
- Ready for real API integration (easy to swap mock for real calls)

## Usage Notes
- This prompt should be used when you have Figma designs selected and ready
- Ensure your .NET API project is in the workspace
- The generated app will be fully functional with mock authentication
- Real API integration requires updating the customerService.register() method
- Logo fallback system handles cases where Figma assets aren't available

## Future Enhancements
When ready to implement real authentication:
1. Replace mock registration in `customerService.ts`
2. Implement proper JWT handling in .NET API
3. Add password hashing and database persistence
4. Update CORS policies for production
5. Add proper error handling for API failures
