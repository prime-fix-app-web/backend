# Build and runtime Dockerfile for PrimeFixPlatform.API using ASP.NET Core 9.0
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore separately for caching
COPY PrimeFixPlatform.API/PrimeFixPlatform.API.csproj PrimeFixPlatform.API/
RUN dotnet restore PrimeFixPlatform.API/PrimeFixPlatform.API.csproj

# Copy everything else
COPY . .
WORKDIR /src/PrimeFixPlatform.API
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Configure runtime environment
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080

# Copy published app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PrimeFixPlatform.API.dll"]