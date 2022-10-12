-- INNER JOIN

-- Write a query to retrieve the name and state abbreviation for the 2 cities named "Columbus" in the database
SELECT city_id, city_name, state_abbreviation FROM city WHERE city_name = 'Columbus' OR city_id = 17;
SELECT * FROM state WHERE state_name = 'Ohio' OR state_name = 'Georgia';


-- Write a new query to retrieve the names of the states (rather than their abbreviations).
SELECT city_name, state_name FROM city 
JOIN state ON city.state_abbreviation = state.state_abbreviation
WHERE city_name = 'Columbus';

--Write a query to retrieve the names of capital cities in each state 
--SELECT * FROM state;
SELECT state_name, city_name FROM state 
JOIN city ON state.capital = city.city_id;

-- Write a query to retrieve the names of all the national parks with their state abbreviations.
-- (Some parks will appear more than once in the results, because they cross state boundaries.)

--Where does the park name live? -> park 
--Where does the state abbreviation live? -> park_state or state 
SELECT park_name, state_abbreviation FROM park
JOIN park_state ON park.park_id = park_state.park_id;

-- The park_state table is an associative table/join table that can be used to connect the park and state tables.
-- Modify the previous query to retrieve the names of the states rather than their abbreviations.

SELECT park_name, state_name FROM park --select park name and state name, starting from the park table
JOIN park_state ON park.park_id = park_state.park_id --join park_state where the park_id keys match
JOIN state ON park_state.state_abbreviation = state.state_abbreviation; --join the state table to park_state where states match

-- Modify the previous query to include the name of the state's capital city.
SELECT park_name, state_name, city_name AS capital_city FROM park 
JOIN park_state ON park.park_id = park_state.park_id
JOIN state ON park_state.state_abbreviation = state.state_abbreviation
JOIN city ON state.capital = city.city_id;

-- Modify the previous query to include the area of each park.
SELECT park_name, state_name, city_name AS capital_city, park.area AS park_area 
FROM park 
JOIN park_state ON park.park_id = park_state.park_id
JOIN state ON park_state.state_abbreviation = state.state_abbreviation
JOIN city ON state.capital = city.city_id;

-- Write a query to retrieve the names and populations of all the cities in the Midwest census region.
SELECT city_name, city.population, city.state_abbreviation FROM city
JOIN state ON state.state_abbreviation = city.state_abbreviation
WHERE state.census_region = 'Midwest';

-- Write a query to retrieve the number of cities in the city table for each state in the Midwest census region.
SELECT COUNT(city_name) AS number_of_cities, city.state_abbreviation FROM city
JOIN state ON state.state_abbreviation = city.state_abbreviation
WHERE state.census_region = 'Midwest'
GROUP BY city.state_abbreviation;

-- Modify the previous query to sort the results by the number of cities in descending order.
SELECT COUNT(city_name) AS number_of_cities, city.state_abbreviation 
FROM city
JOIN state ON state.state_abbreviation = city.state_abbreviation
WHERE state.census_region = 'Midwest'
GROUP BY city.state_abbreviation
ORDER BY number_of_cities DESC;

-- LEFT JOIN

-- Write a query to retrieve the state name and the earliest date a park was established 
--in that state (or territory) for every record in the state table that has park records associated with it.

SELECT state_name, MIN(date_established) AS earliest_date
FROM state 
JOIN park_state ON state.state_abbreviation = park_state.state_abbreviation
JOIN park ON park_state.park_id = park.park_id
GROUP BY state_name;

-- Modify the previous query so the results include entries for all the records in the state table, 
--even if they have no park records associated with them.
--keywords that stand out in the above problem: "for every record in the state table" probably means a left join

SELECT state_name, MIN(date_established) AS earliest_date
FROM state LEFT JOIN park_state ON state.state_abbreviation = park_state.state_abbreviation
LEFT JOIN park ON park_state.park_id = park.park_id
GROUP BY state_name;

-- UNION

-- Write a query to retrieve all the place names in the city and state tables that begin with "W" sorted alphabetically. 
--(Washington is the name of a city and a state--how many times does it appear in the results?)
SELECT city_name FROM city WHERE city_name LIKE 'W%'
UNION
SELECT state_name FROM state 
WHERE state_name LIKE 'W%';

-- Modify the previous query to include a column that indicates whether the place is a city or state.
SELECT city_name, 'City' AS type_of_place FROM city WHERE city_name LIKE 'W%'
UNION
SELECT state_name, 'State' AS type_of_place FROM state 
WHERE state_name LIKE 'W%';



-- MovieDB
-- After running the script to set up the MovieDB database, make sure it is selected in SSMS and confirm it is working correctly by writing queries to retrieve...

-- The names of all the movie genres
--SELECT * FROM genre;

-- The titles of all the Comedy movies
--SELECT title FROM movie
--JOIN movie_genre ON movie.movie_id = movie_genre.movie_id
--JOIN genre ON genre.genre_id = movie_genre.genre_id
--WHERE genre_name = 'Comedy';
