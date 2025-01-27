# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Restore dependencies
# COPY SimpleApi.csproj SimpleApi/
COPY ["SimpleApi.csproj", "SimpleApi/"]

RUN dotnet restore SimpleApi/SimpleApi.csproj

# Copy the rest of the source code
WORKDIR /src/SimpleApi
COPY . .

RUN dotnet build "SimpleApi.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "SimpleApi.csproj" -c Release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy necessary files from the build stage
COPY --from=build /app/build .

# Expose port 7139 for the API
EXPOSE 7139

# Start the Web API
ENTRYPOINT ["dotnet", "SimpleApi.dll"]