#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hotel-Management-Software/Hotel-Management-Software.API.csproj", "Hotel-Management-Software/"]
COPY ["Hotel-Management-Software.BussinessLogic/Hotel-Management-Software.BLL.csproj", "Hotel-Management-Software.BussinessLogic/"]
COPY ["Hotel-Management-Software.DAL/Hotel-Management-Software.DAL.csproj", "Hotel-Management-Software.DataAccess/"]
COPY ["Hotel-Management-Software/Hotel-Management-Software.DTO.csproj", "Hotel-Management-Software.DTO/"]
RUN dotnet restore "./Hotel-Management-Software/./Hotel-Management-Software.API.csproj"
COPY . .
WORKDIR "/src/Hotel-Management-Software"
RUN dotnet build "./Hotel-Management-Software.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hotel-Management-Software.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hotel-Management-Software.API.dll"]
