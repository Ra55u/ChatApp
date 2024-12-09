FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ChatAppCli.csproj ./
RUN dotnet restore ChatAppCli.csproj
COPY . ./
RUN dotnet publish ChatAppCli.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 7891
ENTRYPOINT ["dotnet", "ChatAppCli.dll"]