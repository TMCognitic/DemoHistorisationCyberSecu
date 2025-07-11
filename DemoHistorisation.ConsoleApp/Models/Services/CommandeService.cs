using BStorm.Tools.CommandQuerySeparation.Results;
using BStorm.Tools.Database;
using DemoHistorisation.ConsoleApp.Models.Commands;
using DemoHistorisation.ConsoleApp.Models.Mappers;
using DemoHistorisation.ConsoleApp.Models.Repositories;
using System.Data.Common;

namespace DemoHistorisation.ConsoleApp.Models.Services
{
    internal class CommandeService : ICommandeRepository
    {
        private readonly DbConnection _dbConnection;

        public CommandeService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public ICommandResult Execute(AjoutCommandeCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("CSP_AjoutCommande", true, new { Produits = command.Produits.ToDataTable() });

                if (rows is 0)
                    return ICommandResult.Failure("Il y a quelque de pourri au royaume du Danemark...", null);

                return ICommandResult.Success();
            }
            catch (Exception ex)
            {
                return ICommandResult.Failure(ex.Message, ex);
            }
        }
    }
}
