FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Flight.Optimizer.System/Flight.Optimizer.System.csproj", "Flight.Optimizer.System/"]
RUN dotnet restore "Flight.Optimizer.System/Flight.Optimizer.System.csproj"
COPY . .
WORKDIR "/src/Flight.Optimizer.System"
RUN dotnet build "Flight.Optimizer.System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flight.Optimizer.System.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flight.Optimizer.System.dll"]