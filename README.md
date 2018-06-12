# Weather Program

This program acts as an API to be able to average together weather datapoints into a more human-friendly output.

## Getting Started

_If you are just interested in the WeatherService.cs, please see [here](./Services/WeatherService.cs)._

This project requires dotnet-sdk @ 2.1. You can download that [here](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview1).

* Run the project with `dotnet run`.
* This should host the api at `http://localhost:61165` (This isn't served over https so you can send cURLs)

* Navigate to `http://localhost:61165/api/weather` to see all weather data points in the database.
* Navigate to `http://localhost:61165/api/cities` to see all average city weather data points in the database.
* Navigate to `http://localhost:61165/api/aggregate` to run the aggragation, which will aggregate all rows in the weather data points table into averages organized by city (available to view in the average city weather data table.
* Update the database with `cURL` requests (both weather and cities can have CRUD operations performed against them):
`curl -d '{"State":"WA", "City":"Seattle", "Date":"2018-06-12", "HighTemp":"72.1", "LowTemp":"34.2"}' -H "Content-Type: application/json" -X POST http://localhost:61165/api/weather`


## Room for Improvement

1. The dockerfile is broken, so unfortunately deploying/building via docker is not possible. This is caused by SQLite not being made available (not creating the database) somewhere during the build process.
2. Currently the AggregateController doesn't have methods for querying an aggragation by a collection of IDs, which I think is a desired feature.
3. There are no exposed API routes to calculate an aggregation from a POST request of correctly formatted data without interacting with the API.
