using DemoHistorisation.ConsoleApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHistorisation.ConsoleApp.Models.Mappers
{
    internal static class Mappers
    {
        internal static DataTable ToDataTable(this IEnumerable<Detail> details)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProduitId", typeof(int));
            dt.Columns.Add("Quantite", typeof(int));
            dt.Columns.Add("Prix", typeof(double));

            foreach (Detail detail in details)
            {
                dt.Rows.Add(detail.ProduitId, detail.Quantite, detail.Prix);
            }
            return dt;
        }
    }
}
