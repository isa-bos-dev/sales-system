<div align="center">

[![English](https://img.shields.io/badge/English-4A90E2?style=for-the-badge&logoColor=white)](README.md)
[![Spanish](https://img.shields.io/badge/Spanish-FFDE59?style=for-the-badge&logoColor=white)](README_es.md)

# 🛒 Sistema Web de Ventas (Clean Architecture)

Aplicación web empresarial de punto de venta (POS) y gestión de ventas desarrollada con **ASP.NET Core (.NET 10)**, **SQL Server** y **Arquitectura Limpia (Clean Architecture)**. Diseñada bajo una estricta separación de responsabilidades, control de acceso basado en roles, interfaces dinámicas reactivas y auditoría detallada de transacciones comerciales.

<!-- Badges de Tecnologías -->
![.NET 10](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core_MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/Microsoft_SQL_Server-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Arquitectura-Clean_Architecture-00599C?style=for-the-badge&logo=blueprint&logoColor=white)
![Bootstrap 5](https://img.shields.io/badge/Bootstrap_5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

</div>

---

## 🚀 Descripción General

Esta aplicación proporciona una solución integral para comercios y puntos de venta. Modela el ciclo comercial completo: navegación adaptada por perfiles (Administrador y Personal de Ventas), emisión de tickets en tiempo real con cálculo automatizado de impuestos y subtotales, búsqueda interactiva por SKU y filtrado avanzado en el historial de ventas.

El sistema implementa **Clean Architecture (Arquitectura Limpia)**, garantizando que el núcleo del negocio y los casos de uso permanezcan aislados de bases de datos, dependencias externas, librerías de persistencia y frameworks de presentación.

---

## ✨ Características Principales

- **Control de Acceso Basado en Roles (RBAC):**
  - **Administrador:** Acceso completo a mantenedores de usuarios, productos, registro de ventas, reseteo de claves y consulta global de historiales.
  - **Personal de Ventas:** Flujo enfocado exclusivamente a la realización y registro de tickets de venta.
- **Gestión de Usuarios y Seguridad:**
  - Mantenedor CRUD completo de usuarios.
  - Flujo de actualización forzosa de contraseña en el primer inicio de sesión.
  - Funcionalidad administrativa para restablecer contraseñas de forma inmediata.
- **Mantenedor de Catálogo de Productos:**
  - Gestión de códigos SKU, precios unitarios, niveles de stock y carga de imágenes mediante abstracciones de servicios externos.
  - Filtro interactivo en tiempo real por descripción o SKU.
- **Terminal de Punto de Venta (Nueva Venta):**
  - Búsqueda interactiva de productos por nombre o SKU.
  - Cálculo instantáneo de cantidades, subtotal, impuestos (IGV) y total final a liquidar.
- **Historial y Detalle de Comprobantes:**
  - Filtro por rangos de fecha para auditoría de transacciones.
  - Modal interactivo con el desglose exacto de los artículos que componen cada comprobante emitido.
- **Experiencia Dinámica y Reactiva:**
  - Integración fluida mediante peticiones asíncronas HTTP (POST), previsualizaciones, modales y alertas sin recargas completas de página.

---

## 🏗️ Estructura en Clean Architecture

La solución organiza el código en cuatro capas con reglas de dependencia estrictas:


```

src/
├── Domain/                   # Núcleo del negocio (Entidades, constantes, enums y reglas puras)
│   ├── Entities/             # User, Product, Sale, SaleDetail
│   └── Constants/            # Constantes de tipos de usuario
├── Application/              # Casos de uso y reglas de la aplicación
│   ├── Interfaces/           # Contratos de repositorios y servicios externos
│   └── Services/             # Orquestación de casos de uso (ej. ProductService)
├── Infrastructure/           # Persistencia y servicios externos
│   ├── Context/              # DbContext y mapeos con Entity Framework Core
│   ├── Migrations/           # Control de versiones del esquema SQL Server
│   ├── Repositories/         # Implementación de repositorios
│   └── ExternalServices/     # Implementación del almacenamiento de imágenes
└── Presentation/             # Punto de entrada Web
└── System.Web/           # Proyecto ASP.NET Core MVC (.NET 10), vistas, controladores y recursos dinámicos

```

---

## 🛠️ Stack Tecnológico

### Tecnologías Principales
- **Plataforma:** .NET 10
- **Framework Web:** ASP.NET Core MVC
- **Lenguaje:** C# 14
- **ORM:** Entity Framework Core
- **Base de Datos:** Microsoft SQL Server
- **Arquitectura:** Clean Architecture (Dominio, Aplicación, Infraestructura, Presentación)

### Frontend e Interfaz
- **Diseño:** Bootstrap 5 y estilos modulares
- **Interactividad Dinámica:** JavaScript Asíncrono / Fetch API
- **Componentes:** Modales, previsualizaciones en vivo, badges condicionales y alertas

---

## 🚦 Requisitos Previos e Instalación

### Requisitos Previos
- [.NET SDK (v10.0+) ↗](https://dotnet.microsoft.com/)
- [SQL Server Express / LocalDB ↗](https://www.microsoft.com/sql-server/)
- [Visual Studio 2022+ / VS Code ↗](https://visualstudio.microsoft.com/)



### Instalación y Puesta en Marcha

1. Clonar el repositorio:
   ```bash
   git clone [https://github.com/isa-bos-dev/sales-system.git](https://github.com/isa-bos-dev/sales-system.git)
   cd sales-system-clean-architecture
    ```

2. Configurar la cadena de conexión en `src/Presentation/System.Web/appsettings.json`:
    ```json
    "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=SalesCleanDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

3. Aplicar las migraciones de base de datos con Entity Framework Core:
    ```bash
    dotnet ef database update --project src/Infrastructure --startup-project src/Presentation/System.Web
    ```

4. Iniciar la aplicación web:
    ```bash
    dotnet run --project src/Presentation/System.Web

    ```

---

## 📄 Licencia

Este proyecto está registrado bajo **Todos los Derechos Reservados** con fines exclusivos de exhibición en portafolio profesional. Consulta el archivo [LICENSE](https://www.google.com/search?q=LICENSE) para más detalles.
