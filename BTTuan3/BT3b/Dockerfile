FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BT3b/BT3b.csproj", "BT3b/"]
RUN dotnet restore "BT3b/BT3b.csproj"
COPY . .
WORKDIR "/src/BT3b"
RUN dotnet build "BT3b.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BT3b.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BT3b.dll"]
