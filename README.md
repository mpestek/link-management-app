# Fullstack Challenge #

### Steps to run ###

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
