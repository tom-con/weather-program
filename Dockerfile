FROM microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet ef database update
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-sdk
WORKDIR /app

RUN apt-get -y update
RUN apt-get -y upgrade
RUN apt-get install -y sqlite3 libsqlite3-dev

COPY --from=build-env /app/out .
EXPOSE 61165:61165

ENTRYPOINT [ "dotnet", "sovos-weather.dll" ]