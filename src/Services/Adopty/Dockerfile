FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
WORKDIR /src
COPY ["Services/Adopty/Adopty.csproj", "Services/Adopty/"]
COPY ["Services/Identity/Identity.Contracts/Identity.Contracts.csproj", "Services/Identity/Identity.Contracts/"]
RUN dotnet restore "Services/Adopty/Adopty.csproj"
COPY . .
WORKDIR /src/Services/Adopty
RUN dotnet publish "Adopty.csproj" -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adopty.dll"]