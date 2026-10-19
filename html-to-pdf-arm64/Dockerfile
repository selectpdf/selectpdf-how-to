FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -f net10.0 -o /out

FROM mcr.microsoft.com/dotnet/runtime:10.0
# no apt-get: the Chromium closure ships in SelectPdf.Universal.Native.linux-arm64
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "/app/PdfSample.dll"]
