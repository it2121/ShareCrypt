CREATE TABLE [dbo].[OwnedFF] (
    [UserID]   INT NOT NULL,
    [FFID]     INT NOT NULL,
    [ParantID] INT NOT NULL,
    CONSTRAINT [FK_OwnedFF_FF] FOREIGN KEY ([FFID]) REFERENCES [dbo].[FF] ([FFID]),
    CONSTRAINT [FK_OwnedFF_FF1] FOREIGN KEY ([ParantID]) REFERENCES [dbo].[FF] ([FFID]),
    CONSTRAINT [FK_OwnedFF_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])
);

