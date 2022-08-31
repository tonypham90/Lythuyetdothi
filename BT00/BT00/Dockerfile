FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BT00/BT00.csproj", "BT00/"]
RUN dotnet restore "BT00/BT00.csproj"
COPY . .
WORKDIR "/src/BT00"
RUN dotnet build "BT00.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BT00.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BT00.dll"]
