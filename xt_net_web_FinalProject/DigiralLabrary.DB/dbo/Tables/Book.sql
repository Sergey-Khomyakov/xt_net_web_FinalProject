CREATE TABLE [dbo].[Book] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [BookFile] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC)
);

