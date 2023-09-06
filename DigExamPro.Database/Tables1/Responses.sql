CREATE TABLE [dbo].[Responses] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [StudentExamId] INT             NOT NULL,
    [QuestionId]    INT             NOT NULL,
    [Answer]        NVARCHAR (1000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Questions] ([Id]),
    FOREIGN KEY ([StudentExamId]) REFERENCES [dbo].[StudentExams] ([Id])
);

