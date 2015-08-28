
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2015 14:33:29
-- Generated from EDMX file: C:\Users\Zach\Documents\GitHub\Advanced-Accounting-Customer-Tracker\Advanced Accounting Customer Tracker\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Data];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerCustomerServiceAssociative]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerServiceAssociatives] DROP CONSTRAINT [FK_CustomerCustomerServiceAssociative];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceCustomerServiceAssociative]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerServiceAssociatives] DROP CONSTRAINT [FK_ServiceCustomerServiceAssociative];
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
    [Name] nvarchar(max)  NOT NULL,
    [Phone_Number] nvarchar(max)  NULL,
    [Cell_Phone_Number] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Tax_Form] nvarchar(max)  NULL,
    [Accounting_Method] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL
);
GO

-- Creating table 'CustomerServiceAssociatives'
CREATE TABLE [dbo].[CustomerServiceAssociatives] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Performed] nvarchar(max)  NULL,
    [DueDate] nvarchar(max)  NULL,
    [Frequency] nvarchar(max)  NULL,
    [Reminder] nvarchar(max)  NULL,
    [CustomerID] int  NOT NULL,
    [ServiceID] int  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL
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
ADD CONSTRAINT [FK_CustomerCustomerServiceAssociative]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCustomerServiceAssociative'
CREATE INDEX [IX_FK_CustomerCustomerServiceAssociative]
ON [dbo].[CustomerServiceAssociatives]
    ([CustomerID]);
GO

-- Creating foreign key on [ServiceID] in table 'CustomerServiceAssociatives'
ALTER TABLE [dbo].[CustomerServiceAssociatives]
ADD CONSTRAINT [FK_ServiceCustomerServiceAssociative]
    FOREIGN KEY ([ServiceID])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceCustomerServiceAssociative'
CREATE INDEX [IX_FK_ServiceCustomerServiceAssociative]
ON [dbo].[CustomerServiceAssociatives]
    ([ServiceID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------