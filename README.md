# Schaffner
Sample app for estimating predicted bus arrival times at a stop along a route.

Solutions were built in Visual Studio 2017

To Install and Run:

1.
The easiest way to run it would be to open the Schaffner-Server.sln - build and run it and then open the Schaffner-Client.sln, build it and then change the following line in wwwroot/app/app.js to point to your server endpoint.

    appModule.constant("SchaffnerRestAPIBaseURL", "http://localhost/Schaffner/api/");
   
The constant "SchaffnerResstAPIBaseURL needs to point to a valid endpoint you can reach via the client. If your api is residing on a different server, IP/Machine name is necessary in place of localhost.

Meaning if when you start up your project it is residing on http://localhost:22280/api/, that line should read

    appModule.constant("SchaffnerRestAPIBaseURL", "http://localhost:22280/api/");
    
    
2.
Another option is to publish both Solutions (Client/Server) to IIS under the default website under the names Schaffner and Schaffner-UI for Server and UI respectively. If followed exactly, this should require no additional configuration. If a different IIS name is preferred you can use the following setting, similar to above, to customize it.

    appModule.constant("IISProjectFolderRoot", "/Schaffner-UI/");
    
Just make sure it is consistent. 




Tips/Tricks
-Change the limitTo on the ng-repeat directive in stops-list.component to show up to 10 stops at once.

Notes

The following API calls are defined
- http://localhost:22280/api/stops/  - gets 2 predictions for all routes for all stops
- http://localhost:22280/api/stops/{id} gets 2 predictions for all routes for stop id = 
- http://localhost:22280/api/stops/info gets information about all stops
- http://localhost:22280/api/stops/info/{id} gets information about stop id =



![Optional Text](../master/sample2.png)





