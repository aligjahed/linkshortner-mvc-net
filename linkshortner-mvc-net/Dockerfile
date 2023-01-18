FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["linkshortner-mvc-net/linkshortner-mvc-net.csproj", "linkshortner-mvc-net/"]
RUN dotnet restore "linkshortner-mvc-net/linkshortner-mvc-net.csproj"
COPY . .
WORKDIR "/src/linkshortner-mvc-net"
RUN dotnet build "linkshortner-mvc-net.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "linkshortner-mvc-net.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "linkshortner-mvc-net.dll"]
