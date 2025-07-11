using BStorm.Tools.CommandQuerySeparation.Commands;
using DemoHistorisation.ConsoleApp.Models.Commands;

namespace DemoHistorisation.ConsoleApp.Models.Repositories
{
    internal interface ICommandeRepository :
        ICommandHandler<AjoutCommandeCommand>
    {
    }
}
