CREATE TABLE [dbo].[RoleClaims] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [RoleId]     UNIQUEIDENTIFIER NOT NULL,
    [ClaimType]  NVARCHAR (256)   NULL,
    [ClaimValue] NVARCHAR (256)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleID]) ON DELETE CASCADE
);

