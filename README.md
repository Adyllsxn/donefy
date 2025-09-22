# DONEFY

**Donefy** is a demonstration project that applies the best practices of modern backend development, combining **DDD (Domain-Driven Design)**, **Clean Architecture**, **CQRS**, and **Advanced EF Core** with **PostgreSQL**.  

The goal is to serve as a practical reference for how to structure a real-world project using **clean architecture and code best practices** in an **ASP.NET Core Web API** environment.

---

## ✨ Main Features

- ✅ **User authentication and authorization** with JWT support  
- 🔐 **Password recovery and reset** using secure tokens  
- ⚡ **API organized by folders** (not by classlibs), following Clean Architecture  
- 📚 **Implementation of SOLID principles** and Clean Code practices  
- 🌍 **CORS configuration** for secure and flexible API consumption  
- ⚙️ **Custom middleware** for logging, error handling, and response standardization  
- 📊 **CQRS pattern applied** (clear separation between commands and queries)  
- 🗂 **Advanced persistence with EF Core** and PostgreSQL  

---

## 🚀 Technologies Used

- **Backend**: ASP.NET Core 8 (Web API)  
- **Database**: PostgreSQL  
- **ORM**: Entity Framework Core (advanced implementations)  
- **Architecture**: DDD, Clean Architecture, CQRS  
- **Best Practices**: SOLID, Clean Code, Middleware, CORS  
- **Security**: JWT, Password recovery, Authorization policies  
- **Infrastructure**: Docker (planned), Swagger  

---

## 📁 Project Structure

```bash
DONEFY/
│
├── src/                            # Main source code
│   ├── Core/                       # Business and application layer
│   │   ├── Application/            # Use cases, DTOs, validations
│   │   ├── Domain/                 # Entities, aggregates, business rules
│   │   └── Infrastructure/         # Persistence, repositories, external services
│   │
│   ├── Presentation/               # API exposure layer
│   │   ├── Controllers/            # Web API controllers
│   │   ├── DTOs/                   # Data transfer objects
│   │   └── Filters/                # Global filters (e.g., exceptions, validations)
│   │
│   ├── Setup/                      # Project-wide configurations
│   │   ├── Extensions/             # Service and middleware extensions
│   │   ├── Middleware/             # Custom middlewares
│   │   └── Pipeline/               # Application pipeline configuration
│   │
│   ├── Shared/                     # Utilities and shared resources
│   │   ├── Constants/              # Global constants
│   │   └── Helpers/                # Helper/utility classes
│   │
│   ├── Donefy.csproj               # .NET project configuration file
│   ├── appsettings.json            # Main configuration
│   └── appsettings.Development.json # Development environment configuration
│
├── .gitignore                      # Git ignored files/folders
├── LICENSE                         # Project license (MIT or other)
└── README.md                       # Main project documentation
```

## How to Run the Project

```bash
# Clone this repository:
git clone https://github.com/Adyllsxn/donefy.git


# Navigate to the project folder:

```bash
cd donefy/src
```

### Configure the PostgreSQL database in the appsettings.json file

```bash
# Apply EF Core migrations:
dotnet ef database update
```

## 🚀 Run the Project

By default, the project runs on **HTTP**.  
Use one of the following commands to start it:

```bash
# Run normally (default: HTTP)
dotnet run

# Run with hot reload (HTTP profile)
dotnet watch run --launch-profile "http"

# Run with hot reload (HTTPS profile)
dotnet watch run --launch-profile "https"
```

## 🔧 Troubleshooting

### ⚠️ HTTPS Certificate Issues

If you encounter issues related to HTTPS certificates, you can regenerate the development certificate:

```bash
# Clean existing certificates
dotnet dev-certs https --clean

# Create and trust a new certificate
dotnet dev-certs https --trust
```

## 📘 Documentation

Check out the detailed documentation in the following files:

- [🗺️ API](doc/API.md)
- [🗺️ ARCHITECTURE](doc/ARCHITECTURE.md)
- [🗺️ SETUP](doc/SETUP.md)
