FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GScrape/GScrape.csproj", "GScrape/"]
RUN dotnet restore "GScrape/GScrape.csproj"
COPY . .
WORKDIR "/src/GScrape"
RUN dotnet build "GScrape.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GScrape.csproj" -c Release -o /app/publish

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GScrape.dll"]