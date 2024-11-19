FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY ./src/*.csproj ./
RUN dotnet restore

FROM base AS build
COPY ./src ./
RUN dotnet publish -c Release -o out

# Generate development certificate
RUN mkdir -p /https   # Ensure the directory exists
RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p password

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .
COPY --from=build /https/aspnetapp.pfx /https/aspnetapp.pfx
EXPOSE 5001

ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password

RUN adduser --disabled-password --gecos "" myuser
RUN chown -R myuser:myuser /app /https

USER myuser
ENTRYPOINT ["dotnet", "ToDoListAPI.dll"]