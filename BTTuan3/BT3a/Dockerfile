FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BT3a/BT3a.csproj", "BT3a/"]
RUN dotnet restore "BT3a/BT3a.csproj"
COPY . .
WORKDIR "/src/BT3a"
RUN dotnet build "BT3a.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BT3a.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BT3a.dll"]
