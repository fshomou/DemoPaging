
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2018 14:37:27
-- Generated from EDMX file: D:\Faris\Projects\DemoPaging\DemoPaging\EFModel\EfCustomer.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CustomerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CustomerTB]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerTB];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerTBs'
CREATE TABLE [dbo].[CustomerTBs] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Address] varchar(50)  NULL,
    [Country] varchar(50)  NULL,
    [City] varchar(50)  NULL,
    [Phoneno] varchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerID] in table 'CustomerTBs'
ALTER TABLE [dbo].[CustomerTBs]
ADD CONSTRAINT [PK_CustomerTBs]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------