CREATE TABLE [dbo].[Scores] (
    [pos]     INT IDENTITY (1, 1) NOT NULL,
    [points]   INT NOT NULL,
    [extDriver] INT NOT NULL,
    [extTeam] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([pos] ASC)
);

SET IDENTITY_INSERT [dbo].[Scores] ON;
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(0, 0, 44, 10);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(1, 25, 4, 9);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(2, 18, 8, 8);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(3, 15, 9, 7);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(4, 12, 33, 6);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(5, 10, 15, 5);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(6, 8, 23, 4);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(7, 6, 55, 3);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(8, 4, 11, 2);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(9, 2, 7, 1);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(10, 1, 18, 4);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(11, 0, 99, 7);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(12, 0, 20, 9);
INSERT INTO [dbo].[Scores] ([pos], [points], [extDriver], [extTeam]) VALUES(13, 0, 63, 10);
SET IDENTITY_INSERT [dbo].[Scores] OFF;