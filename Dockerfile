# Stage 1: Build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy toàn bộ project từ repo
COPY . .

# Đảm bảo đặt đúng thư mục chứa API
WORKDIR /app/src/SocialNetwork.API

# Restore và build
RUN dotnet restore SocialNetwork.API.csproj
RUN dotnet publish SocialNetwork.API.csproj -c Release -o /publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "SocialNetwork.API.dll"]
