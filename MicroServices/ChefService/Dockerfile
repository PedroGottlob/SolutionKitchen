# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ["MicroServices/ChefService/ChefService.csproj", "ChefService/"]
COPY ["MicroServices/ChefService/global.json", "ChefService/"]

WORKDIR /app/ChefService
RUN dotnet restore "ChefService.csproj"

COPY MicroServices/ChefService/ .

RUN dotnet build "ChefService.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "ChefService.csproj" -c Release -o /app/publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5001 7001

ENV ASPNETCORE_URLS=http://+:5001

ENTRYPOINT ["dotnet", "ChefService.dll"]
