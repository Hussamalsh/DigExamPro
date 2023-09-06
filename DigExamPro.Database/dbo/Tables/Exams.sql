CREATE TABLE [dbo].[Exams] (
    [ExamID]          UNIQUEIDENTIFIER NOT NULL,
    [Title]           NVARCHAR (512)   NOT NULL,
    [Description]     NVARCHAR (MAX)   NULL,
    [DateTimeCreated] DATETIME         DEFAULT (getdate()) NULL,
    [DateTimeUpdated] DATETIME         NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NOT NULL,
    [Duration]        INT              NULL,
    PRIMARY KEY CLUSTERED ([ExamID] ASC),
    FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([UserID])
);

