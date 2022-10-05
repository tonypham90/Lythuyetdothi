FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DOAN1/DOAN1.csproj", "DOAN1/"]
RUN dotnet restore "DOAN1/DOAN1.csproj"
COPY . .
WORKDIR "/src/DOAN1"
RUN dotnet build "DOAN1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOAN1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOAN1.dll"]
