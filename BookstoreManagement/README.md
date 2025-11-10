# Online Bookstore Management Web Interface

This is the web interface for the Online Bookstore Management System.

## Features

- **Book Catalog**: Browse and search through thousands of books
- **User Authentication**: Login and registration system
- **Order Management**: View and track your orders
- **Responsive Design**: Works on desktop, tablet, and mobile devices
- **Modern UI**: Clean, intuitive interface built with Bootstrap 5

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- The API project must be running (see BookstoreManagementAPI README)

### Setup

1. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

2. **Update API URL** in `appsettings.json` if needed:
   ```json
   {
     "ApiSettings": {
       "BaseUrl": "https://localhost:7001/api"
     }
   }
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

The web application will be available at `https://localhost:7000` and `http://localhost:5000`.

## Features Overview

### Home Page
- Featured books showcase
- Category browsing
- Search functionality
- Responsive hero section

### Books Section
- Complete book catalog
- Advanced search and filtering
- Book details with ratings and reviews
- Category and author filtering

### User Account
- User registration and login
- Order history and tracking
- Profile management

### Book Details
- Comprehensive book information
- Author and category details
- Stock availability
- Add to cart and wishlist (coming in next phases)

## Technologies Used

- ASP.NET Core MVC 8.0
- Bootstrap 5
- Font Awesome icons
- jQuery
- HTTP Client for API communication
- Session management

## Project Structure

```
BookstoreManagement/
├── Controllers/          # MVC Controllers
├── Models/              # View Models
├── Services/            # API Service layer
├── Views/               # Razor Views
│   ├── Home/           # Home page views
│   ├── Account/        # Authentication views
│   ├── Order/          # Order management views
│   └── Shared/         # Shared layouts and partials
└── wwwroot/            # Static files
    ├── css/            # Custom styles
    ├── js/             # JavaScript files
    └── lib/            # Third-party libraries
```

## Development Notes

- The web application communicates with the API through HTTP requests
- User authentication is handled via JWT tokens stored in session
- All book data is fetched from the API in real-time
- The design is fully responsive and mobile-friendly

## Next Steps

Future enhancements will include:
- Shopping cart functionality
- Payment processing
- Admin dashboard
- Advanced search with filters
- Book recommendations
- User reviews and ratings
