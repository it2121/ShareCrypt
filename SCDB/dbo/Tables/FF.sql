CREATE TABLE [dbo].[FF] (
    [FFID]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50)   NULL,
    [Type]    NVARCHAR (50)   NULL,
    [Data]    VARBINARY (MAX) NULL,
    [OwnerID] INT             NULL,
    CONSTRAINT [PK_FilesAndFolders] PRIMARY KEY CLUSTERED ([FFID] ASC)
);

