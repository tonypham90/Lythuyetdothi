FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BT1/BT1.csproj", "BT1/"]
RUN dotnet restore "BT1/BT1.csproj"
COPY . .
WORKDIR "/src/BT1"
RUN dotnet build "BT1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BT1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BT1.dll"]
