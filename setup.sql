CREATE TABLE IF NOT EXISTS cars (
<<<<<<< HEAD
=======
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
>>>>>>> acadc8b8c1ced4196f5f57f513e30ca8f73ec9ee
    id INT NOT NULL AUTO_INCREMENT,
    make VARCHAR(255) NOT NULL,
    model VARCHAR(255) NOT NULL,
    year INT,
    imgUrl VARCHAR(255) NOT NULL,
    price INT,
    description VARCHAR(255),
    user VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS favoriteCars(
    id INT NOT NULL AUTO_INCREMENT,
    carId INT NOT NULL,
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(carId)
    REFERENCES cars(id)
    ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS favoriteHouses(
    id INT NOT NULL AUTO_INCREMENT,
    houseId INT NOT NULL,
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(houseId)
    REFERENCES houses(id)
    ON DELETE CASCADE
); 

CREATE TABLE IF NOT EXISTS favoriteJobs(
    id INT NOT NULL AUTO_INCREMENT,
    jobId INT NOT NULL,
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(jobId)
    REFERENCES jobs(id)
    ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS houses (
    id INT NOT NULL AUTO_INCREMENT,
    floors INT,
    sizeSqFt INT,
    price INT,
    imgUrl VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    user VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
); 

CREATE TABLE IF NOT EXISTS jobs (
    id INT NOT NULL AUTO_INCREMENT,
    company VARCHAR(255) NOT NULL,
    pay INT,
    title VARCHAR(255) NOT NULL,
    user VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
); 

INSERT INTO houses
(floors, price, user)
VALUES
(13, 3333, "google-oauth2|101867735406718996676");

/*ALTER TABLE jobs
ADD COLUMN user VARCHAR(255) NOT NULL

/*ALTER TABLE jobs
DROP COLUMN userId

/*ALTER TABLE houses
ADD COLUMN user VARCHAR(255) NOT NULL

/*ALTER TABLE houses
DROP COLUMN userId

/*ALTER TABLE cars
DROP COLUMN userId*/

/*ALTER TABLE cars
ADD COLUMN user VARCHAR(255) NOT NULL*/





