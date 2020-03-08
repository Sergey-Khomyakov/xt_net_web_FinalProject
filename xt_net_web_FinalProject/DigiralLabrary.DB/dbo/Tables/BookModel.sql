CREATE TABLE [dbo].[BookModel] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Author]          NVARCHAR (50)   NOT NULL,
    [Pages]           INT             NOT NULL,
    [Image]           VARBINARY (MAX) NULL,
    [DateCreatedBook] DATETIME        NOT NULL,
    [Genre]           NVARCHAR (50)   NOT NULL,
    [Description]     NVARCHAR (MAX)  NOT NULL,
    [IdBook]          INT             NOT NULL,
    [Title]           NVARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_BookModel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BookModel_Book] FOREIGN KEY ([IdBook]) REFERENCES [dbo].[Book] ([Id])
);

