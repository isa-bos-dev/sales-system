<div align="center">

[![English](https://img.shields.io/badge/English-4A90E2?style=for-the-badge&logoColor=white)](README.md)
[![Spanish](https://img.shields.io/badge/Spanish-FFDE59?style=for-the-badge&logoColor=white)](README_es.md)

# 🛒 Sales Web System (Clean Architecture)

A robust, enterprise-grade Sales and Point of Sale (POS) Web Application built with **ASP.NET Core (.NET 10)**, **SQL Server**, and **Clean Architecture**. Designed with strict separation of concerns, domain-driven boundaries, role-based authorization, dynamic reactive UI patterns, and comprehensive sales transaction auditing.

<!-- Tech Stack Badges -->
![.NET 10](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core_MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/Microsoft_SQL_Server-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-00599C?style=for-the-badge&logo=blueprint&logoColor=white)
![Bootstrap 5](https://img.shields.io/badge/Bootstrap_5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

</div>

---

## 🚀 Overview

This application serves as a complete Point of Sale and management platform for commercial businesses. It models real-world store operations: role-differentiated navigation (Administrator and Sales Staff), live product itemization with automated tax and subtotal calculations, dynamic SKU searches, and sale history filters.

The system is structured following **Clean Architecture principles**, strictly decoupling business entities and orchestration use cases from data persistence mechanisms, third-party integrations, and UI presentation delivery.

---

## ✨ Features

- **Role-Based Access Control (RBAC):**
  - **Administrator:** Unrestricted access to user maintenance, product catalogs, sales processing, password resets, and transaction reporting.
  - **Sales Staff:** Scoped workflow restricted to point-of-sale processing and customer order creation.
- **User & Security Management:**
  - Complete user maintenance (CRUD).
  - First-login forced password change workflows.
  - One-click administrator password reset capability.
- **Product Catalog Management:**
  - SKU code indexing, pricing, inventory stock controls, and product image handling via external service abstractions.
  - Live client-side and server-side keyword/SKU filtering.
- **Point of Sale (POS) Transaction Entry:**
  - Dynamic product search by SKU code or product title.
  - Real-time calculations for unit pricing, quantities, subtotal, sales tax (IGV), and grand totals.
- **Audit & History Inspection:**
  - Date-range filtering for comprehensive sales history tracking.
  - Granular modal inspection of itemized purchase lines per sale voucher.
- **Reactive UI Flow:**
  - Dynamic user experience leveraging asynchronous HTTP requests, modal previews, live validation badges, and interactive feedback without full page reloads.

---

## 🏗️ Clean Architecture Structure

The solution enforces clear layer boundaries and unidirectional dependency rules:


```

src/
├── Domain/                   # Enterprise core (Entities, business rules, enums, constants)
│   ├── Entities/             # User, Product, Sale, SaleDetail
│   └── Constants/            # User role constants and business types
├── Application/              # Use cases and application business rules
│   ├── Interfaces/           # Repository contracts and external service abstractions
│   └── Services/             # Orchestration logic and application services (e.g., ProductService)
├── Infrastructure/           # External systems, frameworks, and data access
│   ├── Context/              # EF Core database contexts and SQL Server configurations
│   ├── Migrations/           # Database version control scripts
│   ├── Repositories/         # Repository implementations
│   └── ExternalServices/     # Cloud/external image storage implementations
└── Presentation/             # Web entry point
└── System.Web/           # ASP.NET Core MVC (.NET 10) application, controllers, views, dynamic scripts

```

---

## 🛠️ Tech Stack

### Core Technologies
- **Runtime:** .NET 10
- **Framework:** ASP.NET Core MVC
- **Language:** C# 14
- **Database ORM:** Entity Framework Core
- **Database Engine:** Microsoft SQL Server
- **Architecture:** Clean Architecture (Domain, Application, Infrastructure, Presentation)

### Frontend & UI
- **Styling:** Bootstrap 5 & Custom CSS
- **Dynamic Interaction:** Asynchronous JavaScript / Fetch API (SPA-like reactive behavior)
- **Components:** Modals, dynamic tables, live previews, and interactive notifications

---

## 🚦 Getting Started

### Prerequisites
- [.NET SDK (v10.0+) ↗](https://dotnet.microsoft.com/)
- [SQL Server Express / LocalDB ↗](https://www.microsoft.com/sql-server/)
- [Visual Studio 2022+ / VS Code ↗](https://visualstudio.microsoft.com/)


### Setup & Installation

1. Clone the repository:
   ```bash
   git clone [https://github.com/isa-bos-dev/sales-systeme.git](https://github.com/isa-bos-dev/sales-system.git)
   cd sales-system-clean-architecture

    ```

2. Configure your database connection string in `src/Presentation/System.Web/appsettings.json`:
    ```json
    "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=SalesCleanDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```


3. Apply Entity Framework Core database migrations:
    ```bash
    dotnet ef database update --project src/Infrastructure --startup-project src/Presentation/System.Web
    ```


4. Run the web application:
    ```bash
    dotnet run --project src/Presentation/System.Web
    ```

---

## 📄 License

This project is licensed under **All Rights Reserved** for portfolio demonstration purposes only. See the [LICENSE](https://www.google.com/search?q=LICENSE) file for details.

