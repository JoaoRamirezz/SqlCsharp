using System;
using System.Data;
using System.Data.SqlClient;

public class Login
{

    public void Run()
    {
        SqlConnectionStringBuilder stringConnectionBuilder = new SqlConnectionStringBuilder();
        stringConnectionBuilder.DataSource = @"CT-C-0013E\SQLEXPRESS01";
        stringConnectionBuilder.InitialCatalog = "example";
        stringConnectionBuilder.IntegratedSecurity = true;
        string stringConnection = stringConnectionBuilder.ConnectionString;
        SqlConnection conn = new SqlConnection(stringConnection);
        conn.Open();
        string nome = Console.ReadLine();
        string senha = Console.ReadLine();
        SqlCommand comm = new SqlCommand($"select * from Cliente where Nome = '{nome}' and Senha = '{senha}'");
        comm.Connection = conn;
        var reader = comm.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        if (dt.Rows.Count > 0)
            Console.WriteLine($"Usuário {dt.Rows[0].ItemArray[0]} Logado");
        else
            Console.WriteLine("Conta inexistente");
        conn.Close();
    }
}