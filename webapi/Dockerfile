# syntax=docker/dockerfile:1

# Build stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["webapi.csproj", "."]
RUN dotnet restore "webapi.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet publish "webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
USER app
ENTRYPOINT ["dotnet", "webapi.dll"]
