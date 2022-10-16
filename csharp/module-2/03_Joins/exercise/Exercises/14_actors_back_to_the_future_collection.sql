-- 14. The names of actors who've appeared in the movies in the "Back to the Future Collection", sorted alphabetically.
-- (28 rows)
SELECT person_name 
FROM person
JOIN movie ON movie.collection_id = movie.movie_id
JOIN movie_actor ON person.person_id = movie_actor.actor_id
JOIN collection ON collection.collection_id = movie_actor.movie_id
WHERE collection_name = 'Back to the Future Collection'
