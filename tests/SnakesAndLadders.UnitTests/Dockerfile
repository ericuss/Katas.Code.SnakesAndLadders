#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tests/SnakesAndLadders.UnitTests/SnakesAndLadders.UnitTests.csproj", "tests/SnakesAndLadders.UnitTests/"]
COPY ["src/SnakesAndLadders.Domain/SnakesAndLadders.Domain.csproj", "src/SnakesAndLadders.Domain/"]
RUN dotnet restore "tests/SnakesAndLadders.UnitTests/SnakesAndLadders.UnitTests.csproj"
COPY . .
WORKDIR "/src/tests/SnakesAndLadders.UnitTests"
RUN dotnet build "SnakesAndLadders.UnitTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnakesAndLadders.UnitTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
