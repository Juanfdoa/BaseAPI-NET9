# Base API

A reusable ASP.NET Core 9 Web API template built using **Clean Architecture**, **JWT Authentication**, **ASP.NET Identity**, and **FluentValidation**.

This repository serves as the foundation for future projects by providing a clean, scalable, and maintainable architecture.

---

# Architecture

The solution follows the principles of Clean Architecture.

```
BaseApi.Api
│
├── Controllers
├── Middlewares
├── Filters
├── Configurations
└── Extensions

BaseApi.Application
│
├── Constants
├── DTOs
├── Interfaces
├── Validators
├── Services
├── Exceptions
└── Mappings

BaseApi.Domain
│
├── Entities
├── Enums
└── Common

BaseApi.Infrastructure
│
├── Identity
├── Services
├── Templates
├── Configurations
└── Persistence
```

---

# Features

- ASP.NET Core 9
- Clean Architecture
- Entity Framework Core
- ASP.NET Identity
- JWT Authentication
- FluentValidation
- Global Exception Middleware
- Swagger
- Email Templates (HTML + Scriban)
- Password Recovery
- Password Change

---

# Authentication

Implemented endpoints:

| Endpoint | Description |
|----------|-------------|
| POST /auth/register | Register a new user |
| POST /auth/login | Authenticate user |
| GET /auth/me | Get current authenticated user |
| POST /auth/forgot-password | Generate password reset token |
| POST /auth/reset-password | Reset password |
| POST /auth/change-password | Change password |

---

# Validation

Request validation is implemented using FluentValidation.

Validators are automatically executed through a Validation Filter.

---

# Exception Handling

Global exception handling is implemented using Middleware.

Common exceptions:

- ValidationException
- BadRequestException
- NotFoundException
- UnauthorizedException
- ForbiddenException

---

# Email Templates

Email templates are stored as HTML files inside:

```

Infrastructure/Templates

```

Templates are rendered using Scriban.

---

# Project Goals

This project is intended to be used as a reusable starting point for new ASP.NET Core Web APIs.

The focus is:

- Clean Architecture
- Maintainability
- Scalability
- Separation of Concerns
- SOLID Principles

---

# Branches

| Branch | Description |
|---------|-------------|
| base | Stable reusable template |