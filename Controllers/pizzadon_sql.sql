-- CREATE TABLE Pizza
-- (
--   pizzaID INT PRIMARY KEY AUTO_INCREMENT,
--   name VARCHAR(50) NOT NULL,
--   description VARCHAR(255) NOT NULL
-- );

-- CREATE TABLE Customer
-- (
--   custID INT PRIMARY KEY AUTO_INCREMENT,
--   last_name VARCHAR(30) NOT NULL,
--   first_name VARCHAR(30) NOT NULL,
--   phone VARCHAR(15)
-- );

-- CREATE TABLE pizzaorder
-- (
--   id INT AUTO_INCREMENT,
--   custID INT NOT NULL,
--   orderDate VARCHAR(12),
--   PRIMARY KEY(id),
--   FOREIGN KEY (custID) REFERENCES Customer (custID)
--   ON DELETE CASCADE
-- );

CREATE TABLE order_item
(
  orderID INT NOT NULL,
  pizzaID INT NOT NULL,
  size CHAR(1) NOT NULL,
  PRIMARY KEY(orderID, pizzaID),
  FOREIGN KEY (orderID) REFERENCES pizzaorder (id)
  ON DELETE CASCADE,
  FOREIGN KEY (pizzaID) REFERENCES Pizza (pizzaID)
  ON DELETE CASCADE
);