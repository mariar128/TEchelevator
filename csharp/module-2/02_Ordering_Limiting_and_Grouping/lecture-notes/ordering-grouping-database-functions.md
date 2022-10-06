# Intro to ordering, grouping, and database functions

## Problem statement

Filtered, but otherwise unorganized information is only so useful. Grouping and ordering data can make information *understandable*.

Database functions to count, sum, average, and otherwise massage the data can further enrich the information.

## Lesson objectives

* Ordering
* Limiting results
* String operations functions
* Aggregate functions
* Grouping results
* Subqueries (optional)

## Notes and examples

### **Ordering results**

- To sort a result set, you can use the `ORDER BY` clause:

    ```sql
    SELECT col1, col2
    FROM tablename
    WHERE col1 = 'value'
    ORDER BY col1 [ASC | DESC], col2 [ASC | DESC]
    ```
- Sort columns must exist in the table being queried, but not necessarily in the result set.
- Aliased columns can also be used for sorting.
- Multiple column names can be provided which creates a *priority* sort. In other words, the first column in the `ORDER BY` clause is the *major* or *primary* sort. All other columns are *minor* or *secondary* sorts in the left-to-right order in which they were given.

### **Limiting results**

- We can reduce the size of our result set to *N results*.
    - **Postgres**: use `LIMIT N` at the end of query.
    - **SQL Server**: use `SELECT TOP N` in the beginning of the query.

### **String operations**

- We can concatenate the values across multiple columns into a single field.
    - **Postgres**: use the `||` operator to concatenate strings. `SELECT (column1 || ', ' || column2) FROM table`
    - **SQL Server**: use the `+` operator to concatenate strings. `SELECT (column1 + ', ' + column2) FROM table`

### **Aggregate functions**

* **`AVG`** returns the average value of a numeric column
* **`SUM`**  returns the total sum of a numeric column
* **`COUNT`** returns the number of rows matching criteria
* **`MIN`** returns the smallest value of the selected column
* **`MAX`** returns the largest value of the selected column

### **Grouping results**

`GROUP BY` statements group records into summary rows and return one record for each group.

- Grouping data is the process of combining columns with duplicate values.
    - For example, a database may contain information about employees. Many employees may live in different cities. Suppose you wanted to figure the average salary paid to employees within each city. We would use the aggregate function `AVG` for the salary, and `GROUP BY` the city.
    - You can use the `GROUP BY` clause in conjunction with aggregate functions to collect data across multiple records.
    - The signature of the statement follows:

    ```sql
    SELECT expression1, expression2, ... expression_n,
        aggregate_function (aggregate_expression)
    FROM table
    [WHERE condition_expression]
    GROUP BY expression1, expression2, ... expression_n
    ORDER BY order_column;
    ```

### **Subqueries** *(optional)*

We don't offer explicit exercises for subqueries (although it's often used for the capstone), but this day is typically lighter and gives us the chance to present the idea that queries can "span" multiple tables, in addition to the notion of combining queries to help further organize and clarify information.

A **subquery** is called an inner query and can provide the results of one query as input to another.

- Often used in the `WHERE` clause
- Can only return one item in the `SELECT` clause

	```sql
	SELECT column_name [, column_name]
	FROM table1 [, table2]
	WHERE column_name (IN | NOT IN)
		(SELECT column_name FROM table [WHERE])
	```
