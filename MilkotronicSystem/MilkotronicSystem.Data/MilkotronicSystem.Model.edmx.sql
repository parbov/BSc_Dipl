
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/12/2013 11:11:36
-- Generated from EDMX file: D:\TU\diplomna\MilkotronicSystem\MilkotronicSystem.Data\MilkotronicSystem.Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MilkotronicSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PCB_Data_PCBs1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCB_Data] DROP CONSTRAINT [FK_PCB_Data_PCBs1];
GO
IF OBJECT_ID(N'[dbo].[FK_Sensors_PCBs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sensors] DROP CONSTRAINT [FK_Sensors_PCBs];
GO
IF OBJECT_ID(N'[dbo].[FK_Thermo_Data_PCBs1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Thermo_Data] DROP CONSTRAINT [FK_Thermo_Data_PCBs1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PCB_Data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PCB_Data];
GO
IF OBJECT_ID(N'[dbo].[PCBs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PCBs];
GO
IF OBJECT_ID(N'[dbo].[Sensors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sensors];
GO
IF OBJECT_ID(N'[dbo].[Thermo_Data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Thermo_Data];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PCB_Data'
CREATE TABLE [dbo].[PCB_Data] (
    [id] int IDENTITY(1,1) NOT NULL,
    [pcbId] int  NOT NULL,
    [date] nchar(10)  NOT NULL,
    [time] nchar(10)  NOT NULL,
    [operation] nvarchar(50)  NOT NULL,
    [model] nchar(10)  NOT NULL,
    [boxNumber] int  NULL,
    [speed] nvarchar(50)  NOT NULL,
    [Cal1] nvarchar(15)  NULL,
    [Cal2] nvarchar(15)  NULL,
    [Cal3] nvarchar(15)  NULL,
    [program] varchar(max)  NULL,
    [data] varchar(max)  NULL,
    [orderNumber] nvarchar(10)  NULL,
    [ClientName] nvarchar(50)  NULL,
    [country] nvarchar(50)  NULL,
    [operator] nchar(10)  NULL,
    [programVersion] float  NULL,
    [options] nvarchar(50)  NULL,
    [numberPcb] int  NOT NULL,
    [numberSensor] int  NOT NULL
);
GO

-- Creating table 'PCBs'
CREATE TABLE [dbo].[PCBs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [pcbNumber] int  NOT NULL
);
GO

-- Creating table 'Sensors'
CREATE TABLE [dbo].[Sensors] (
    [id] int IDENTITY(1,1) NOT NULL,
    [number] int  NOT NULL,
    [pcbId] int  NOT NULL
);
GO

-- Creating table 'Thermo_Data'
CREATE TABLE [dbo].[Thermo_Data] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] nvarchar(50)  NOT NULL,
    [time] varchar(50)  NOT NULL,
    [box] int  NULL,
    [pcbId] int  NOT NULL,
    [sensor] int  NOT NULL,
    [N40] int  NULL,
    [P60] int  NULL,
    [workplace] nvarchar(50)  NULL,
    [programVersion] float  NULL,
    [ad623] int  NULL,
    [amplitude] int  NULL,
    [numberPcb] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(50)  NOT NULL,
    [authCode] nvarchar(40)  NOT NULL,
    [sessionKey] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'PCB_Data'
ALTER TABLE [dbo].[PCB_Data]
ADD CONSTRAINT [PK_PCB_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PCBs'
ALTER TABLE [dbo].[PCBs]
ADD CONSTRAINT [PK_PCBs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Sensors'
ALTER TABLE [dbo].[Sensors]
ADD CONSTRAINT [PK_Sensors]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Thermo_Data'
ALTER TABLE [dbo].[Thermo_Data]
ADD CONSTRAINT [PK_Thermo_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [pcbId] in table 'PCB_Data'
ALTER TABLE [dbo].[PCB_Data]
ADD CONSTRAINT [FK_PCB_Data_PCBs1]
    FOREIGN KEY ([pcbId])
    REFERENCES [dbo].[PCBs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PCB_Data_PCBs1'
CREATE INDEX [IX_FK_PCB_Data_PCBs1]
ON [dbo].[PCB_Data]
    ([pcbId]);
GO

-- Creating foreign key on [pcbId] in table 'Sensors'
ALTER TABLE [dbo].[Sensors]
ADD CONSTRAINT [FK_Sensors_PCBs]
    FOREIGN KEY ([pcbId])
    REFERENCES [dbo].[PCBs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sensors_PCBs'
CREATE INDEX [IX_FK_Sensors_PCBs]
ON [dbo].[Sensors]
    ([pcbId]);
GO

-- Creating foreign key on [pcbId] in table 'Thermo_Data'
ALTER TABLE [dbo].[Thermo_Data]
ADD CONSTRAINT [FK_Thermo_Data_PCBs1]
    FOREIGN KEY ([pcbId])
    REFERENCES [dbo].[PCBs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Thermo_Data_PCBs1'
CREATE INDEX [IX_FK_Thermo_Data_PCBs1]
ON [dbo].[Thermo_Data]
    ([pcbId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------