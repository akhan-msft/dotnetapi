# Generic React App from Figma Designs

## Overview
A concise prompt for generating production-ready React applications from any Figma design using modern best practices and design-to-code workflows.

## Prompt

```
Create a complete React TypeScript application based on my currently selected Figma designs. 

### Requirements:
- **Design Analysis**: Extract all design tokens, components, and user flows from Figma
- **Modern Stack**: React 18+, TypeScript, React Router v6, modern CSS practices
- **Component Architecture**: Atomic design with reusable components matching Figma designs
- **Asset Integration**: Download and integrate all Figma assets with fallback systems
- **Responsive Design**: Mobile-first approach matching Figma breakpoints
- **Type Safety**: Full TypeScript coverage with proper interfaces
- **State Management**: React hooks and context for app state
- **Navigation**: Route structure based on Figma page flow
- **Error Handling**: Proper boundaries, loading states, and user feedback
- **Development Ready**: Hot reload, linting, and build optimization

### Implementation:
1. Analyze Figma designs and extract design system (colors, typography, spacing)
2. Create component library based on Figma elements
3. Build pages matching exact Figma layouts
4. Implement responsive behavior and interactions
5. Set up proper routing and navigation
6. Include form validation and error states
7. Add loading and empty states
8. Generate comprehensive documentation

### Deliverables:
- Complete React project with clean architecture
- Components styled exactly to Figma specifications
- Working responsive design across all breakpoints
- Proper TypeScript types and interfaces
- README with component documentation
- Working development server

Start by analyzing my Figma selection and proceed with full implementation.
```

## Technical Patterns

### Project Structure
```
src/
├── components/
│   ├── ui/ (atomic components)
│   ├── layout/ (page layouts)
│   └── forms/ (form components)
├── pages/ (route components)
├── hooks/ (custom hooks)
├── types/ (TypeScript definitions)
├── styles/ (design system)
├── utils/ (helper functions)
└── assets/ (Figma downloads)
```

### Key Features
- **Design Token Extraction**: Automatic CSS custom properties from Figma
- **Component Generation**: UI components matching Figma elements exactly
- **Asset Pipeline**: Figma image download with optimization and fallbacks
- **Responsive Implementation**: CSS Grid/Flexbox matching Figma constraints
- **Form Handling**: React Hook Form with validation
- **Error Boundaries**: Graceful error handling throughout app
- **Performance**: Code splitting and lazy loading for optimal performance

### Best Practices Applied
- Atomic design methodology
- Accessibility standards (WCAG 2.1)
- SEO optimization
- Progressive enhancement
- Clean code principles
- Modern React patterns (hooks, context, suspense)

## Usage
This prompt works with any Figma design selection and generates a complete, production-ready React application without requiring specific backend integration or business logic assumptions.
