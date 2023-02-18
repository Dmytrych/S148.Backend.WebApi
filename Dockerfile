FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /etc/s148/
COPY . .
WORKDIR "/etc/s148/S148.Backend"
RUN dotnet restore "S148.Backend.csproj"
RUN dotnet build "S148.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "S148.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "S148.Backend.dll"]