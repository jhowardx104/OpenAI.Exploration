FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OpenAI.Exploration/OpenAI.Exploration.csproj", "OpenAI.Exploration/"]
RUN dotnet restore "OpenAI.Exploration/OpenAI.Exploration.csproj"
COPY . .
WORKDIR "/src/OpenAI.Exploration"
RUN dotnet build "OpenAI.Exploration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenAI.Exploration.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenAI.Exploration.dll"]
