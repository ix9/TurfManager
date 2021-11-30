# TurfManager
.NET Core 3.1 WebApp (and WebAPI) to manage your home lawn. 
Uses MS SQL Database for storage.

Keeps a log of lawn care routines.
Calculates the Growing Degree Days (GDD) for your lawn for applications of Plant Growth Regulator (PGR)


## V1.0 
* Receives LIVE temperature information from Philips Hue Outdoor temperature sensor via NodeRED to the WebAPI 
* NodeRED calls the WebAPI to GenerateSummary for previous days temperature data (grabbing the MAX and MIN values) daily at 6am
* GDD is calcuted and persisted to the database. MIN + MAX / 2 -10 for warm season grass.
* NodeRED calls the WebAPI to GetCumulativeGDD (SUM of GDD since last application) and sends a Push notifiation via Pushover.net daily at 7am
* User interaction handled by iOS Shortcuts calling the WebAPI to log "actions"

This a WIP and my code is poor. I am not a developer.

## To-do list

* Setup ASPNET internal cron jobs for /GenerateSummary and /GetCumulativeGDD
* Integrate Pushover.net directly into app.


## API Documentation
Is available in [API.md](API.md)
## Database Structure 
See [Database.sql](Database.sql) for basic MSSQL Schema with test data.


### Generate markdown from the Swagger JSON file
#### Requires Widdershins (npm install -g widdershins)
    widdershins --language_tabs "http:HTTP" --summary swagger.json -o API.md

