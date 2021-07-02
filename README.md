# Fullstack Challenge #

This challenge was done over an 8 hr period.

## Requirements
1. User registration / login, supporting basic info like:
  - Username
  - Password
  - Email
  - First and Last name.

2. Logged in users can add links to their "space", and assign tags to them, (e.g. sports, media, news, ...).
3. The application considers two links equal, if they have the same address and query parameters, regardless of query param order.
4. When a user adds an existing link, the app suggests tags that other users have used for the link, sorted by the number of occurrences.
5. When the user adds a new link, the app does some analysis on it, based on which it suggests some tags. The analysis is done by fetching the HTML content from the link, counting keyword occurrences (excluding html tags and attributes). Based on that is suggests up to 10 tags to the user.


## Steps to run ###

To run the application quickly, you can use the docker-compose.yml file inside of the
root folder. Run ``` docker-compose up ``` inside of the root folder.
This should run the database and frontend inside two containers. The backend needs to be run separately as I've failed to configure it. However, when the backend starts, it should **automatically build the database**.

* Run ```docker-compose up ```, however you may need to run ``` docker-compose build ``` first.
* This will start run a DB container **exposed on port 5234**.
* The frontend will run inside a container **exposed on port 4200**.
* It's important that the frontend runs on port 4200, as this port is configured for CORS.
* Run the backend and let it build the database.

### Alternatively ###
If the previous approach does not work please run all 3 separately.

* Run the angular app with ``` ng serve ``` and expose it on port 4200.
* Run an instance of MSSQL server locally and provide the appropriate connection string
to backend's ```appSettings.json```
* Run the backend on port 5001 and let it build the DB.

NOTE: If for any reason the DB migration fails, please download dotnet ef tool by running (assuming you have the dotnet SDK) ``` dotnet tools install --global dotnet-ef ```.
After this run ```dotnet ef database update``` inside the ```BackendArchitecture.Api``` folder after you have built the solution with the correct connection string.
