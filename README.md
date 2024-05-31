# TurfManager
ASPNETCore 8.0 WebApp (and WebAPI) to manage your home lawn. 
Uses MS SQL Database for storage.

Keeps a log of lawn care routines.
Calculates the Growing Degree Days (GDD) for your lawn for applications of Plant Growth Regulator (PGR)


## V1.1 
* Updated to ASPNET Core 8.0 nuget packages, dockerfile, and stronger SymmetricKey's.
* Fixed container support

## V1.0 
* Receives LIVE temperature information from Philips Hue Outdoor temperature sensor via NodeRED to the WebAPI 
* NodeRED calls the WebAPI to GenerateSummary for previous days temperature data (grabbing the MAX and MIN values) daily at 6am
* GDD is calcuted and persisted to the database. MIN + MAX / 2 -10 for warm season grass.
* Home Assistant calls the WebAPI to /api/GetCumulativeGDD (SUM of GDD since last application) and an automation can push daily GDD numbers to your phone.
* User interaction handled by iOS Shortcuts calling the WebAPI to log "actions"

This a still a WIP and my code is poor. I am not a developer.

## To-do list

* Setup ASPNET internal cron jobs for /GenerateSummary and /GetCumulativeGDD
* Make the UI Prettier/mobile friendly.


## API Documentation
Is available in [API.md](API.md)
## Database Structure 
See [Database.sql](Database.sql) for basic MSSQL Schema with test data.


### Generate markdown from the Swagger JSON file
#### Requires Widdershins (npm install -g widdershins)
    widdershins --language_tabs "http:HTTP" --summary swagger.json -o API.md

