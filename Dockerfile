FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /home/weather-forecast

# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o /stage-publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /home/weather-forecast/runtime-publish
COPY --from=build-env /stage-publish .
EXPOSE 80
EXPOSE 7291

ENTRYPOINT ["dotnet", "weatherForecast.dll"]