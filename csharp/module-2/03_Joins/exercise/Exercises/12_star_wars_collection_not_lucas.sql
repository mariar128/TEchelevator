-- 12. The titles of the movies in the "Star Wars Collection" that weren't directed by George Lucas, sorted alphabetically.
-- (5 rows)
SELECT DISTINCT title 
FROM movie
JOIN collection ON movie.collection_id = collection.collection_id
JOIN movie_actor ON movie.movie_id = movie_actor.movie_id
JOIN person ON person.person_id = movie.director_id
WHERE collection_name = 'Star Wars Collection' AND person_name != 'George Lucas'
ORDER by title