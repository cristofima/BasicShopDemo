using Microsoft.Data.SqlClient;
using System;

namespace BasicShopDemo.Api.Exceptions
{
    /// <summary>
    /// Class for manage SQL Server errors.
    /// For more information, visit: https://docs.microsoft.com/en-us/sql/relational-databases/errors-events/database-engine-events-and-errors?view=sql-server-ver15
    /// <see></see>
    public class CustomSQLServerException
    {
        public string ShowSQLServerError(SqlException sqlServerError, string actualTable, string sourceClass)
        {
            var initMessage = "Internal error in the database. Try again, if the error continues, please contact the system staff and inform them about the error." +
                    Environment.NewLine + Environment.NewLine
                    + "(" + sqlServerError.Message.ToString() + ") in "
                    + sqlServerError.Source.ToString();

            try
            {
                switch (sqlServerError.Number)
                {
                    case 300:
                        initMessage = "The user does not have permission to perform this action.";
                        break;
                    case 547:
                        string[] cadena = sqlServerError.Message.ToString().Split(Convert.ToChar(" "));

                        var table = cadena[16];
                        var constraint = cadena[8];

                        constraint = constraint.Replace(".", "");
                        table = table.Replace(",", "");
                        table = table.Replace("dbo.", "");

                        initMessage = $"It is not possible to delete or update in {actualTable}, due to the constraint {constraint} in the table {table}.";
                        break;

                    default:
                        break;
                }
                return initMessage;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
