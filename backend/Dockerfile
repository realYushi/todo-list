# Builder stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY ./src/*.csproj ./
RUN dotnet restore
COPY ./src/ ./
RUN dotnet publish -c Release -o out

# Runner stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "ToDoListAPI.dll"]