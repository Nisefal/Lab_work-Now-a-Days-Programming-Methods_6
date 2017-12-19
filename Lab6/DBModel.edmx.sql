
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/19/2017 22:26:35
-- Generated from EDMX file: C:\Users\kolya\source\repos\Lab6\Lab6\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Computing_eguipment'
CREATE TABLE [dbo].[Computing_eguipment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [price] nvarchar(max)  NOT NULL,
    [computing_power] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CE_user'
CREATE TABLE [dbo].[CE_user] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [surname] nvarchar(max)  NOT NULL,
    [position] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Computing_eguipmentCE_user'
CREATE TABLE [dbo].[Computing_eguipmentCE_user] (
    [Computing_eguipment_Id] int  NOT NULL,
    [CE_user_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Computing_eguipment'
ALTER TABLE [dbo].[Computing_eguipment]
ADD CONSTRAINT [PK_Computing_eguipment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CE_user'
ALTER TABLE [dbo].[CE_user]
ADD CONSTRAINT [PK_CE_user]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Computing_eguipment_Id], [CE_user_Id] in table 'Computing_eguipmentCE_user'
ALTER TABLE [dbo].[Computing_eguipmentCE_user]
ADD CONSTRAINT [PK_Computing_eguipmentCE_user]
    PRIMARY KEY CLUSTERED ([Computing_eguipment_Id], [CE_user_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Computing_eguipment_Id] in table 'Computing_eguipmentCE_user'
ALTER TABLE [dbo].[Computing_eguipmentCE_user]
ADD CONSTRAINT [FK_Computing_eguipmentCE_user_Computing_eguipment]
    FOREIGN KEY ([Computing_eguipment_Id])
    REFERENCES [dbo].[Computing_eguipment]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CE_user_Id] in table 'Computing_eguipmentCE_user'
ALTER TABLE [dbo].[Computing_eguipmentCE_user]
ADD CONSTRAINT [FK_Computing_eguipmentCE_user_CE_user]
    FOREIGN KEY ([CE_user_Id])
    REFERENCES [dbo].[CE_user]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Computing_eguipmentCE_user_CE_user'
CREATE INDEX [IX_FK_Computing_eguipmentCE_user_CE_user]
ON [dbo].[Computing_eguipmentCE_user]
    ([CE_user_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------