CREATE TABLE [dbo].[Options] (
    [OptionID]   UNIQUEIDENTIFIER NOT NULL,
    [QuestionID] UNIQUEIDENTIFIER NULL,
    [OptionText] NVARCHAR (512)   NULL,
    [IsCorrect]  BIT              NULL,
    PRIMARY KEY CLUSTERED ([OptionID] ASC),
    FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Questions] ([QuestionID]) ON DELETE CASCADE
);

