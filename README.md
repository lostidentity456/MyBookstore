# 📚 Online Bookstore Management System

A comprehensive, full-stack online bookstore management system built with ASP.NET Core 8.0, featuring a RESTful API and modern web interface.

## 🚀 Features

### For Customers
- **Book Catalog**: Browse thousands of books with advanced search and filtering
- **User Authentication**: Secure registration and login system
- **Order Management**: Place orders and track order status
- **Book Reviews**: Rate and review books
- **Wishlist**: Save books for later purchase
- **Recommendations**: Personalized book recommendations

### For Store Owners/Admins
- **Complete Book Management**: Add, edit, and manage book inventory
- **Order Processing**: Manage orders and update status
- **User Management**: Manage customer accounts
- **Analytics Dashboard**: Comprehensive sales and performance reports
- **Inventory Management**: Track stock levels and low stock alerts
- **Category & Author Management**: Organize books by categories and authors

### Technical Features
- **RESTful API**: Well-documented API with Swagger integration
- **JWT Authentication**: Secure token-based authentication
- **Role-based Authorization**: Admin, Store Owner, and Customer roles
- **Payment Processing**: Integrated payment system with refund capabilities
- **Advanced Search**: Full-text search with filters
- **Recommendation Engine**: AI-powered book recommendations
- **Analytics & Reporting**: Comprehensive business intelligence
- **Responsive Design**: Mobile-first, responsive web interface
- **Docker Support**: Containerized deployment

## 🏗️ Architecture

### Backend (API)
- **Framework**: ASP.NET Core 8.0 Web API
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **Documentation**: Swagger/OpenAPI
- **Testing**: xUnit with Moq

### Frontend (Web)
- **Framework**: ASP.NET Core 8.0 MVC
- **UI**: Bootstrap 5 with custom CSS
- **Icons**: Font Awesome
- **JavaScript**: Vanilla JS with jQuery

### Database Schema
- **Users**: Customer and admin management
- **Books**: Complete book information with inventory
- **Orders**: Order processing and tracking
- **Payments**: Payment processing and refunds
- **Reviews**: User reviews and ratings
- **Recommendations**: AI-powered recommendations
- **Analytics**: Business intelligence data

## 🚀 Quick Start

### Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code
- Docker Desktop (for containerized deployment)

### Option 1: Local Development

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd PRN232_Project
   ```

2. **Start the API**
   ```bash
   cd BookstoreManagementAPI
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

3. **Start the Web Application**
   ```bash
   cd BookstoreManagement
   dotnet restore
   dotnet run
   ```

4. **Access the applications**
   - Web App: https://localhost:7000
   - API: https://localhost:7001
   - API Docs: https://localhost:7001/swagger

### Option 2: Docker Deployment

1. **Deploy with Docker Compose**
   ```bash
   # Windows
   .\deploy.ps1
   
   # Linux/Mac
   docker-compose up --build -d
   ```

2. **Access the applications**
   - Web App: http://localhost:7000
   - API: http://localhost:7001
   - API Docs: http://localhost:7001/swagger

## 🔐 Default Credentials

- **Admin Email**: admin@bookstore.com
- **Admin Password**: Admin123!

## 📊 API Endpoints

### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/register` - User registration
- `GET /api/auth/me` - Get current user

### Books
- `GET /api/books` - Get all books
- `GET /api/books/{id}` - Get book by ID
- `GET /api/books/search?q={term}` - Search books
- `GET /api/books/featured` - Get featured books
- `POST /api/books` - Create book (Admin/Store Owner)
- `PUT /api/books/{id}` - Update book (Admin/Store Owner)

### Orders
- `GET /api/orders` - Get all orders (Admin/Store Owner)
- `GET /api/orders/my-orders` - Get user's orders
- `POST /api/orders` - Create order
- `PUT /api/orders/{id}/status` - Update order status

### Analytics
- `GET /api/analytics/dashboard-summary` - Get dashboard summary
- `GET /api/analytics/sales-report` - Get sales report
- `GET /api/analytics/top-selling-books` - Get top selling books

### Recommendations
- `GET /api/recommendations/user/{userId}` - Get user recommendations
- `GET /api/recommendations/trending` - Get trending books
- `GET /api/recommendations/new-releases` - Get new releases

## 🧪 Testing

### Run Unit Tests
```bash
cd BookstoreManagementAPI.Tests
dotnet test
```

### Run Integration Tests
```bash
# Start the API
cd BookstoreManagementAPI
dotnet run

# Run tests in another terminal
cd BookstoreManagementAPI.Tests
dotnet test
```

## 📈 Performance Features

- **Caching**: In-memory caching for frequently accessed data
- **Pagination**: Efficient data pagination
- **Lazy Loading**: Optimized database queries
- **Compression**: Response compression
- **CDN Ready**: Static file optimization

## 🔒 Security Features

- **JWT Authentication**: Secure token-based authentication
- **Role-based Authorization**: Granular permission system
- **Password Hashing**: BCrypt password hashing
- **CORS Configuration**: Cross-origin request security
- **Input Validation**: Comprehensive input validation
- **SQL Injection Protection**: Entity Framework parameterized queries

## 📱 Mobile Support

- **Responsive Design**: Mobile-first approach
- **Touch-friendly**: Optimized for touch devices
- **Progressive Web App**: PWA capabilities
- **Offline Support**: Basic offline functionality

## 🚀 Deployment

### Production Deployment
1. Update connection strings in `appsettings.Production.json`
2. Configure JWT settings
3. Set up SSL certificates
4. Deploy to Azure/AWS/GCP

### Docker Deployment
```bash
# Build and run
docker-compose up --build -d

# View logs
docker-compose logs -f

# Stop services
docker-compose down
```

## 📚 Documentation

- **API Documentation**: Available at `/swagger` endpoint
- **Code Documentation**: Comprehensive XML documentation
- **Database Schema**: Entity Framework migrations
- **Deployment Guide**: Step-by-step deployment instructions

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new features
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🆘 Support

For support and questions:
- Create an issue in the repository
- Contact the development team
- Check the documentation

## 🎯 Roadmap

- [ ] Mobile app (React Native/Flutter)
- [ ] Advanced analytics dashboard
- [ ] Multi-language support
- [ ] Advanced recommendation algorithms
- [ ] Real-time notifications
- [ ] Social features (reviews, sharing)
- [ ] Subscription model
- [ ] Advanced inventory management

---

**Built with ❤️ using ASP.NET Core 8.0**
