FROM mcr.microsoft.com/dotnet/sdk:7.0 AS dotnet-build
WORKDIR /src
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY Eurowebapi.Api/*.csproj ./Eurowebapi.Api/
COPY Eurowebapi.Application/*.csproj ./Eurowebapi.Application/
COPY Eurowebapi.Infrastructure/*.csproj ./Eurowebapi.Infrastructure/
COPY Eurowebapi.Domain/*.csproj ./Eurowebapi.Domain/
RUN dotnet restore "SampleWithReact.Api/SampleWithReact.Api.csproj"
#
# copy everything else and build dotnet app
COPY SampleWithReact.Api/. ./SampleWithReact.Api/
COPY SampleWithReact.Application/. ./SampleWithReact.Application/
COPY SampleWithReact.Infrastructure/. ./SampleWithReact.Infrastructure/
COPY SampleWithReact.Domain/. ./SampleWithReact.Domain/
WORKDIR /src/SampleWithReact.Api
RUN dotnet build "SampleWithReact.Api.csproj" -c Release -o /app/build

# publish dotnet app
FROM dotnet-build AS dotnet-publish
RUN dotnet publish "SampleWithReact.Api.csproj" -c Release -o /app/publish

# publish react app
FROM node AS node-builder
WORKDIR /node
COPY ./SampleWithReact.Api/ClientApp/ /node
RUN npm install
RUN npm run build

# final stage/image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final
WORKDIR /app
RUN mkdir /app/wwwroot
COPY --from=dotnet-publish /app/publish .
COPY --from=node-builder /node/build ./wwwroot
ENTRYPOINT ["dotnet", "SampleWithReact.Api.dll"]