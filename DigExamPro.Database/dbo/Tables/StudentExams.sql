CREATE TABLE [dbo].[StudentExams] (
    [StudentExamID]     UNIQUEIDENTIFIER NOT NULL,
    [UserID]            UNIQUEIDENTIFIER NULL,
    [ExamID]            UNIQUEIDENTIFIER NULL,
    [DateTimeStarted]   DATETIME         NULL,
    [DateTimeCompleted] DATETIME         NULL,
    [TotalScore]        INT              NULL,
    PRIMARY KEY CLUSTERED ([StudentExamID] ASC),
    FOREIGN KEY ([ExamID]) REFERENCES [dbo].[Exams] ([ExamID]) ON DELETE CASCADE,
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE
);

