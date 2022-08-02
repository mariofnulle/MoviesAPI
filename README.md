# Movie Catalog System
This project is an online movie catalog system for study purposes.
Feel free to download and use the code.

## Now Implemented
For now its possible to use the entire system through API calling in Postman.
- User Register;
- Login / Logout;
- Product CRUD
  - Movies;
  - Movie Theather;
  - Address;
  - Manager;
  - Session;

## How to use
In the appsettings.json, configure the database name. The system was implemented using SQL.
Execute the migrations for initial table creation.

To call the APIs use Postman.
The routes are the HTTP method + controller name. Some especific cases need an id or "all".
E.g. - (HTTP Get) "movie/1" to return the movie registered with id 1.

Any questions check the swagger.

## To Do
- Implement MVC Project;
- Develop the front-end (HTML, CSS);
- Create Views to manipulate API data.
