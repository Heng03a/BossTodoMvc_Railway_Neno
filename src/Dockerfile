# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore src/BossTodoMvc.Web/BossTodoMvc.Web.csproj

RUN dotnet publish src/BossTodoMvc.Web/BossTodoMvc.Web.csproj \
    -c Release \
    -o /out \
    /p:UseAppHost=false

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /out .

ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
EXPOSE 8080

ENTRYPOINT ["dotnet", "BossTodoMvc.Web.dll"]
