
CREATE TABLE Superhero_Power (
	SuperheroId int NOT NULL,
	PowerId int NOT NULL
	PRIMARY KEY (SuperheroId, PowerId)
);

ALTER TABLE Superhero_Power 
ADD FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id);


ALTER TABLE Superhero_Power 
ADD FOREIGN KEY (PowerId) REFERENCES Power(Id);