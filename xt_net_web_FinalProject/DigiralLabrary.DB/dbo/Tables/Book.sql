CREATE TABLE [dbo].[Book] (
    [BookId]   INT             IDENTITY (1, 1) NOT NULL,
    [BookFile] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookId] ASC)
);

