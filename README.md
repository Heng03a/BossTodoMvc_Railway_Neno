## 🟦 BossTodoMvc — Clean Architecture ASP.NET Core 8 Showcase

### Overview

BossTodoMvc is a production-ready ASP.NET Core 8 MVC application designed to demonstrate clean architecture principles, layered separation of concerns, and server-side business logic orchestration.

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

* Application Layer
  Service layer implementing business rules (sorting, filtering, orchestration).

* Infrastructure Layer
  EF Core repository implementation with PostgreSQL (Neon cloud).

* Web Layer
  MVC Controllers, Razor Views, Cookie Authentication.

No business logic leaks into repository.

---

### Key Engineering Decisions

* Sorting logic controlled at service layer (not repository).
* Repository returns raw dataset (no enforced ordering).
* Domain entity properties are read-only — state changes via domain methods.
* Clean separation between authentication and business logic.

---

### Security

* Cookie-based authentication
* Claims identity
* Model validation with user feedback
* Server-side validation for task operations

---

### Deployment

* Hosted on Railway
* PostgreSQL on Neon
* GitHub → CI/CD auto-deploy
* Release-mode publish verified before deployment

---

### What Project demostrates

This project demonstrates:

* Production-oriented ASP.NET Core MVC design
* Cloud-hosted database integration
* DevOps awareness
* Clean separation of concerns
    
