// See https://aka.ms/new-console-template for more information


using BStorm.Tools.CommandQuerySeparation.Results;
using DemoHistorisation.ConsoleApp.Models.Commands;
using DemoHistorisation.ConsoleApp.Models.Entities;
using DemoHistorisation.ConsoleApp.Models.Repositories;
using DemoHistorisation.ConsoleApp.Models.Services;
using Microsoft.Data.SqlClient;
using System.Data.Common;

using (DbConnection dbConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoHistorisation;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
{
    ICommandeRepository commandeRepository = new CommandeService(dbConnection);

    ICommandResult commandResult = commandeRepository.Execute(new AjoutCommandeCommand(new List<Detail>()
    {
        new Detail(1, 1, .9),
        new Detail(2, 1, 1),
    }));

    if(commandResult.IsFailure)
    {
        Console.WriteLine(commandResult.ErrorMessage);
        return;
    }

    Console.WriteLine("Commande Ajoutée...");
}
