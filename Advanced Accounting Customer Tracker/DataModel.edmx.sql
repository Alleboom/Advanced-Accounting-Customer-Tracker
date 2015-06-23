
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2015 09:04:55
-- Generated from EDMX file: C:\Users\Zach\Source\Workspaces\Advanced Accounting2\Advanced Accounting Customer Tracker\Advanced Accounting Customer Tracker\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Customer_Service]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerServiceAssociatives] DROP CONSTRAINT [FK_Customer_Service];
GO
IF OBJECT_ID(N'[dbo].[FK_Service_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerServiceAssociatives] DROP CONSTRAINT [FK_Service_Customer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[CustomerServiceAssociatives]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerServiceAssociatives];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Phone_Number] varchar(max)  NULL,
    [Cell_Phone_Number] varchar(max)  NULL,
    [Email] varchar(max)  NULL,
    [Tax_Form] varchar(max)  NULL,
    [Accounting_Method] varchar(max)  NULL,
    [Address] varchar(max)  NULL
);
GO

-- Creating table 'CustomerServiceAssociatives'
CREATE TABLE [dbo].[CustomerServiceAssociatives] (
    [ServiceID] int  NOT NULL,
    [CustomerID] int  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [Performed] bit  NULL,
    [DueDate] datetime  NULL,
    [Frequency] varchar(max)  NULL,
    [Reminder] bit  NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Description] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerServiceAssociatives'
ALTER TABLE [dbo].[CustomerServiceAssociatives]
ADD CONSTRAINT [PK_CustomerServiceAssociatives]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerID] in table 'CustomerServiceAssociatives'
ALTER TABLE [dbo].[CustomerServiceAssociatives]
ADD CONSTRAINT [FK_Customer_Service]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Customer_Service'
CREATE INDEX [IX_FK_Customer_Service]
ON [dbo].[CustomerServiceAssociatives]
    ([CustomerID]);
GO

-- Creating foreign key on [ServiceID] in table 'CustomerServiceAssociatives'
ALTER TABLE [dbo].[CustomerServiceAssociatives]
ADD CONSTRAINT [FK_Service_Customer]
    FOREIGN KEY ([ServiceID])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Service_Customer'
CREATE INDEX [IX_FK_Service_Customer]
ON [dbo].[CustomerServiceAssociatives]
    ([ServiceID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------