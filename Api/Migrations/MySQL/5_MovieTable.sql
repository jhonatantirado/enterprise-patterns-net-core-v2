CREATE TABLE movie(
  movie_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  movie_name VARCHAR(50) NOT NULL,
  release_date DATETIME NOT NULL,
  mpaa_rating INT UNSIGNED NOT NULL,  
  genre VARCHAR(50) NOT NULL,
  rating FLOAT NOT NULL,
  director_id INT UNSIGNED NOT NULL,
  licensing_model INT NOT NULL,
  PRIMARY KEY(movie_id),
  UNIQUE INDEX UQ_movie_name_director_id(movie_name, director_id),
  INDEX IX_movie_director_id(director_id),
  CONSTRAINT FK_movie_director_id FOREIGN KEY(director_id) REFERENCES director(director_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO movie(movie_name, release_date, mpaa_rating, genre, rating, director_id,licensing_model) 
VALUES
('The Amazing Spider-Man', '2012-07-03 00:00:00', 3, 'Adventure', 7, 1,1),
('Beauty and the Beast', '2017-03-17 00:00:00', 3, 'Family', 7.8, 2,1),
('The Secret Life of Pets', '2016-07-08 00:00', 1, 'Adventure', 6.6, 3,1),
('The Jungle Book', '2016-04-15 00:00', 2, 'Fantasy', 7.5, 4,1),
('Split', '2017-01-20 00:00:00', 3, 'Horror', 7.4, 5,1),
('The Mummy', '2017-06-09 00:00:00', 4, 'Action', 6.7, 6,2);