
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/18/2012 20:21:24
-- Generated from EDMX file: D:\gplus.saimoe\Saimoe\Models\EDMX\Saimoe.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Saimoe];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ContestantProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contestants] DROP CONSTRAINT [FK_ContestantProfile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contestants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contestants];
GO
IF OBJECT_ID(N'[dbo].[Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profiles];
GO


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contestants'
CREATE TABLE [dbo].[Contestants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GooglePlusId] nvarchar(21) UNIQUE NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [Profile_Id] int UNIQUE  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Interest] nvarchar(21)  NOT NULL,
    [Characteristic] nvarchar(max)  NOT NULL,
    [ActingCute] nvarchar(max)  NOT NULL,
    [RegistrationPost] nvarchar(max)  NULL,
    [Tagline] nvarchar(max)  NOT NULL,
    [JoinedYear] smallint  NOT NULL,
    [JoinedMonth] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Contestants'
ALTER TABLE [dbo].[Contestants]
ADD CONSTRAINT [PK_Contestants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Profile_Id] in table 'Contestants'
ALTER TABLE [dbo].[Contestants]
ADD CONSTRAINT [FK_ContestantProfile]
    FOREIGN KEY ([Profile_Id])
    REFERENCES [dbo].[Profiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContestantProfile'
CREATE INDEX [IX_FK_ContestantProfile]
ON [dbo].[Contestants]
    ([Profile_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------