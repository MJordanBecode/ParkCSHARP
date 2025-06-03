CREATE TABLE price (
                       attraction_price INTEGER PRIMARY KEY,
                       visitor_price INTEGER NOT NULL DEFAULT 50
);

CREATE TABLE happiness (
                           happiness INTEGER PRIMARY KEY
);

CREATE TABLE attraction (
                            id_attraction VARCHAR(50) PRIMARY KEY,
                            name_attraction VARCHAR(50) UNIQUE NOT NULL,
                            level_attraction INTEGER NOT NULL DEFAULT 1,
                            happiness INTEGER NOT NULL,
                            attraction_price INTEGER NOT NULL,
                            FOREIGN KEY (happiness) REFERENCES happiness(happiness),
                            FOREIGN KEY (attraction_price) REFERENCES price(attraction_price)
);

CREATE TABLE shop (
                      id_attraction VARCHAR(50) PRIMARY KEY,
                      counter_attraction INTEGER NOT NULL DEFAULT 0,
                      set_flag BOOLEAN NOT NULL DEFAULT false,
                      FOREIGN KEY (id_attraction) REFERENCES attraction(id_attraction)
);

CREATE TABLE bank (
                      capital INTEGER NOT NULL DEFAULT 5000
);

CREATE TABLE visitor (
                         total_visitor INTEGER NOT NULL DEFAULT 0
);
