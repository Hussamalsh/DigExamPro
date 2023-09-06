CREATE TABLE [dbo].[Questions] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [ExamId]             INT             NOT NULL,
    [QuestionText]       NVARCHAR (1000) NOT NULL,
    [TypeId]             INT             NOT NULL,
    [CorrectOptionIndex] INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Questions_Exams] FOREIGN KEY ([ExamId]) REFERENCES [dbo].[Exams] ([Id]),
    CONSTRAINT [FK_Questions_QuestionType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[QuestionType] ([Id])
);

