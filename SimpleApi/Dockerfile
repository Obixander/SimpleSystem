# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Restore dependencies
COPY SimpleApi/SimpleApi.csproj SimpleApi/

RUN dotnet restore SimpleApi/SimpleApi.csproj

# Copy the rest of the source code
COPY . ./

# Publish the application
RUN dotnet publish SimpleApi/SimpleApi.csproj -c Release -o out

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy necessary files from the build stage
COPY --from=build /app/out .

# Expose port 7139 for the API
EXPOSE 7139

# Start the Web API
ENTRYPOINT ["dotnet", "SimpleApi.dll"]