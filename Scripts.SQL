
CREATE DATABASE CTTDB;

USE CTTDB;

CREATE TABLE [dbo].[Items] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (500)  NOT NULL,
    [IMG]         NVARCHAR (100)  NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [Stock]       INT             NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO Users (Id,Password, Email, Admin, Staff) VALUES (0,'chilterntalkingtherapies@gmail.com', 'AQAAAAEAACcQAAAAEMBg5UqcaZ3Sri2w9wHq3Q0x1tRY0O4MuLDjeGfbqT7fNHUj\u002Ba74SUZ5rnODSWo8Xw==', True, True)
INSERT INTO Users (Id,Password, Email, Admin, Staff) VALUES (1,'TestStaff', 'AQAAAAEAACcQAAAAENZYFKnVVaZL/WqElO2cJrvLG1dux27EuLDGeItdsej658VaehzNFYiStbN6tkdGCg==', False, True)
INSERT INTO Users (Id,Password, Email, Admin, Staff) VALUES (2,'TestClient', 'AQAAAAEAACcQAAAAEFoGoawVtV/X1DFEmG7MklX5CbL1SpsRu8S44M77tKUy1A\u002BH7GQe1cuB9L3vgQpF/g==', False, False)

