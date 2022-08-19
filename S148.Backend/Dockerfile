FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["S148.Backend/S148.Backend.csproj", "S148.Backend/"]
RUN dotnet restore "S148.Backend/S148.Backend.csproj"
COPY . .
WORKDIR "/src/S148.Backend"
RUN dotnet build "S148.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "S148.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "S148.Backend.dll"]
