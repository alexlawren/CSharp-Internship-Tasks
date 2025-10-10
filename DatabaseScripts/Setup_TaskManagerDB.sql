IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TaskManagerDB')
BEGIN
    CREATE DATABASE TaskManagerDB;
END
GO

USE TaskManagerDB;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Tasks](
        [Id]          INT             IDENTITY(1,1) NOT NULL,
        [Title]       NVARCHAR(255)   NOT NULL,
        [Description] NVARCHAR(MAX)   NULL,
        [IsCompleted] BIT             NOT NULL CONSTRAINT [DF_Tasks_IsCompleted] DEFAULT ((0)),
        [CreatedAt]   DATETIME        NOT NULL CONSTRAINT [DF_Tasks_CreatedAt] DEFAULT (GETDATE()),
        
        CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO