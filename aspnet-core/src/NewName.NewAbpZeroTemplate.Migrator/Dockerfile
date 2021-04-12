#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/NewName.NewAbpZeroTemplate.Migrator/NewName.NewAbpZeroTemplate.Migrator.csproj", "src/NewName.NewAbpZeroTemplate.Migrator/"]
COPY ["src/NewName.NewAbpZeroTemplate.EntityFrameworkCore/NewName.NewAbpZeroTemplate.EntityFrameworkCore.csproj", "src/NewName.NewAbpZeroTemplate.EntityFrameworkCore/"]
COPY ["src/NewName.NewAbpZeroTemplate.Core/NewName.NewAbpZeroTemplate.Core.csproj", "src/NewName.NewAbpZeroTemplate.Core/"]
COPY ["src/NewName.NewAbpZeroTemplate.Core.Shared/NewName.NewAbpZeroTemplate.Core.Shared.csproj", "src/NewName.NewAbpZeroTemplate.Core.Shared/"]
RUN dotnet restore "src/NewName.NewAbpZeroTemplate.Migrator/NewName.NewAbpZeroTemplate.Migrator.csproj"
COPY . .
WORKDIR "/src/src/NewName.NewAbpZeroTemplate.Migrator"
RUN dotnet build "NewName.NewAbpZeroTemplate.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewName.NewAbpZeroTemplate.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewName.NewAbpZeroTemplate.Migrator.dll"]
