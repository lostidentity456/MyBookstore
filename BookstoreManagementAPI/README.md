# Online Bookstore Management API

This is the API project for the Online Bookstore Management System.

## Features

- **Books Management**: CRUD operations for books with categories and authors
- **User Authentication**: JWT-based authentication with role-based authorization
- **Order Management**: Complete order processing and tracking
- **Search & Filtering**: Advanced search capabilities for books
- **RESTful API**: Clean, well-documented REST endpoints

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Setup

1. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

2. **Update connection string** in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=OnlineBookstoreDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Create and update database**:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:7001` and `http://localhost:5001`.

### API Documentation

Once running, visit `https://localhost:7001/swagger` for interactive API documentation.

## API Endpoints

### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/register` - User registration
- `GET /api/auth/me` - Get current user info
- `POST /api/auth/validate` - Validate token

### Books
- `GET /api/books` - Get all books
- `GET /api/books/{id}` - Get book by ID
- `GET /api/books/search?q={term}` - Search books
- `GET /api/books/category/{id}` - Get books by category
- `GET /api/books/author/{id}` - Get books by author
- `GET /api/books/featured` - Get featured books
- `POST /api/books` - Create book (Admin/Store Owner)
- `PUT /api/books/{id}` - Update book (Admin/Store Owner)
- `DELETE /api/books/{id}` - Delete book (Admin/Store Owner)

### Orders
- `GET /api/orders` - Get all orders (Admin/Store Owner)
- `GET /api/orders/my-orders` - Get user's orders
- `GET /api/orders/{id}` - Get order by ID
- `POST /api/orders` - Create order
- `PUT /api/orders/{id}/status` - Update order status (Admin/Store Owner)
- `PUT /api/orders/{id}/cancel` - Cancel order

### Categories
- `GET /api/categories` - Get all categories
- `GET /api/categories/{id}` - Get category by ID
- `POST /api/categories` - Create category (Admin/Store Owner)
- `PUT /api/categories/{id}` - Update category (Admin/Store Owner)
- `DELETE /api/categories/{id}` - Delete category (Admin/Store Owner)

### Authors
- `GET /api/authors` - Get all authors
- `GET /api/authors/{id}` - Get author by ID
- `POST /api/authors` - Create author (Admin/Store Owner)
- `PUT /api/authors/{id}` - Update author (Admin/Store Owner)
- `DELETE /api/authors/{id}` - Delete author (Admin/Store Owner)

## Authentication

The API uses JWT (JSON Web Tokens) for authentication. Include the token in the Authorization header:

```
Authorization: Bearer <your-jwt-token>
```

## Default Admin Account

After running the initial migration, you can use these credentials to login as admin:

- **Email**: admin@bookstore.com
- **Password**: Admin123!

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- JWT Authentication
- AutoMapper
- Swagger/OpenAPI
- BCrypt for password hashing
