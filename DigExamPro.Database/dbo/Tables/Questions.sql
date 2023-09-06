CREATE TABLE [dbo].[Questions] (
    [QuestionID]         UNIQUEIDENTIFIER NOT NULL,
    [ExamID]             UNIQUEIDENTIFIER NULL,
    [QuestionType]       INT              NOT NULL,
    [QuestionText]       NVARCHAR (MAX)   NOT NULL,
    [Points]             INT              NULL,
    [CorrectOptionIndex] INT              NULL,
    PRIMARY KEY CLUSTERED ([QuestionID] ASC),
    FOREIGN KEY ([ExamID]) REFERENCES [dbo].[Exams] ([ExamID]) ON DELETE CASCADE,
    FOREIGN KEY ([QuestionType]) REFERENCES [dbo].[QuestionType] ([Id])
);

