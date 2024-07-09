#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Homer.Apresentation/Host/Homer.LoginApi/Homer.LoginApi.csproj", "Homer.Apresentation/Host/Homer.LoginApi/"]
COPY ["Homer.Application/Homer.Application/Homer.Application.csproj", "Homer.Application/Homer.Application/"]
COPY ["Homer.Domain/Homer.Domain.csproj", "Homer.Domain/"]
COPY ["Homer.Infrastructure/Homer.Infrastructure.csproj", "Homer.Infrastructure/"]
RUN dotnet restore "./Homer.Apresentation/Host/Homer.LoginApi/Homer.LoginApi.csproj"
COPY . .
WORKDIR "/src/Homer.Apresentation/Host/Homer.LoginApi"
RUN dotnet build "./Homer.LoginApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Homer.LoginApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Homer.LoginApi.dll"]