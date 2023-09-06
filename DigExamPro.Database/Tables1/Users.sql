CREATE TABLE [dbo].[Users] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (255) NOT NULL,
    [Email]        NVARCHAR (255) NOT NULL,
    [PasswordHash] NVARCHAR (255) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NULL
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

