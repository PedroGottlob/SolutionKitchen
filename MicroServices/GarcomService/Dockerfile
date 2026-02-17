# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ["MicroServices/GarcomService/GarcomService.csproj", "GarcomService/"]
COPY ["MicroServices/GarcomService/global.json", "GarcomService/"]

WORKDIR /app/GarcomService
RUN dotnet restore "GarcomService.csproj"

COPY MicroServices/GarcomService/ .

RUN dotnet build "GarcomService.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "GarcomService.csproj" -c Release -o /app/publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5002 7002

ENV ASPNETCORE_URLS=http://+:5002

ENTRYPOINT ["dotnet", "GarcomService.dll"]
