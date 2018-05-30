## soccer-logos

The purpose of this application is to grab data from a public web API and display this data in a responsive web application allowing users to quickly filter through the results. The data selected was English League Football teams available from <a href="https://www.football-data.org/documentation">football-data.org</a>



<img src="/gifs/filtering.gif"  />



Example of the running application filtering by "man" then "manchester city" to limit the list of teams down

####Repository

The repository is open and available freely under my Github <a href="https://github.com/JamesMReilly/soccer-logos">JamesMReilly</a>

####References
I found that Microsoft's official documentation on <a href"https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/?view=aspnetcore-2.0">Creating Razor Page web apps in ASP.NET Core</a> and <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-2.0&tabs=aspnetcore2x">Session and app state in ASP.NET Core</a> were the most useful in completing this exercise

####Implementation Details

* This app was developed entirely in Visual Studio
* Connects to <a href="https://www.football-data.org/documentation">football-data.org</a> public API for football(soccer!) data
* The API requests are made in C# and deserialized into custom C# objects with NewtonSoftJSON
* The unit tests were written using NUnit 3 test framework
* The web page was built with ASP.NET Core using Microsoft's Razor Pages
* Browser caching implemented to save query results for performance

####Project Structure

The application was implemented in 4 C# projects: Types, Core, Main, and Web

##### SoccerLogos.Types

The Types project defines custom data types to deserialize JSON query results into

#####SoccerLogos.Core
Core contains all code for making the specific HTTP requests and wrap the results into their respective types

#####SoccerLogos.Main
The Main project has static implementations of the highest level methods to be called by the web project limiting the neccesary references to the API code

#####SoccerLogosWeb
The ASP.NET Core web application. This project is the startup project and implements all front-end interaction with Razor Pages combining HTML and C#






