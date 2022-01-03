#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SnakesAndLadders.Console/SnakesAndLadders.Console.csproj", "src/SnakesAndLadders.Console/"]
COPY ["src/SnakesAndLadders.Domain/SnakesAndLadders.Domain.csproj", "src/SnakesAndLadders.Domain/"]
RUN dotnet restore "src/SnakesAndLadders.Console/SnakesAndLadders.Console.csproj"
COPY . .
WORKDIR "/src/src/SnakesAndLadders.Console"
RUN dotnet build "SnakesAndLadders.Console.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "SnakesAndLadders.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnakesAndLadders.Console.dll"]
