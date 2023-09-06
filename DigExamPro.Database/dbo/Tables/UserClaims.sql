CREATE TABLE [dbo].[UserClaims] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [ClaimType]  NVARCHAR (256)   NULL,
    [ClaimValue] NVARCHAR (256)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE
);

