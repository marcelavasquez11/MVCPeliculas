FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /src

COPY ["MVCPeliculas/MVCPeliculas.csproj", "MVCPeliculas/"]

RUN dotnet restore "MVCPeliculas/MVCPeliculas.csproj"

RUN dotnet tool install --global dotnet-ef --version 8.*
ENV PATH="$PATH:/root/.dotnet/tools"

COPY . .

WORKDIR "/src/MVCPeliculas"

RUN dotnet build "MVCPeliculas.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "MVCPeliculas.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "MVCPeliculas.dll"]