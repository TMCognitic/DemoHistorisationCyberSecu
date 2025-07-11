CREATE TABLE [dbo].[ProduitHistory]
(
	[HistoryId] INT NOT NULL IDENTITY,
	[ProduitId] INT NOT NULL,
	[Nom] NVARCHAR(18) NOT NULL,
	[Prix] FLOAT NOT NULL,
	[From] DATETIME2 NOT NULL,
	[To] DATETIME2 NULL, 
    CONSTRAINT [PK_ProduitHistory] PRIMARY KEY ([HistoryId]),
);

GO

CREATE INDEX [IX_ProduitHistory_ProduitId] ON [dbo].[ProduitHistory] ([ProduitId])
