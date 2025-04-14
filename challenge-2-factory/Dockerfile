FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["challenge-2-factory/challenge-2-factory.csproj", "challenge-2-factory/"]
RUN dotnet restore "challenge-2-factory/challenge-2-factory.csproj"
COPY . .
WORKDIR "/src/challenge-2-factory"
RUN dotnet build "challenge-2-factory.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "challenge-2-factory.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "challenge-2-factory.dll"]
