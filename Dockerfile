# Use the official .NET 7 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.sln .
COPY QuickMartPOSWeb/*.csproj ./QuickMartPOSWeb/
RUN dotnet restore

# Copy everything else and build the release version
COPY . .
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 80
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "QuickMartPOSWeb.dll"]
