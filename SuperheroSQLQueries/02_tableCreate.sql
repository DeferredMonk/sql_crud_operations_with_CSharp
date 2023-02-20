CREATE TABLE Superhero (
	Id int NOT NULL IDENTITY(1,1),
	Name nvarchar(255) NOT NULL,
	Alias nvarchar(255),
	Origin nvarchar(255),
	PRIMARY KEY (Id)
);

CREATE TABLE Assistant (
	Id int NOT NULL IDENTITY(1,1),
	Name nvarchar(255) NOT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE Power (
	Id int NOT NULL IDENTITY(1,1),
	Name nvarchar(255) NOT NULL,
	Description nvarchar(255) NOT NULL,
	PRIMARY KEY (Id)
);