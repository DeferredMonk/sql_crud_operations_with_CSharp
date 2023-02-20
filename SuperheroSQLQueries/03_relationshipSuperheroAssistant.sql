ALTER TABLE Assistant
ADD SuperheroId int,
FOREIGN KEY (SuperheroId) REFERENCES Superhero (Id);
