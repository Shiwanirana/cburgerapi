-- CREATE TABLE burger(
--   id int AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   bun VARCHAR(255) NOT NULL,
--   price DECIMAL(6,2) NOT NULL,
--   toppings VARCHAR(255),
--   description VARCHAR(255),
--   PRIMARY KEY(id)
-- );

-- CREATE TABLE sides(
--   id int AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   price DECIMAL(6,2) NOT NULL,
--   description VARCHAR(255),
--   PRIMARY KEY(id)
-- );
-- INSERT INTO sides
-- (name,price,description)VALUES
-- ("Fries",10.2,"Salty small fries");
-- INSERT INTO sides
-- (name,price,description)VALUES
-- ("Bread Sticks",12,"made with fresh breads");
-- INSERT INTO sides
-- (name,price,description)VALUES
-- ("Cheese balls",18,"made with fresh cheese");
-- SELECT * FROM sides;

CREATE TABLE drinks(
  id int AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL UNIQUE,
  price DECIMAL(6,2) NOT NULL,
  description VARCHAR(255),
  PRIMARY KEY(id)
);
INSERT INTO drinks
(name,price,description)VALUES
("Coka Cola",12.2,"chilled drink");
INSERT INTO drinks
(name,price,description)VALUES
("Dew",20,"dar k aage jeet hai");
INSERT INTO drinks
(name,price,description)VALUES
("Pepsi",15.21,"cold drink");
SELECT * FROM drinks;

-- INSERT INTO burger
-- (name,bun,price,toppings,description)VALUES
-- ("HamBurger","Ham",10,"ham","delicious");
-- INSERT INTO burger
-- (name,bun,price,toppings,description)VALUES
-- ("heeseBurger","wheat",8,"cheese","very tasty");

-- SELECT * FROM burger;