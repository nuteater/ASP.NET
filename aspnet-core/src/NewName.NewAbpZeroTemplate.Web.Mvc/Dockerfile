#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/NewName.NewAbpZeroTemplate.Web.Mvc/NewName.NewAbpZeroTemplate.Web.Mvc.csproj", "src/NewName.NewAbpZeroTemplate.Web.Mvc/"]
COPY ["src/NewName.NewAbpZeroTemplate.Web.Core/NewName.NewAbpZeroTemplate.Web.Core.csproj", "src/NewName.NewAbpZeroTemplate.Web.Core/"]
COPY ["src/NewName.NewAbpZeroTemplate.Application/NewName.NewAbpZeroTemplate.Application.csproj", "src/NewName.NewAbpZeroTemplate.Application/"]
COPY ["src/NewName.NewAbpZeroTemplate.Application.Shared/NewName.NewAbpZeroTemplate.Application.Shared.csproj", "src/NewName.NewAbpZeroTemplate.Application.Shared/"]
COPY ["src/NewName.NewAbpZeroTemplate.Core.Shared/NewName.NewAbpZeroTemplate.Core.Shared.csproj", "src/NewName.NewAbpZeroTemplate.Core.Shared/"]
COPY ["src/NewName.NewAbpZeroTemplate.Core/NewName.NewAbpZeroTemplate.Core.csproj", "src/NewName.NewAbpZeroTemplate.Core/"]
COPY ["src/NewName.NewAbpZeroTemplate.EntityFrameworkCore/NewName.NewAbpZeroTemplate.EntityFrameworkCore.csproj", "src/NewName.NewAbpZeroTemplate.EntityFrameworkCore/"]
COPY ["src/NewName.NewAbpZeroTemplate.GraphQL/NewName.NewAbpZeroTemplate.GraphQL.csproj", "src/NewName.NewAbpZeroTemplate.GraphQL/"]
RUN dotnet restore "src/NewName.NewAbpZeroTemplate.Web.Mvc/NewName.NewAbpZeroTemplate.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/NewName.NewAbpZeroTemplate.Web.Mvc"
RUN dotnet build "NewName.NewAbpZeroTemplate.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewName.NewAbpZeroTemplate.Web.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewName.NewAbpZeroTemplate.Web.Mvc.dll"]
