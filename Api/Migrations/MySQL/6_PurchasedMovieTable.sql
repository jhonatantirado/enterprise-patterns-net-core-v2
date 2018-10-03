CREATE TABLE purchased_movie(
  purchased_movie_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  movie_id BIGINT UNSIGNED NOT NULL,
  customer_id BIGINT UNSIGNED NOT NULL,
  price DECIMAL(18,2) NOT NULL,
  purchase_date DATETIME NOT NULL,
  expiration_date DATETIME NOT NULL,
  PRIMARY KEY(purchased_movie_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;