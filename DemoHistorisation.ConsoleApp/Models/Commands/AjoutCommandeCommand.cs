using BStorm.Tools.CommandQuerySeparation.Commands;
using DemoHistorisation.ConsoleApp.Models.Entities;

namespace DemoHistorisation.ConsoleApp.Models.Commands
{
    internal class AjoutCommandeCommand : ICommandDefinition
    {
        public IEnumerable<Detail> Produits { get; }

        public AjoutCommandeCommand(IEnumerable<Detail> produits)
        {
            Produits = produits;
        }
    }
}
