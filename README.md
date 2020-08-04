# Blog Api with C# and ASP.NET Core 3.1.302
And I attempted to bootstrap the app with a mysql database.... using the MySqlConnector Nuget Package...

### To Bootstrap

#### Step 1:
git clone https://github.com/propenster/NetCoreBlogApi.git netcoreapi

#### Step 2:
cd netcoreapi

#### Step 3: 
Navigate to the src\BlogPostApi folder

#### Step 4: Set up the database on your local server with the dumpfile - blogapi.sql 
<p> Bootstrap the database using the dump db of the blogapi (blogapi.sql) in the resources folder of this repo</p>
<p> </p>
#### Step 4.1: Change the DefaultConnection settings in appsettings.json file in source folder...see below

"AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "server=127.0.0.1;user id={root or HostName};password={password};port=3306;database=blogapi;"
}

#### Step 5: Run the Application
Using the dotnet cli
dotnet run

#### The App is served at http://localhost:5000/api/blog OR https://localhost:5001/api/blog

#### Step 6: Use Postman to test the API endpoints

POST https://localhost:5001/api/blog
{ "Title": "One", "Content": "First Blog Post!" }

POST https://localhost:5001/api/blog
{ "Title": "Two", "Content": "Second Blog Post!" }

POST https://localhost:5001/api/blog
{ "Title": "Three", "Content": "Third Blog Post!" }

GET https://localhost:5001/api/blog
// Output:
[
    { "id": 3, "title": "Three", "content": "Third Blog Post!" },
    { "id": 2, "title": "Two", "content": "Second Blog Post!" },
    { "id": 1, "title": "One", "content": "First Blog Post!"}
]



#### Enjoy!

