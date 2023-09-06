CREATE TABLE [dbo].[StudentExams] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [StudentId] INT        NOT NULL,
    [ExamId]    INT        NOT NULL,
    [DateTaken] DATETIME   DEFAULT (getdate()) NULL,
    [DateTimeCompleted] DATETIME,
    [Score]     FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ExamId]) REFERENCES [dbo].[Exams] ([Id]),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Users] ([Id])
);

