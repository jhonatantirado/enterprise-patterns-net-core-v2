CREATE TABLE customer(
  customer_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  identity_document VARCHAR(20) NOT NULL,
  active BIT NOT NULL,
	email varchar(150) NOT NULL,
	status int NOT NULL,
	status_expiration_date datetime NULL,
	money_spent decimal(18, 2) NOT NULL,
  PRIMARY KEY(customer_id),
  INDEX IX_customer_last_first_name(last_name, first_name),
  UNIQUE INDEX UQ_customer_identity_document(identity_document)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO customer(first_name, last_name, identity_document, active,email,status,money_spent) 
VALUES('Juan', 'Pérez', '123456789', 1,'',1,0);
INSERT INTO customer(first_name, last_name, identity_document, active,email,status,money_spent) 
VALUES('Carlos', 'Pérez', '123456780', 1,'',1,0);
INSERT INTO customer(first_name, last_name, identity_document, active,email,status,money_spent) 
VALUES('Alberto', 'Otero', '123456781', 1,'',1,0);