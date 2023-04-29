FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Adopty/Adopty.Api/Adopty.Api.csproj", "Services/Adopty/Adopty.Api/"]
COPY ["Services/Adopty/Adopty.Application/Adopty.Application.csproj", "Services/Adopty/Adopty.Application/"]
COPY ["Services/Adopty/Adopty.Infrastructure/Adopty.Infrastructure.csproj", "Services/Adopty/Adopty.Infrastructure/"]
COPY ["Services/Adopty/Adopty.Domain/Adopty.Domain.csproj", "Services/Adopty/Adopty.Domain/"]
COPY ["Services/Identity/Identity.Contracts/Identity.Contracts.csproj", "Services/Identity/Identity.Contracts/"]
RUN dotnet restore "Services/Adopty/Adopty.Api/Adopty.Api.csproj"
COPY . .
WORKDIR "/src/Services/Adopty/Adopty.Api"
RUN dotnet build "Adopty.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Adopty.Api.csproj" -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adopty.Api.dll"]