FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /out

# Alpine: the app carries no engine, the selectpdf/engine container converts
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "/app/PdfSample.dll"]
