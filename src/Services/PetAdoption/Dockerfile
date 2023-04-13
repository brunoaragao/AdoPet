FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/PetAdoption/PetAdoption.Api/PetAdoption.Api.csproj", "Services/PetAdoption/PetAdoption.Api/"]
COPY ["Services/PetAdoption/PetAdoption.Application/PetAdoption.Application.csproj", "Services/PetAdoption/PetAdoption.Application/"]
COPY ["Services/PetAdoption/PetAdoption.Domain/PetAdoption.Domain.csproj", "Services/PetAdoption/PetAdoption.Domain/"]
COPY ["Services/PetAdoption/PetAdoption.Infrastructure/PetAdoption.Infrastructure.csproj", "Services/PetAdoption/PetAdoption.Infrastructure/"]
COPY ["Libraries/SeedWork/SeedWork.csproj", "Libraries/SeedWork/"]
RUN dotnet restore "Services/PetAdoption/PetAdoption.Api/PetAdoption.Api.csproj"
COPY . .
WORKDIR "/src/Services/PetAdoption/PetAdoption.Api"
RUN dotnet build "PetAdoption.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetAdoption.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetAdoption.Api.dll"]