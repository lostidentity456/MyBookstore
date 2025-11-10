# Use the official .NET 8 runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 8 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BookstoreManagementAPI/OnlineBookstoreManagementAPI.csproj", "BookstoreManagementAPI/"]
RUN dotnet restore "BookstoreManagementAPI/OnlineBookstoreManagementAPI.csproj"
COPY . .
WORKDIR "/src/BookstoreManagementAPI"
RUN dotnet build "OnlineBookstoreManagementAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineBookstoreManagementAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineBookstoreManagementAPI.dll"]
