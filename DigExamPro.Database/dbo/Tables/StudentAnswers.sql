CREATE TABLE [dbo].[StudentAnswers] (
    [StudentAnswerID] UNIQUEIDENTIFIER NOT NULL,
    [StudentExamID]   UNIQUEIDENTIFIER NULL,
    [QuestionID]      UNIQUEIDENTIFIER NULL,
    [AnswerText]      NVARCHAR (MAX)   NOT NULL,
    [OptionID]        UNIQUEIDENTIFIER NULL,
    [IsCorrect]       BIT              NULL,
    PRIMARY KEY CLUSTERED ([StudentAnswerID] ASC),
    FOREIGN KEY ([OptionID]) REFERENCES [dbo].[Options] ([OptionID]),
    FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Questions] ([QuestionID]) ON DELETE CASCADE,
    FOREIGN KEY ([StudentExamID]) REFERENCES [dbo].[StudentExams] ([StudentExamID])
);

