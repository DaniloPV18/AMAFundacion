# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

# Copia los archivos del proyecto y restaura las dependencias
COPY ./src/Backend/src ./
RUN dotnet restore "FundacionAMA.API/FundacionAMA.API.csproj"

# Compila y publica la aplicación en una sola etapa
RUN dotnet publish "FundacionAMA.API/FundacionAMA.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS final
WORKDIR /app
EXPOSE 7130
# Copia los archivos publicados desde la etapa de construcción
COPY --from=build /app/publish .

# Configura las variables de entorno necesarias
ENV ASPNETCORE_URLS=http://+:7130 \
    ASPNETCORE_ENVIRONMENT=Production


# Configura el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "FundacionAMA.API.dll"]
