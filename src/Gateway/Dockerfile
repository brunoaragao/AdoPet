FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
WORKDIR /src
COPY ["Gateway/Gateway.Api/Gateway.Api.csproj", "Gateway/Gateway.Api/"]
RUN dotnet restore "Gateway/Gateway.Api/Gateway.Api.csproj"
COPY . .
WORKDIR "/src/Gateway/Gateway.Api"
RUN dotnet publish "Gateway.Api.csproj" -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.Api.dll"]