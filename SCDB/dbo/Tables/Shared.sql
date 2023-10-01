CREATE TABLE [dbo].[Shared] (
    [OwnerID]    INT NOT NULL,
    [SharedToID] INT NOT NULL,
    [Status]     INT NOT NULL,
    [FFID]       INT NOT NULL,
    [ParantID]   INT NOT NULL,
    CONSTRAINT [FK_Shared_FF] FOREIGN KEY ([ParantID]) REFERENCES [dbo].[FF] ([FFID]),
    CONSTRAINT [FK_Shared_FF1] FOREIGN KEY ([FFID]) REFERENCES [dbo].[FF] ([FFID]),
    CONSTRAINT [FK_Shared_Users] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[Users] ([ID]),
    CONSTRAINT [FK_Shared_Users1] FOREIGN KEY ([SharedToID]) REFERENCES [dbo].[Users] ([ID])
);

