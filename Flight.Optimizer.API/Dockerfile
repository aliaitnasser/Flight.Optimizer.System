FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Flight.Optimizer.API/Flight.Optimizer.API.csproj", "Flight.Optimizer.API/"]
RUN dotnet restore "Flight.Optimizer.API/Flight.Optimizer.API.csproj"
COPY . .
WORKDIR "/src/Flight.Optimizer.API"
RUN dotnet build "Flight.Optimizer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flight.Optimizer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flight.Optimizer.API.dll"]