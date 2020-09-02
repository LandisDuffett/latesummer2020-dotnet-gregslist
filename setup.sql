CREATE TABLE IF NOT EXISTS cars (
    id INT NOT NULL AUTO_INCREMENT,
    make VARCHAR(255) NOT NULL,
    model VARCHAR(255) NOT NULL,
    year INT,
    imgUrl VARCHAR(255) NOT NULL,
    price INT,
    description VARCHAR(255),
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
); 

CREATE TABLE IF NOT EXISTS houses (
    id INT NOT NULL AUTO_INCREMENT,
    floors INT,
    sizeSqFt INT,
    price INT,
    imgUrl VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
); 

CREATE TABLE IF NOT EXISTS jobs (
    id INT NOT NULL AUTO_INCREMENT,
    company VARCHAR(255) NOT NULL,
    pay INT,
    title VARCHAR(255) NOT NULL,
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
); 

/* CREATE TABLE cars (
    id INT NOT NULL AUTO_INCREMENT,
    make VARCHAR(255) NOT NULL,
    model VARCHAR(255) NOT NULL,
    year INT,
    imgUrl VARCHAR(255) NOT NULL,
    price INT,
    description VARCHAR(255),
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
) */


/* 
INSERT INTO cars
(make, model, year, price, imgUrl, description, userId)
VALUES
("Chevy", "Tracker", 1989, 2000, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQiEdhq7a4aHGvv8FxjKUpAg_godVfcyLzHSg&usqp=CAU", "Itsa trackin", "D$SUPERSECRETUSERID") */