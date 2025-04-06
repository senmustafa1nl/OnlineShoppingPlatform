# 🌐 **Online Shopping Platform API**

## 📌 **Project Overview**

The **Online Shopping Platform API** is a backend e-commerce solution designed to manage products, orders, users, and the relationships between them. It offers a full suite of features to handle the core functionalities of an online shopping platform, such as:

- User registration and authentication
- Product management (CRUD operations)
- Order creation and order management
- Role-based access control for secure management

This project leverages **ASP.NET Core** for building scalable web APIs, **Entity Framework Core** for database access, **JWT (JSON Web Tokens)** for authentication, and **ASP.NET Core Identity** for managing users and roles. The system is designed to handle multiple user roles with different permissions, providing a secure and flexible environment for e-commerce.

### **Key Features**:

- **JWT Authentication and Authorization** for stateless security.
- **ASP.NET Core Identity** for user registration, authentication, and role management.
- **Role-Based Access Control (RBAC)** for different access levels (e.g., Admin, Customer).
- **ASP.NET Core Middleware** for centralized error handling.
- **Entity Framework Core** for seamless database management using a Code First approach.
- **Swagger** integration for interactive API documentation.
- **Fluent Validation** for validating incoming API requests.

---

## 🛠️ **Technologies Used**

This project utilizes a range of modern technologies and tools to create a secure, scalable, and user-friendly platform.

### **1. ASP.NET Core**

ASP.NET Core is the backbone of this project. It's an open-source, cross-platform web framework for building modern, high-performance web applications. It's used here to build a RESTful API to handle product, order, and user management.

Key features of ASP.NET Core in this project:
- Lightweight and fast.
- Supports dependency injection.
- High scalability for handling large-scale applications.

### **2. Entity Framework Core**

Entity Framework Core (EF Core) is an object-relational mapping (ORM) framework that facilitates interaction with the database. It allows developers to work with databases using C# objects, abstracting away complex SQL queries.

The project uses EF Core's **Code First** approach to generate database tables from C# models. The database schema is automatically created and updated through migrations.

Key benefits of EF Core:
- Simplifies CRUD operations.
- Tracks changes and automatically generates SQL queries for those changes.
- Database-agnostic, supporting a variety of database systems.

### **3. JWT Authentication**

**JSON Web Token (JWT)** is used for secure authentication. In this system, when a user logs in, a JWT is issued and must be included in the headers of subsequent requests to access protected routes. JWT tokens are lightweight, stateless, and provide an efficient way to manage user sessions.

Benefits of JWT include:
- **Stateless Authentication**: The server doesn’t need to keep track of user sessions.
- **Compact**: The token is compact and can be easily transmitted via HTTP headers.
- **Secure**: Signed tokens can’t be tampered with.

### **4. ASP.NET Core Identity**

ASP.NET Core Identity is used for handling user registration, login, password hashing, and role management. It provides an easy-to-use solution for managing users and roles with minimal configuration.

With ASP.NET Core Identity, we can:
- Handle user authentication securely.
- Manage roles and permissions (e.g., Admin, Customer).
- Ensure password safety with hashing and salting.

### **5. FluentValidation**

**FluentValidation** is a library used for validating incoming API requests. It provides a fluent interface to define validation rules for objects. By using FluentValidation, we ensure that our application only accepts valid data.

### **6. Swagger**

Swagger is used to document the API. The integrated Swagger UI allows developers to interact with the API directly from the browser, making it easier to test endpoints and understand the request/response formats.

---

## 🚀 **Project Setup and Installation**

### **Prerequisites**

Before running the project, ensure you have the following tools installed:

- **.NET 6.0 or later**: The runtime required to build and run the project.
- **SQL Server**: Or any database management system of your choice.
- **Visual Studio** (Windows) or **Visual Studio Code** (cross-platform) for development.
- **Git**: To clone the repository.

### **Clone the Repository**

First, clone the repository from GitHub to your local machine using the following command:

```bash
git clone https://github.com/username/online-shopping-platform-api.git
