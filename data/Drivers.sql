CREATE TABLE [dbo].[Driver]
(
	[ID] int PRIMARY KEY IDENTITY(1,1),
	[Number] int UNIQUE NOT NULL,
	[Name] varchar(255) NOT NULL,
	[DOB] date,
	[HelmetImage] image NOT NULL,
	[Image] image NOT NULL,
	[TeamID] int NOT NULL,
	[Podiums] int NOT NULL,
	[CountryCode] char(2) NOT NULL,
);

INSERT INTO [Driver]
VALUES(
		44,
		'Lewis Hamilton',
        CONVERT(date,'1985-01-07'),
		'C:\data\formulaone\img\lewisHamilton-Helmet.jpg',
		'C:\data\formulaone\img\lewisHamilton.jpg',
		1,
		159,
		'GB'        
);
INSERT INTO [Driver]
VALUES(
		77,
		'Valtteri Bottas',
        CONVERT(date,'1989-08-28'),
		'C:\data\formulaone\img\valterriBottas-Helmet.jpg',
		'C:\data\formulaone\img\valterriBottas.jpg',
		1,
		53,
		'FI'        
);
INSERT INTO [Driver]
VALUES(
		33,
		'Max Verstappen',
        CONVERT(date,'1997-09-30'),
		'C:\data\formulaone\img\maxVerstappen-Helmet.jpg',
		'C:\data\formulaone\img\maxVerstappen.jpg',
		2,
		38,
		'NL'       
);
INSERT INTO [Driver]
VALUES(
		4,
		'Lando Norris',
        CONVERT(date,'1999-11-13'),
		'C:\data\formulaone\img\landoNorris-Helmet.jpg',
		'C:\data\formulaone\img\landoNorris.jpg',
		3,
		1,
		'GB'       
);
INSERT INTO [Driver]
VALUES(
		23,
		'Alexander Albon',
        CONVERT(date,'1999-03-23'),
		'C:\data\formulaone\img\alexanderAlbon-Helmet.jpg',
		'C:\data\formulaone\img\alexanderAlbon.jpg',
		2,
		1,
		'TH'        
);
INSERT INTO [Driver]
VALUES(
		3,
		'Daniel Ricciardo',
        CONVERT(date,'1989-07-01'),
		'C:\data\formulaone\img\danielRicciardo-Helmet.jpg',
		'C:\data\formulaone\img\danielRicciardo.jpg',
		5,
		29,
		'AU'        
);
INSERT INTO [Driver]
VALUES(
		16,
		'Charles Leclerc',
        CONVERT(date,'1997-10-16'),
		'C:\data\formulaone\img\charlesLeclerc-Helmet.jpg',
		'C:\data\formulaone\img\charlesLeclerc.jpg',
		6,
		12,
		'PL'        
);
INSERT INTO [Driver]
VALUES(
		18,
		'Lance Stroll',
        CONVERT(date,'1998-10-29'),
		'C:\data\formulaone\img\lanceStroll-Helmet.jpg',
		'C:\data\formulaone\img\lanceStroll.jpg',
		4,
		2,
		'CA'        
);
INSERT INTO [Driver]
VALUES(
		11,
		'Sergio Perez',
        CONVERT(date,'1990-01-26'),
		'C:\data\formulaone\img\sergioPerez-Helmet.jpg',
		'C:\data\formulaone\img\sergioPerez.jpg',
		4,
		8,
		'MX'       
);
INSERT INTO [Driver]
VALUES(
		10,
		'Pierre Gasly',
        CONVERT(date,'1996-02-07'),
		'C:\data\formulaone\img\pierreGasly-Helmet.jpg',
		'C:\data\formulaone\img\pierreGasly.jpg',
		7,
		2,
		'FR'        
);
INSERT INTO [Driver]
VALUES(
		55,
		'Carlos Sainz',
        CONVERT(date,'1994-09-01'),
		'C:\data\formulaone\img\carlosSainz-Helmet.jpg',
		'C:\data\formulaone\img\carlosSainz.jpg',
		3,
		2,
		'ES'        
);
INSERT INTO [Driver]
VALUES(
		31,
		'Esteban Ocon',
        CONVERT(date,'1996-09-17'),
		'C:\data\formulaone\img\estebanOcon-Helmet.jpg',
		'C:\data\formulaone\img\estebanOcon.jpg',
		5,
		0,
		'FR'        
);
INSERT INTO [Driver]
VALUES(
		5,
		'Sebastian Vettel',
        CONVERT(date,'1987-07-03'),
		'C:\data\formulaone\img\sebastianVettel-Helmet.jpg',
		'C:\data\formulaone\img\sebastianVettel.jpg',
		6,
		120,
		'DE'        
);
INSERT INTO [Driver]
VALUES(
		26,
		'Daniil Kvyat',
        CONVERT(date,'1994-04-26'),
		'C:\data\formulaone\img\daniilKvyat-Helmet.jpg',
		'C:\data\formulaone\img\daniilKvyat.jpg',
		7,
		3,
		'RU'        
);
INSERT INTO [Driver]
VALUES(
		7,
		'Kimi Räikkönen',
        CONVERT(date,'1979-10-17'),
		'C:\data\formulaone\img\kimiRaikkonen-Helmet.jpg',
		'C:\data\formulaone\img\kimiRaikkonen.jpg',
		8,
		103,
		'FI'        
);
INSERT INTO [Driver]
VALUES(
		99,
		'Antonio Giovinazzi',
        CONVERT(date,'1993-12-14'),
		'C:\data\formulaone\img\antonioGiovinazzi-Helmet.jpg',
		'C:\data\formulaone\img\antonioGiovinazzi.jpg',
		8,
		0,
		'IT'        
);
INSERT INTO [Driver]
VALUES(
		20,
		'Kevin Magnussen',
        CONVERT(date,'1992-10-05'),
		'C:\data\formulaone\img\kevinMagnussen-Helmet.jpg',
		'C:\data\formulaone\img\kevinMagnussen.jpg',
		9,
		1,
		'DK'        
);
INSERT INTO [Driver]
VALUES(
		6,
		'Nicholas Latifi',
        CONVERT(date,'1995-06-29'),
		'C:\data\formulaone\img\nicholasLatifi-Helmet.jpg',
		'C:\data\formulaone\img\nicholasLatifi.jpg',
		10,
		0,
		'CA'        
);
INSERT INTO [Driver]
VALUES(
		63,
		'George Russell',
        CONVERT(date,'1998-02-15'),
		'C:\data\formulaone\img\georgeRussell-Helmet.jpg',
		'C:\data\formulaone\img\georgeRussell.jpg',
		10,
		0,
		'GB'        
);
INSERT INTO [Driver]
VALUES(
		8,
		'Romain Grosjean',
        CONVERT(date,'1986-04-17'),
		'C:\data\formulaone\img\romainGrosjean-Helmet.jpg',
		'C:\data\formulaone\img\romainGrosjean.jpg',
		9,
		10,
		'FR'        
);
