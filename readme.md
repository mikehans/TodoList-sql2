# TodoList demo app
## What am I demonstrating here?
* Dependency injection in a console application
* Basic Dapper usage to access a SQL database
    * sending a SQL statement
    * inserting data through a stored procedure
    * reading data through a stored procedure
* Getting app settings through DI

Be aware that this is demo-ware. It's not a good demo of production ready practices.

## Big fat outstanding problem
The DB connections created in ```TodoList.DataAccess.SqlServer``` and ```TodoList.DataAccess.Sqlite``` are not being disposed of!

The DI container won't dispose of the ```IDBConnection``` as it is not managed by the DI container - I'm directly calling ```new SqlConnection()``` or ```new SqliteConnection()``` inside the delegate method. 

So I currently don't know how to ensure the connection gets disposed of.

One option might be to do away with the delegate and use an interface instead. This should allow me to call the ```Dispose()``` method at the end of the program. 

I don't want to delegate creation of the ```IDBConnection``` to the DI container as I want it to be ignorant of the data access technologies. One advanced scenario I've heard of is to create a child DI container. This could be in the ```TodoList.DataAccess``` class which would be better.

## What are my thoughts on Dapper?
It's really easy. 

It relates readily to existing SQL knowledge. There's no mucking around with meeting the needs of the ORM (like with EF Core).

Errors are pretty obvious and related to ADO.NET.

The ORM provides ready translation of ADO.NET DataTables into POCO objects.

You change the SQL type by changing the ADO.NET IDbConnection.

The console app is entirely unaware of it, unlike EF which fills up the Program.cs file.