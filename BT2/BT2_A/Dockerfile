FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BT2/BT2.csproj", "BT2/"]
RUN dotnet restore "BT2/BT2.csproj"
COPY . .
WORKDIR "/src/BT2"
RUN dotnet build "BT2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BT2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BT2.dll"]
