FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install NodeJs
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs

# Set the working directory for the build stage
WORKDIR /src
# Copy the project file into the container's /src folder
COPY ["src/Via.Movies.Api/Via.Movies.Api.csproj", "src/Via.Movies.Api/"]
# Restore the NuGet packages for the project
RUN dotnet restore "src/Via.Movies.Api/Via.Movies.Api.csproj"
# Copy the remaining source code files into the container
COPY . .
WORKDIR "/src/src/Via.Movies.Api/"
# Build the project with the Release configuration and output the result to /app/build
RUN dotnet build "Via.Movies.Api.csproj" -c Release -o /app/build

# Create a new stage named 'publish' that starts from the 'build' stage
FROM build AS publish
# Publish the project with the Release configuration and output the result to /app/publish
RUN dotnet publish "Via.Movies.Api.csproj" -c Release -o /app/publish

# Create a new stage named 'final' that starts from the 'base' stage
FROM base AS final
WORKDIR /app
# Copy the published output from the 'publish' stage to the current working directory
COPY --from=publish /app/publish .

# Set the entrypoint command to start the app using the .NET runtime
ENTRYPOINT ["dotnet", "Via.Movies.Api.dll"]