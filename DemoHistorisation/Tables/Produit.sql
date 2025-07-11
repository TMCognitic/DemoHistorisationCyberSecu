CREATE TABLE [dbo].[Produit]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(128) NOT NULL, 
    [Prix] FLOAT NOT NULL, 
    CONSTRAINT [PK_Produit] PRIMARY KEY ([Id]) 
)

GO

CREATE TRIGGER [dbo].[TR_Produit_OnInsert]
    ON [dbo].[Produit]
    AFTER INSERT
    AS
    BEGIN
        SET NoCount ON

        DECLARE @Now DATETIME2 = SYSDATETIME();

        INSERT INTO ProduitHistory (ProduitId, Nom, Prix, [From], [To])
        SELECT Id, Nom, Prix, @Now, NULL
        FROM inserted
    END

GO

CREATE TRIGGER [dbo].[TR_Produit_OnUpdate]
    ON [dbo].[Produit]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON

        DECLARE @Now DATETIME2 = SYSDATETIME();

        UPDATE ProduitHistory 
        SET [To] = @Now 
        WHERE ProduitId IN (SELECT Id FROM deleted) AND [To] IS NULL;

        INSERT INTO ProduitHistory (ProduitId, Nom, Prix, [From], [To])
        SELECT Id, Nom, Prix, @Now, NULL
        FROM inserted
    END
GO

CREATE TRIGGER [dbo].[TR_Produit_OnDelete]
    ON [dbo].[Produit]
    AFTER DELETE
    AS
    BEGIN
        SET NoCount ON

        DECLARE @Now DATETIME2 = SYSDATETIME();

        UPDATE ProduitHistory 
        SET [To] = @Now 
        WHERE ProduitId IN (SELECT Id FROM deleted) AND [To] IS NULL;
    END