# Base stage: Set up the common base for building the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY ./src/*.csproj ./
RUN dotnet restore

# Build stage: Compiles the application
FROM base AS build
COPY ./src ./
RUN dotnet publish -c Release -o out

# Test stage: Runs tests 
FROM build AS test
# Assuming test projects are copied similarly and use `dotnet test`
# Note: Adjust paths and project files as necessary
RUN dotnet test

# Production stage: Prepares the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS production
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 5000
RUN adduser --disabled-password --gecos "" myuser
USER myuser
ENTRYPOINT ["dotnet", "ToDoListAPI.dll"]
