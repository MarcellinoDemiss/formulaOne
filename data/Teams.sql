CREATE TABLE [dbo].[Team]
(
	[ID] int PRIMARY KEY IDENTITY(1,1),
    [TeamName] varchar(255) UNIQUE NOT NULL,
    [TeamLogo] image NOT NULL,
    [Base] varchar(255) NOT NULL,
    [TeamChief] varchar(255) NOT NULL,
    [TechnicalChief] varchar(255) NOT NULL,
	[PowerUnit] varchar(255) NOT NULL,
	[CarImage] image NOT NULL,
	[CountryID] char(2) NOT NULL,
	[WorldChampionships] int default 0,
    [PolePositions] int default 0
);

INSERT INTO [Team]
VALUES(
		'Mercedes-AMG Petronas F1 Team',
		'C:\\data\\formulaone\\img\\mercedesTeamLogo.jpg',
        'Brackley',
		'Toto Wolff',
		'James Allison',
		'Mercedes',
		'C:\\data\\formulaone\\img\\mercedesCarImage.jpg',
		'UK',
		6,
		113        
);
INSERT INTO [Team]
VALUES(
		'Aston Martin Red Bull Racing',
		'C:\\data\\formulaone\\img\\redBullTeamLogo.jpg',
        'Milton Keynes',
		'Christian Horner',
		'Pierre Waché',
		'Honda',
		'C:\\data\\formulaone\\img\\redBullCarImage.jpg',
		'UK',
		4,
		66        
);
INSERT INTO [Team]
VALUES(
		'McLaren F1 Team',
		'C:\\data\\formulaone\\img\\mcLarenTeamLogo.jpg',
        'Woking',
		'Andreas Seidl',
		'James Key',
		'Renault',
		'C:\\data\\formulaone\\img\\mcLarenCarImage.jpg',
		'UK',
		8,
		155        
);
INSERT INTO [Team]
VALUES(
		'BWT Racing Point F1 Team',
		'C:\\data\\formulaone\\img\\racingPointTeamLogo.jpg',
        'Silverstone',
		'Otmar Szafnauer',
		'Andrew Green',
		'BWT Mercedes',
		'C:\\data\\formulaone\\img\\racingPointCarImage.jpg',
		'UK',
		0,
		0        
);
INSERT INTO [Team]
VALUES(
		'Renault DP World F1 Team',
		'C:\\data\\formulaone\\img\\renaultTeamLogo.jpg',
        'Enstone',
		'Cyril Abiteboul',
		'TBC',
		'Renault',
		'C:\\data\\formulaone\\img\\renaultCarImage.jpg',
		'UK',
		2,
		20        
);
INSERT INTO [Team]
VALUES(
		'Scuderia Ferrari Mission Winnow',
		'C:\\data\\formulaone\\img\\ferrariTeamLogo.jpg',
        'Maranello',
		'Mattia Binotto',
		'Simone Resta',
		'Ferrari',
		'C:\\data\\formulaone\\img\\ferrariCarImage.jpg',
		'IT',
		16,
		221        
);
INSERT INTO [Team]
VALUES(
		'Scuderia AlphaTauri Honda',
		'C:\\data\\formulaone\\img\\alphaTauriTeamLogo.jpg',
        'Faenza',
		'Franz Tost',
		'Jody Egginton',
		'Honda',
		'C:\\data\\formulaone\\img\\alphaTauriCarImage.jpg',
		'IT',
		0,
		1        
);
INSERT INTO [Team]
VALUES(
		'Alfa Romeo Racing ORLEN',
		'C:\\data\\formulaone\\img\\alfaRomeoTeamLogo.jpg',
        'Hinwil',
		'Frédéric Vasseur',
		'Jan Monchaux',
		'Ferrari',
		'C:\\data\\formulaone\\img\\alfaRomeoCarImage.jpg',
		'IT',
		0,
		1        
);
INSERT INTO [Team]
VALUES(
		'Haas F1 Team',
		'C:\\data\\formulaone\\img\\haasTeamLogo.jpg',
        'Kannapolis',
		'Guenther Steiner',
		'Rob Taylor',
		'Ferrari',
		'C:\\data\\formulaone\\img\\haasCarImage.jpg',
		'US',
		0,
		0        
);
INSERT INTO [Team]
VALUES(
		'Williams Racing',
		'C:\\data\\formulaone\\img\\williamsTeamLogo.jpg',
        'Grove',
		'Simon Roberts',
		'TBC',
		'Mercedes',
		'C:\\data\\formulaone\\img\\williamsCarImage.jpg',
		'UK',
		9,
		129        
);

