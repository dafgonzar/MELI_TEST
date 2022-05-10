#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MeliTest.Api/MeliTest.Api.csproj", "MeliTest.Api/"]
COPY ["MeliTest.Intrastructure/MeliTest.Intrastructure.csproj", "MeliTest.Intrastructure/"]
COPY ["MeliTest.Core/MeliTest.Core.csproj", "MeliTest.Core/"]
RUN dotnet restore "MeliTest.Api/MeliTest.Api.csproj"
COPY . .
WORKDIR "/src/MeliTest.Api"
RUN dotnet build "MeliTest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeliTest.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeliTest.Api.dll"]