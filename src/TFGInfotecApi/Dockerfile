#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["src/TFGInfotecApi/TFGInfotecApi.csproj", "src/TFGInfotecApi/"]
COPY ["src/TFGInfotecAbstractions/TFGInfotecAbstractions.csproj", "src/TFGInfotecAbstractions/"]
COPY ["src/TFGInfotecCore/TFGInfotecCore.csproj", "src/TFGInfotecCore/"]
COPY ["src/TFGInfotecInfrastructure/TFGInfotecInfrastructure.csproj", "src/TFGInfotecInfrastructure/"]

RUN dotnet restore "src/TFGInfotecApi/TFGInfotecApi.csproj"

# Copy the entire source code
COPY . .

WORKDIR "/src/src/TFGInfotecApi"
RUN dotnet build "TFGInfotecApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TFGInfotecApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TFGInfotecApi.dll"]
