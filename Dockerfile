# ------------------------------------
# Stage 1: Build
# ------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# کپی فایل پروژه
COPY ReoNet.api.csproj .

# Restore
RUN dotnet restore ReoNet.api.csproj

# کپی کل پروژه
COPY . .

# Publish
RUN dotnet publish ReoNet.api.csproj -c Release -o /app/publish

# ------------------------------------
# Stage 2: Runtime
# ------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "ReoNet.api.dll"]
