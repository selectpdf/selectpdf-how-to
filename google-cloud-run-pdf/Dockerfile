FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish PdfApp.csproj -c Release -r linux-x64 --self-contained false -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app ./
# the image's non-root user; the engine needs no extra packages
USER $APP_UID
ENTRYPOINT ["dotnet", "PdfApp.dll"]
