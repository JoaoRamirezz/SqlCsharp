using System.Data.SqlClient;

public class UserSubscribe
{
    public void Run(string nome, string senha, string data)
    {
        SqlConnectionStringBuilder stringConnectionBuilder = new SqlConnectionStringBuilder();
        stringConnectionBuilder.DataSource = @"CT-C-0013E\SQLEXPRESS01"; // Nome do servidor
        stringConnectionBuilder.InitialCatalog = "example"; // Nome do banco
        stringConnectionBuilder.IntegratedSecurity = true;
        string stringConnection = stringConnectionBuilder.ConnectionString;
        SqlConnection conn = new SqlConnection(stringConnection);
        conn.Open();


        SqlCommand comm = new SqlCommand($"insert Cliente values ('{nome}', '{senha}', CONVERT(DATETIME, '{data}'));");
        comm.Connection = conn;
        comm.ExecuteNonQuery();
        conn.Close();
    }
}