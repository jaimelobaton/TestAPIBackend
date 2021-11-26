Step By Step How to run this Project

1- Clone the project  using this url :
https://github.com/jaimelobaton/TestAPIBackend.git
This a public Project

2-Change the connectionString in the appsettings.json file to your local Database. I worked with Sql Server.

3- In your Local Database, you must create a New Database Named Test.

4-We must create a database and required tables before running the application. 
As we are using entity framework, we can use below database migration command with package manger 
console to create a migration script.

add-Migration "First prefill"

and then this Script:

update-database

Now, you must Prefill your new Database. You can do this executing the Following Scripts :


INSERT INTO [dbo].[Directors] VALUES ('Steven',null ,'Spielberg','1987-10-10',NULL,'1995-5-5',NULL)
INSERT INTO [dbo].[Directors] VALUES ('Martin',null ,'Scorsese','1971-1-9',NULL,'1946-5-7',NULL)
INSERT INTO [dbo].[Directors] VALUES ('Alfred',null ,'Hitchcock','1946-9-29',NULL,'1914-9-7',NULL)

 INSERT INTO [dbo].[Genrers] VALUES ('Terror','1960',8);
 INSERT INTO [dbo].[Genrers] VALUES ('Drama','1930',8);
 INSERT INTO [dbo].[Genrers] VALUES ('Comedy','1930',10);


INSERT INTO [dbo].[Studios] VALUES ('Universal','Chicago','USA','Peter','1910-1-1');
INSERT INTO [dbo].[Studios] VALUES ('Marvel','Chicago','USA','Peter','1910-1-1');
INSERT INTO [dbo].[Studios] VALUES ('Pixar','Orlando','USA','Walt','1920-5-5');

please consider the primary keys of the Studio, Genre and Director tables to load the movies table.

INSERT INTO [dbo].[Movies] VALUES ('Scarface',80,'1965-5-18',1,NULL,1,1,3);
INSERT INTO [dbo].[Movies] VALUES ('King Lion',120,'1990-5-8',1,NULL,1,1,4);
INSERT INTO [dbo].[Movies] VALUES ('Shrek',120,'2001-5-8',1,NULL,1,1,5);




Following above steps, you should be able to run this Project.





/***************************************************************************************
How this project works
****************************************************************************************/

1-Following the requirements, these are the endpoints services  :

Register -POST 
http://localhost:48837/api/Authenticate/register

Body example:
{
  "email": "test@example.com",
  "password": "Gy12345678@"
}

Login -GET
http://localhost:48837/api/Authenticate/login
{
  "email": "test@example.com",
  "password": "Gy12345678@"
}
This method generate  a valid JWT token. 

We have received a token after successful login with above credentials.
 
We can pass above token value as a bearer token inside the authorization tab IN POSTMAN to access all the methods of our API.

This token isValid for 20 minutes, You can check this configuration in source code.

Create Movie -POST 
http://localhost:48837/Movie/CreateMovie
{
      "Title": "Gone 3",
       "Duration": 100,
       "ReleaseDate" : "2015-04-28T14:45:15" ,
       "GenrerId" : 2, // REFERENCIAL INTEGRITY 
       "StudioId" : 1, // REFERENCIAL INTEGRITY 
       "DirectorId" : 3 // REFERENCIAL INTEGRITY 
}

Be carefull with REFERENTIAL INTEGRITY.Movies Table has Foreign Keys with Director , Studio adn Gender Tables.


Edit Movie - PUT
http://localhost:48837/Movie/EditMovie
{
    "Id": 10,
    "Title": "Gone Part 2",
    "Duration": 50,
    "ReleaseDate": "2019-05-28T14:45:15",
    "GenrerId": 2, // REFERENCIAL INTEGRITY 
    "StudioId": 1,  // REFERENCIAL INTEGRITY 
    "DirectorId": 3 // REFERENCIAL INTEGRITY 
}

Delete Movie - DELETE
http://localhost:48837/Movie/DeleteMovie/12  --Delete an specific element.

Delete all Movie - DELETE
http://localhost:48837/Movie/DeleteMovie/  --Delete All the elements asociated to the logged user 


Get All the Public elements  - GET
http://localhost:48837/Movie/getAllPublicMovies?pageNumber=1&pageSize=2

We're using [FromQuery] to point out that we’ll be using query parameters 
to define which page and how many Movies we are requesting


Get All the Liked Movies  -GET
http://localhost:48837/Movie/getAllLikedMoviesByUser?pageNumber=1&pageSize=2


Get All the movies asociated to the logged User  - GET
http://localhost:48837/Movie/getAllMoviesByUser?pageNumber=1&pageSize=2


I used Swagger to share documentation.
http://localhost:48837/swagger/index.html


This  API is deployed in a publicly accessible URL
https://godesarrollo.renovacionterritorio.gov.co/Test/api/Authenticate/login

Take into consideration, if you want to test this API in POSTMAN or other API Clients , you must disabled SSL certificate Verification.
Settings->Request



