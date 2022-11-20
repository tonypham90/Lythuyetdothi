FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cau2/Cau2.csproj", "Cau2/"]
RUN dotnet restore "Cau2/Cau2.csproj"
COPY . .
WORKDIR "/src/Cau2"
RUN dotnet build "Cau2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cau2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cau2.dll"]
