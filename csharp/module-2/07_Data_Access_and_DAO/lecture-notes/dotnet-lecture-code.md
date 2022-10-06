# Database connectivity (DAO) - C# lecture notes

## Database schema

Review the `UnitedStates` database schema with the class. Make sure to review the table names, fields, and data types.

## Starting code

Run the provided CLI application. Demonstrate creating, removing, updating, and deleting city records from the database. Avoid diving into the details of the CLI, since it isn't today's primary focus.

Note that the park-related features of the CLI won't work correctly until you implement the `ParkSqlDao`.

## Connecting to the database

Application code that interacts with a database is a "client" of the database in the same way SSMS is.

There are many different database platforms—for example, SQL Server, PostgreSQL, or Oracle—that an application may want to integrate with.

- .NET provides a library called ADO.NET for interacting with a variety of databases in a generic way.

- A "driver" is implemented for each database so that application code can communicate with that database.

When code interacts with a database, it needs to **create a connection**.

- Connections remain open until they're closed or time out.

- Connections have overhead when created and opened, so there's often a finite number of connections managed as a group. This is called **connection pooling**.

- A **connection string** specifies the name of the driver to use, the host and any port, the database name, and a username and password.

- Connection strings shouldn't be written directly in code. **Why?**

- Connections are valuable resources. Leaving it connected for a single application might be fine, but what about a larger-scale application?

---

You can point out the connection strings in `Program.cs` and how it's created and used in the `*SqlDao` classes. Note that the connection string details (including username and password) are included in the lecture code for convenience, but this shouldn't be done when developing real applications.

> Note: At some point, you might demonstrate moving the connection string into `appsettings.json` and retrieving it with the commented out code in `Program.cs`. You'll have to add `Microsoft.Extensions.Configuration` and `System.IO` to the `using`s.

---

## Executing SQL statements

Once a connection is instantiated and opened, other objects that issue SQL commands can use it.

The ADO.NET library's `SqlCommand` class executes SQL statements and returns results, often as a `SqlDataReader`.

A `SqlDataReader` object provides the ability to walk through each row in the result set and read values from each of the columns.

The results from a SQL query are often used to populate **domain objects**.

A **parameterized query** is a query in which placeholders are used for parameters, and the parameter values are supplied at execution time. The most important reason to use parameterized queries is to avoid SQL injection attacks.

---

Use the methods in `StateSqlDao` as examples of basic parameterized queries that populate `State` domain objects. Note that the `State` domain object only has the properties needed by this application.

Often, domain objects (like `City`) have properties that correspond to every column of the associated table, but make sure students understand that's not a requirement.

---

## The DAO pattern

The **Data Access Object (DAO)** design pattern encapsulates the details of persistent storage inside of classes whose only role is to store and retrieve data.

DAOs usually perform CRUD operations on domain objects.
  - **C**reate
  - **R**ead
  - **U**pdate
  - **D**elete

The DAO pattern makes code **loosely coupled**.

- Isolating data access code inside of DAOs decouples the rest of the application from the details of persistence.

- Relational databases are often used for persistent storage, but other technologies could be used such as the filesystem, NoSQL database, or a web service.

- It isolates the code changes that need to be made in the event of a table schema change.

Each DAO consists of three components:

1. A domain object (`City`)
2. An interface (`ICityDao`)
3. An implementation of that interface (`CitySqlDao`)

---

Remind the students of the value of programming to interfaces, allowing the implementation to change without having to change the code using the interface.

Use `CitySqlDao` as an example of implementing all the CRUD methods.

Spend the rest of lecture implementing the following methods of `ParkSqlDao`:

* `GetPark` and `CreateParkFromReader`
* `GetParksByState`
    * The query for this method requires a `JOIN`.
* `CreatePark`
    * In SQL Server, an `OUTPUT` clause can be used to get back values from a newly inserted record.
    * The `ExecuteScalar` method can be used rather than `ExecuteReader` when a single value is expected.
* `UpdatePark`
    * The `ExecuteNonQuery` method of `SqlCommand` is used when no data needs to be returned from running the SQL (it returns a row count of records affected).
* `DeletePark`
    * Deleting a park requires removing records from the `park` and `park_state` tables.
    * You could wait to add the deletion from `park_state` until after implementing the next two methods.
* `AddParkToState`
* `RemoveParkFromState`
    * This method isn't used by the CLI application, but it may be useful tomorrow for integration testing.

After (or while) implementing all those methods, run the CLI application to demonstrate that they work.

---

## Note regarding exceptions and error-handling

Today's DAO implementations intentionally omit error-handling for the sake of keeping things simple and focused. Consider demonstrating how exceptions could be used in the context of a DAO on a review day or another opportunity when time permits.
