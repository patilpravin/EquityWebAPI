#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Equity.Positions.Web.API/Equity.Positions.Web.API.csproj", "Equity.Positions.Web.API/"]
RUN dotnet restore "Equity.Positions.Web.API/Equity.Positions.Web.API.csproj"
COPY . .
WORKDIR "/src/Equity.Positions.Web.API"
RUN dotnet build "Equity.Positions.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Equity.Positions.Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Equity.Positions.Web.API.dll"]