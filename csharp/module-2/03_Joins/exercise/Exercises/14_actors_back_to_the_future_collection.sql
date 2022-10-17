-- 14. The names of actors who've appeared in the movies in the "Back to the Future Collection", sorted alphabetically.
-- (28 rows)
SELECT DISTINCT person_name 
FROM movie
LEFT JOIN collection ON collection.collection_id = movie.collection_id
LEFT JOIN movie_actor ON movie.movie_id = movie_actor.movie_id
LEFT JOIN person ON person.person_id = movie_actor.actor_id
WHERE collection_name = 'Back to the Future Collection'
ORDER BY person_name
