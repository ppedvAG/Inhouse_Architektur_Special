// See https://aka.ms/new-console-template for more information
using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

Console.WriteLine("Hello, Factory!");

string conStringSQL = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";

string conStringlite = @"Data Source=C:\DB\Northwind.sqlite";

DbProviderFactory factory = null;
string conString = "";

if (1 != 1)
{
    factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
    conString = conStringSQL;
}
else
{
    factory = Microsoft.Data.Sqlite.SqliteFactory.Instance;
    conString = conStringlite;
}


DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();
Console.WriteLine("DB open");

DbCommand sqlCommand = factory.CreateCommand();
sqlCommand.Connection = con;
sqlCommand.CommandText = "SELECT COUNT(*) FROM Employees";

var rowCount = sqlCommand.ExecuteScalar();
Console.WriteLine($"{rowCount} Employees in DB");