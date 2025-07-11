CREATE PROCEDURE [dbo].[CSP_AjoutCommande]
	@Produits CT_Detail READONLY
AS
BEGIN
	BEGIN TRANSACTION AjoutCommande

	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM @Produits)
		BEGIN
			RAISERROR ('Aucun produit définit', 16, 1);
		END


		INSERT INTO Commande ([Date]) VALUES (DEFAULT);
		DECLARE @CommandeId INT = SCOPE_IDENTITY();

		INSERT INTO Details ([CommandeId], [ProduitId], [Quantite], [Prix])
		SELECT @CommandeId, ProduitId, Quantite, Prix
		FROM @Produits;
		
		COMMIT TRANSACTION AjoutCommande
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE(),
				@ErrorSeverity INT = ERROR_SEVERITY(),
				@ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
		ROLLBACK TRANSACTION AjoutCommande
	END CATCH
END
