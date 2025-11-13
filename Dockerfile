# -----------------------------
# Stage 1: Build
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# فقط فایل پروژه اصلی را کپی کن و Restore بزن
COPY *.csproj ./
RUN dotnet restore

# کل پروژه را کپی کن و Publish بگیر
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# -----------------------------
# Stage 2: Runtime
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# فایل‌های Publish شده را از مرحله Build کپی کن
COPY --from=build /app/publish .

# پورت Swagger و API
EXPOSE 80

# دستور اجرای پروژه
ENTRYPOINT ["dotnet", "ReoNet.api.dll"]
