FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ConsoleChat.csproj ./
RUN dotnet restore ConsoleChat.csproj
COPY . ./
RUN dotnet publish ConsoleChat.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 7891
ENTRYPOINT ["dotnet", "ConsoleChat.dll"]