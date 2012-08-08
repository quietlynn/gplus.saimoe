
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/08/2012 14:12:59
-- Generated from EDMX file: D:\gplus.saimoe\Saimoe\Models\Saimoe.edmx
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
    [GooglePlusId] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [Profile_Id] int  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Interest] nvarchar(max)  NOT NULL,
    [Characteristic] nvarchar(max)  NOT NULL,
    [ActingCute] nvarchar(max)  NOT NULL,
    [RegistrationPost] nvarchar(max)  NULL,
    [Tagline] nvarchar(max)  NOT NULL,
    [JoinedDate] datetime  NOT NULL,
    [UserCaches_Id] int  NOT NULL
);
GO

-- Creating table 'Administrators'
CREATE TABLE [dbo].[Administrators] (
    [GooglePlusId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Votings'
CREATE TABLE [dbo].[Votings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Deadline] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'UserCaches'
CREATE TABLE [dbo].[UserCaches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL
);
GO

-- Creating table 'ContestantVoting'
CREATE TABLE [dbo].[ContestantVoting] (
    [Contestants_Id] int  NOT NULL,
    [Votings_Id] int  NOT NULL
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

-- Creating primary key on [GooglePlusId] in table 'Administrators'
ALTER TABLE [dbo].[Administrators]
ADD CONSTRAINT [PK_Administrators]
    PRIMARY KEY CLUSTERED ([GooglePlusId] ASC);
GO

-- Creating primary key on [Id] in table 'Votings'
ALTER TABLE [dbo].[Votings]
ADD CONSTRAINT [PK_Votings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserCaches'
ALTER TABLE [dbo].[UserCaches]
ADD CONSTRAINT [PK_UserCaches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Contestants_Id], [Votings_Id] in table 'ContestantVoting'
ALTER TABLE [dbo].[ContestantVoting]
ADD CONSTRAINT [PK_ContestantVoting]
    PRIMARY KEY NONCLUSTERED ([Contestants_Id], [Votings_Id] ASC);
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

-- Creating foreign key on [Contestants_Id] in table 'ContestantVoting'
ALTER TABLE [dbo].[ContestantVoting]
ADD CONSTRAINT [FK_ContestantVoting_Contestant]
    FOREIGN KEY ([Contestants_Id])
    REFERENCES [dbo].[Contestants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Votings_Id] in table 'ContestantVoting'
ALTER TABLE [dbo].[ContestantVoting]
ADD CONSTRAINT [FK_ContestantVoting_Voting]
    FOREIGN KEY ([Votings_Id])
    REFERENCES [dbo].[Votings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContestantVoting_Voting'
CREATE INDEX [IX_FK_ContestantVoting_Voting]
ON [dbo].[ContestantVoting]
    ([Votings_Id]);
GO

-- Creating foreign key on [UserCaches_Id] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [FK_ProfileUserCache]
    FOREIGN KEY ([UserCaches_Id])
    REFERENCES [dbo].[UserCaches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfileUserCache'
CREATE INDEX [IX_FK_ProfileUserCache]
ON [dbo].[Profiles]
    ([UserCaches_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------