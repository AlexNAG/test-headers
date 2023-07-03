FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["TestHeadersWebApi/TestHeadersWebApi.csproj", "TestHeadersWebApi/"]
RUN dotnet restore "TestHeadersWebApi/TestHeadersWebApi.csproj"
COPY . .
WORKDIR "/src/TestHeadersWebApi"
RUN dotnet build "TestHeadersWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestHeadersWebApi.csproj" -c Release -o /app/publish -r win-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestHeadersWebApi.dll"]
