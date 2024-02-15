FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LinksPairs_Bot/LinksPairs_Bot.csproj", "LinksPairs_Bot/"]
RUN dotnet restore "LinksPairs_Bot/LinksPairs_Bot.csproj"
COPY . .
WORKDIR "/src/LinksPairs_Bot"
RUN dotnet build "LinksPairs_Bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinksPairs_Bot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinksPairs_Bot.dll"]
