# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ["MicroServices/ApiGateway/ApiGateway.csproj", "ApiGateway/"]
COPY ["MicroServices/ApiGateway/global.json", "ApiGateway/"]

WORKDIR /app/ApiGateway
RUN dotnet restore "ApiGateway.csproj"

COPY MicroServices/ApiGateway/ .

RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5000 7000

ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "ApiGateway.dll"]
