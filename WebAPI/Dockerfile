FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

COPY *.sln .
COPY . .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish WebAPI/WebAPI.csproj -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/WebAPI/out .
ENTRYPOINT ["dotnet", "WebAPI.dll"]