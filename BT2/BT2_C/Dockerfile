FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BT2_C/BT2_C.csproj", "BT2_C/"]
RUN dotnet restore "BT2_C/BT2_C.csproj"
COPY . .
WORKDIR "/src/BT2_C"
RUN dotnet build "BT2_C.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BT2_C.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BT2_C.dll"]
