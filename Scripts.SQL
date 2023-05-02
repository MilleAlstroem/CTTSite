
CREATE DATABASE CTTDB;

USE CTTDB;

CREATE TABLE [dbo].[Table] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Price]       DECIMAL (18)  NOT NULL,
    [IMG]         VARCHAR (100) NOT NULL,
    [Description] VARCHAR (500) NOT NULL,
    [Stock]       INT           NOT NULL
);