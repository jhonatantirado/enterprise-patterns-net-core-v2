CREATE TABLE bank_account(
  bank_account_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  number VARCHAR(50) NOT NULL,  
  balance DECIMAL(10,2) NOT NULL,
  currency VARCHAR(3) NOT NULL,
  locked BIT NOT NULL,
  customer_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY(bank_account_id),
  INDEX IX_bank_account_customer_id(customer_id),
  UNIQUE INDEX UQ_bank_account_number(number),
  CONSTRAINT FK_bank_account_customer_id FOREIGN KEY(customer_id) REFERENCES customer(customer_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO bank_account(number, balance, currency, locked, customer_id) VALUES('123-456-001', 3500.00, 'USD', 0, 1);
INSERT INTO bank_account(number, balance, currency, locked, customer_id) VALUES('123-456-002', 4800.50, 'PEN', 0, 1);
INSERT INTO bank_account(number, balance, currency, locked, customer_id) VALUES('123-456-003', 5500.75, 'USD', 0, 1);
INSERT INTO bank_account(number, balance, currency, locked, customer_id) VALUES('123-456-004', 6800.00, 'USD', 0, 2);
INSERT INTO bank_account(number, balance, currency, locked, customer_id) VALUES('123-456-005', 3800.25, 'USD', 0, 3);