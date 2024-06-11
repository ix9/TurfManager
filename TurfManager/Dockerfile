FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

USER app
FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TurfManager/TurfManager.csproj", "TurfManager/"]
RUN dotnet restore "TurfManager/TurfManager.csproj"
COPY . .
WORKDIR "/src/TurfManager"
RUN dotnet build "TurfManager.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TurfManager.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TurfManager.dll"]
