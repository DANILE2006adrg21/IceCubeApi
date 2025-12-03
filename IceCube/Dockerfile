# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["IceCube/IceCube.csproj", "IceCube/"]
RUN dotnet restore "IceCube/IceCube.csproj"

COPY . .
WORKDIR "/src/IceCube"
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IceCube.dll"]
