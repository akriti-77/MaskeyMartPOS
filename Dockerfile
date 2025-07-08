# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy solution and project files
COPY *.sln .
COPY QuickMartPOSWeb/*.csproj ./QuickMartPOSWeb/

# Restore dependencies
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/QuickMartPOSWeb
RUN dotnet publish -c Release -o out

# Stage 2: Run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/QuickMartPOSWeb/out ./
ENTRYPOINT ["dotnet", "QuickMartPOSWeb.dll"]
