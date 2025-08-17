# Build source code
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App
RUN cd ..
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Api.dll"]
EXPOSE 7013