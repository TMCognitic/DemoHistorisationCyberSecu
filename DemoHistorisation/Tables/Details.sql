CREATE TABLE [dbo].[Details]
(
	ProduitId INT NOT NULL,
	CommandeId INT NOT NULL,
	Quantite INT NOT NULL,
	Prix FLOAT NOT NULL,
    CONSTRAINT [PK_Details] PRIMARY KEY ([CommandeId], [ProduitId]),
	CONSTRAINT [CK_Details_Prix] CHECK ([Prix] >= 0), 
    CONSTRAINT [FK_Details_Commande] FOREIGN KEY (CommandeId) REFERENCES Commande([Id]),
    CONSTRAINT [FK_Details_Produit] FOREIGN KEY (ProduitId) REFERENCES Produit([Id])
)
