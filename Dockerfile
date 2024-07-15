#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ITCGKPLAB/ITCGKPLAB.csproj", "ITCGKPLAB/"]
COPY ["ITCGKP.Data.Services/ITCGKP.Data.Services.csproj", "ITCGKP.Data.Services/"]
COPY ["ITCGKP.Data.ViewModels/ITCGKP.Data.ViewModels.csproj", "ITCGKP.Data.ViewModels/"]
COPY ["ITCGKP.DATA.MODELS/ITCGKP.Data.Models.csproj", "ITCGKP.DATA.MODELS/"]
RUN dotnet restore "ITCGKPLAB/ITCGKPLAB.csproj"
COPY . .
WORKDIR "/src/ITCGKPLAB"
RUN dotnet build "ITCGKPLAB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITCGKPLAB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITCGKPLAB.dll"]