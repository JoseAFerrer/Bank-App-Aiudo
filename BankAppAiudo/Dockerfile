#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BankAppAiudo/BankAppAiudo.csproj", "BankAppAiudo/"]
RUN dotnet restore "BankAppAiudo/BankAppAiudo.csproj"
COPY . .
WORKDIR "/src/BankAppAiudo"
RUN dotnet build "BankAppAiudo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankAppAiudo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankAppAiudo.dll"]