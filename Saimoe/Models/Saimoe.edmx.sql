
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/09/2012 22:22:15
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
IF OBJECT_ID(N'[dbo].[FK_ProfileUserCache]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profiles] DROP CONSTRAINT [FK_ProfileUserCache];
GO
IF OBJECT_ID(N'[dbo].[FK_ContestantGrouping_Contestant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContestantGrouping] DROP CONSTRAINT [FK_ContestantGrouping_Contestant];
GO
IF OBJECT_ID(N'[dbo].[FK_ContestantGrouping_Grouping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContestantGrouping] DROP CONSTRAINT [FK_ContestantGrouping_Grouping];
GO
IF OBJECT_ID(N'[dbo].[FK_VotingGrouping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groupings] DROP CONSTRAINT [FK_VotingGrouping];
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
IF OBJECT_ID(N'[dbo].[Administrators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Administrators];
GO
IF OBJECT_ID(N'[dbo].[Votings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Votings];
GO
IF OBJECT_ID(N'[dbo].[UserCaches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserCaches];
GO
IF OBJECT_ID(N'[dbo].[Groupings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groupings];
GO
IF OBJECT_ID(N'[dbo].[ContestantGrouping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContestantGrouping];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contestants'
CREATE TABLE [dbo].[Contestants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GooglePlusId] nvarchar(50)  NOT NULL,
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
    [GooglePlusId] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Contests'
CREATE TABLE [dbo].[Contests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Deadline] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Status] tinyint  NOT NULL,
    [MininumVoteNumber] int  NOT NULL,
    [MaximumVoteNumber] int  NOT NULL
);
GO

-- Creating table 'UserCaches'
CREATE TABLE [dbo].[UserCaches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Groupings'
CREATE TABLE [dbo].[Groupings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Contest_Id] int  NOT NULL
);
GO

-- Creating table 'Votes'
CREATE TABLE [dbo].[Votes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreatedDate] nvarchar(max)  NOT NULL,
    [GooglePlusId] nvarchar(50)  NOT NULL,
    [Status] int  NOT NULL,
    [Contestant_Id] int  NOT NULL,
    [Grouping_Id] int  NOT NULL
);
GO

-- Creating table 'ContestantGrouping'
CREATE TABLE [dbo].[ContestantGrouping] (
    [Contestants_Id] int  NOT NULL,
    [Groupings_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'Contests'
ALTER TABLE [dbo].[Contests]
ADD CONSTRAINT [PK_Contests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserCaches'
ALTER TABLE [dbo].[UserCaches]
ADD CONSTRAINT [PK_UserCaches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Groupings'
ALTER TABLE [dbo].[Groupings]
ADD CONSTRAINT [PK_Groupings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [PK_Votes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Contestants_Id], [Groupings_Id] in table 'ContestantGrouping'
ALTER TABLE [dbo].[ContestantGrouping]
ADD CONSTRAINT [PK_ContestantGrouping]
    PRIMARY KEY NONCLUSTERED ([Contestants_Id], [Groupings_Id] ASC);
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

-- Creating foreign key on [Contestants_Id] in table 'ContestantGrouping'
ALTER TABLE [dbo].[ContestantGrouping]
ADD CONSTRAINT [FK_ContestantGrouping_Contestant]
    FOREIGN KEY ([Contestants_Id])
    REFERENCES [dbo].[Contestants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Groupings_Id] in table 'ContestantGrouping'
ALTER TABLE [dbo].[ContestantGrouping]
ADD CONSTRAINT [FK_ContestantGrouping_Grouping]
    FOREIGN KEY ([Groupings_Id])
    REFERENCES [dbo].[Groupings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContestantGrouping_Grouping'
CREATE INDEX [IX_FK_ContestantGrouping_Grouping]
ON [dbo].[ContestantGrouping]
    ([Groupings_Id]);
GO

-- Creating foreign key on [Contest_Id] in table 'Groupings'
ALTER TABLE [dbo].[Groupings]
ADD CONSTRAINT [FK_ContestGrouping]
    FOREIGN KEY ([Contest_Id])
    REFERENCES [dbo].[Contests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContestGrouping'
CREATE INDEX [IX_FK_ContestGrouping]
ON [dbo].[Groupings]
    ([Contest_Id]);
GO

-- Creating foreign key on [Contestant_Id] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [FK_ContestantVote]
    FOREIGN KEY ([Contestant_Id])
    REFERENCES [dbo].[Contestants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContestantVote'
CREATE INDEX [IX_FK_ContestantVote]
ON [dbo].[Votes]
    ([Contestant_Id]);
GO

-- Creating foreign key on [Grouping_Id] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [FK_GroupingVote]
    FOREIGN KEY ([Grouping_Id])
    REFERENCES [dbo].[Groupings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupingVote'
CREATE INDEX [IX_FK_GroupingVote]
ON [dbo].[Votes]
    ([Grouping_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------