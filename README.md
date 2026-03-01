## 🟦 BossTodoMvc — Clean Architecture ASP.NET Core 8 Showcase

### Overview

BossTodoMvc is a production-ready ASP.NET Core 8 MVC application designed to demonstrate clean architecture principles, layered separation of concerns, and server-side business logic orchestration, domain-driven design principles, and cloud-ready deployment practices

The project showcases enterprise-ready patterns including:

* Service Layer abstraction
* Repository pattern
* Domain-driven entity encapsulation
* Cookie-based authentication
* Cloud deployment (Railway + Neon PostgreSQL)
* Server-side filtering and sorting logic
* Responsive UI design

This project is intentionally structured to reflect real-world enterprise web application architecture.

---

### Architecture

Layered design:

* Domain Layer
  Encapsulated entities with behavior methods (ToggleComplete, UpdateTitle).
  Read-only properties
  State transitions via domain methods:

  * `ToggleComplete()`
  * `UpdateTitle()`
  * Prevents direct state mutation (DDD principle)

* Application Layer
  Service layer implementing business rules (sorting, filtering, orchestration).
  Business logic orchestration:
  * Filtering
  * Sorting
  * Task creation
  * State changes
* No data access logic inside services

* Infrastructure Layer
  EF Core repository implementation with PostgreSQL (Neon cloud).
  Repository pattern (`ITodoRepository`)
  No business logic leakage

* Web Layer
  MVC Controllers, Razor Views, Cookie Authentication.
  Model validation & user feedback
  Query-string driven sorting (`?sort=completed`, etc.)

No business logic leaks into repository.

The project intentionally separates concerns across Domain, Application, Infrastructure, and Web layers to reflect real-world enterprise web application architecture.

This showcase highlights:

* Clean Architecture implementation
* Repository + Service pattern
* Domain-encapsulated entities
* Server-side filtering & sorting logic
* Cookie-based authentication
* PostgreSQL cloud integration (Neon)
* CI/CD deployment via Railway
* Responsive UI design

---

### Key Engineering Decisions

* Sorting logic controlled at service layer (not repository).
* Repository returns raw dataset (no enforced ordering).
* Domain entity properties are read-only — state changes via domain methods.
* Clean separation between authentication and business logic.

  Explicit Query-Driven Behavior

  Sorting is controlled via URL parameters:

  ```
  /Todos?sort=completed
  /Todos?sort=active
  /Todos?sort=oldest
  /Todos?sort=newest
  ```
  
  This demonstrates server-side orchestration and predictable routing behavior.

### Authentication & Security

* Cookie-based authentication
* Claims identity
* Model validation with user feedback
* Server-side validation for task operations
* Authorization attribute on controller
---

### ☁ Deployment Architecture

* Hosted on Railway
* PostgreSQL on Neon
* GitHub → CI/CD auto-deploy
* Release-mode publish verified before deployment
* Deployment Flow:
  ```
  Git Push → Railway Auto Build → Docker Publish (Release Mode) → Live Deployment
  ```
All deployments validated using:
```
  dotnet publish -c Release

## 🎨 UI & UX

* Responsive card-based layout
* Clear task state indicators
* Visual grouping via status dot
* Consistent button styling
* Server-driven state refresh (no JS framework dependency)

### What Project demonstrates

This project demonstrates:

* Production-oriented ASP.NET Core MVC design
* Cloud-hosted database integration
* DevOps awareness
* Clean layered architecture
* EF Core with PostgreSQL
* Cloud database integration
* CI/CD deployment pipelines
* Production debugging (Release-mode validation)
* Separation of business logic and persistence

* Clean separation of concerns
    
