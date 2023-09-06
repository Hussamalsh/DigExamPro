CREATE TABLE [dbo].[Roles] (
    [RoleID]         UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (256)   NOT NULL,
    [NormalizedName] NVARCHAR (256)   NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

