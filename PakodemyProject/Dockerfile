#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PakodemyProject/PakodemyProject.csproj", "PakodemyProject/"]
COPY ["BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
COPY ["EntitiesLayer/EntitiesLayer.csproj", "EntitiesLayer/"]
RUN dotnet restore "PakodemyProject/PakodemyProject.csproj"
COPY . .
WORKDIR "/src/PakodemyProject"
RUN dotnet build "PakodemyProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PakodemyProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PakodemyProject.dll"]