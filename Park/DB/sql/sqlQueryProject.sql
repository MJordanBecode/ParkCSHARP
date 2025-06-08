-- installation packages pour sqlite : dotnet add package System.Data.SQLite => permet de communiquer avec la db

-- Altération de la table attraction pour qu'elle ait la colonne image_path
ALTER TABLE attraction
ADD COLUMN image_path VARCHAR(255);

--  Ajout des différentes attractions dans la table attractions
PRAGMA foreign_keys = ON; --Permet d'activier les contraintes des FK

INSERT INTO attraction (id_attraction, name_attraction, level_attraction, happiness, attraction_price, image_path)
VALUES 
(1, 'Auto Tamponeuse', 1, 4, 450, 'images/AutoTamponeuse.png'),
(2, 'Bateau à Bascule', 1, 6, 550, 'images/BateauBascule.png'),
(3, 'Bateau Tamponneur', 1, 4, 450, 'images/BateauTamponneur.png'),
(4, 'Bowling', 1, 7, 600, 'images/Bowling.png'),
(5, 'Carrousel', 1, 2, 350, 'images/Carrousel.png'),
(6, 'Chaises Volantes', 1, 9, 700, 'images/ChaiseVolante.png');

-- Insertion des différents id de attractions dans shop
INSERT INTO shop (id_attraction) VALUES ('1'); -- si '1' existe dans attraction.id_attraction
INSERT INTO shop (id_attraction) VALUES ('2'); -- si '1' existe dans attraction.id_attraction
INSERT INTO shop (id_attraction) VALUES ('3'); -- si '1' existe dans attraction.id_attraction
INSERT INTO shop (id_attraction) VALUES ('4'); -- si '1' existe dans attraction.id_attraction
INSERT INTO shop (id_attraction) VALUES ('5'); -- si '1' existe dans attraction.id_attraction
INSERT INTO shop (id_attraction) VALUES ('6'); -- si '1' existe dans attraction.id_attraction

-- Permet de voir le contenu de shop avec la table attraction
SELECT *
FROM shop
INNER JOIN attraction ON shop.id_attraction = attraction.id_attraction;

-- Permet de voir le contenue jointé de la table price et happiness 
SELECT price.attraction_price, price.visitor_price, happiness.happiness
FROM price
CROSS JOIN happiness;

