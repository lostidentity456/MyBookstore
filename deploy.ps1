# Online Bookstore Management System Deployment Script
# This script deploys the entire system using Docker Compose

Write-Host "Starting Online Bookstore Management System Deployment..." -ForegroundColor Green

# Check if Docker is running
try {
    docker version | Out-Null
    Write-Host "Docker is running" -ForegroundColor Green
} catch {
    Write-Host "Docker is not running. Please start Docker Desktop and try again." -ForegroundColor Red
    exit 1
}

# Check if Docker Compose is available
try {
    docker-compose version | Out-Null
    Write-Host "Docker Compose is available" -ForegroundColor Green
} catch {
    Write-Host "Docker Compose is not available. Please install Docker Compose and try again." -ForegroundColor Red
    exit 1
}

# Stop any existing containers
Write-Host "Stopping existing containers..." -ForegroundColor Yellow
docker-compose down

# Build and start the services
Write-Host "Building and starting services..." -ForegroundColor Yellow
docker-compose up --build -d

# Wait for services to be ready
Write-Host "Waiting for services to be ready..." -ForegroundColor Yellow
Start-Sleep -Seconds 30

# Check if services are running
Write-Host "Checking service status..." -ForegroundColor Yellow
docker-compose ps

# Display access information
Write-Host "`nDeployment completed successfully!" -ForegroundColor Green
Write-Host "`nAccess URLs:" -ForegroundColor Cyan
Write-Host "Web Application: http://localhost:7000" -ForegroundColor White
Write-Host "API Documentation: http://localhost:7001/swagger" -ForegroundColor White
Write-Host "Database: localhost:1433" -ForegroundColor White

Write-Host "`nDefault Admin Credentials:" -ForegroundColor Cyan
Write-Host "Email: admin@bookstore.com" -ForegroundColor White
Write-Host "Password: Admin123!" -ForegroundColor White

Write-Host "`nTo view logs:" -ForegroundColor Cyan
Write-Host "docker-compose logs -f" -ForegroundColor White

Write-Host "`nTo stop the system:" -ForegroundColor Cyan
Write-Host "docker-compose down" -ForegroundColor White
