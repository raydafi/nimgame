CREATE DATABASE db_allumettes;
USE db_allumettes;

CREATE TABLE players (
    id INT AUTO_INCREMENT,
    name VARCHAR(50),
    wins INT,
    loses INT,
    PRIMARY KEY (id)
);

CREATE TABLE history (
    id INT AUTO_INCREMENT,
    player1_id INT,
    player2_id INT,
    game_type VARCHAR(50),
    result VARCHAR(50),
    PRIMARY KEY (id),
    FOREIGN KEY (player1_id) REFERENCES players(id),
    FOREIGN KEY (player2_id) REFERENCES players(id)
);