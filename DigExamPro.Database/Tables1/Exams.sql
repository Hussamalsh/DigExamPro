CREATE TABLE [dbo].[Exams] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (255)  NOT NULL,
    [Description]      NVARCHAR (1000) NULL,
    [CreatedDate]      DATETIME        DEFAULT (getdate()) NULL,
    [LastModifiedDate] DATETIME        NULL,
    [Duration] INT
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

