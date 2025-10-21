# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore dependencies
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy build output
COPY --from=build /app/publish .

# Set the port for Cloud Run
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Cloud Run requires the container to listen on this port
EXPOSE 8080

# Start the application
ENTRYPOINT ["dotnet", "Car.Rental.API.dll"]