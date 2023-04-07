FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ToNinetyOne.WebApi/ToNinetyOne.WebApi.csproj", "ToNinetyOne.WebApi/"]
RUN dotnet restore "ToNinetyOne.WebApi/ToNinetyOne.WebApi.csproj"
COPY . .
WORKDIR "/src/ToNinetyOne.WebApi"
RUN dotnet build "ToNinetyOne.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToNinetyOne.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToNinetyOne.WebApi.dll"]
