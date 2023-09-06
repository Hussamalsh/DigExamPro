CREATE TABLE [dbo].[Users] (
    [UserID]       UNIQUEIDENTIFIER NOT NULL,
    [UserName]     NVARCHAR (256)   NOT NULL,
    [Email]        NVARCHAR (256)   NOT NULL,
    [PasswordHash] NVARCHAR (512)   NOT NULL,
    [PhoneNumber]  NVARCHAR (20)    NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC)
);

