#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["obras_service/obras_service.csproj", "obras_service/"]
RUN dotnet restore "obras_service/obras_service.csproj"
COPY . .
WORKDIR "/src/obras_service"
RUN dotnet build "obras_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "obras_service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "obras_service.dll"]