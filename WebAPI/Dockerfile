FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

COPY *.sln .
COPY . .
WORKDIR /app/WebAPI
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish WebAPI/WebAPI.csproj -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/WebAPI/WebAPI/out .
ENTRYPOINT ["dotnet", "WebAPI.dll"]