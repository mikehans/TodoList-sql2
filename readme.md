# TodoList demo app
## What am I demonstrating here?
* Dependency injection in a console application
* Basic Dapper usage to access a SQL database
    * sending a SQL statement
    * inserting data through a stored procedure
    * reading data through a stored procedure
* Getting app settings through DI

Be aware that this is demo-ware. It's not a good demo of production ready practices.

## What are my thoughts on Dapper?
It's really easy. 

It relates readily to existing SQL knowledge. There's no mucking around with meeting the needs of the ORM (like with EF Core).

Errors are pretty obvious and related to ADO.NET.

The ORM provides ready translation of ADO.NET DataTables into POCO objects.

You change the SQL type by changing the ADO.NET IDbConnection.

The console app is entirely unaware of it, unlike EF which fills up the Program.cs file.