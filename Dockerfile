# Step 1: Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Step 2: Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["CalculatorApp.csproj", "./"]
RUN dotnet restore "CalculatorApp.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "CalculatorApp.csproj" -c Release -o /app/publish

# Step 3: Final stage, run the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CalculatorApp.dll"]
