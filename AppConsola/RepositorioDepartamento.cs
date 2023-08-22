using System.Data.SqlClient;

namespace AppConsola;

public class RepositorioDepartamento
{
    public void agregar(string nombre)
    {
        using SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR);
        using SqlCommand comando = new SqlCommand("INSERT INTO Departamentos (Nombre) VALUES (@Nombre)", conexion);
        comando.Parameters.AddWithValue("@Nombre", nombre);
        conexion.Open();
        comando.ExecuteNonQuery();
        conexion.Close();
    }

    public List<Departamento> Consultar()
    {
        List<Departamento> departamentos = new List<Departamento>();
        using SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR);
        using SqlCommand comando = new SqlCommand("SELECT  * FROM Departamentos", conexion);
        conexion.Open();
        SqlDataReader lector =  comando.ExecuteReader();
        while(lector.Read())
        {
            int id = Convert.ToInt32(lector["Id"]);
            string nombre = lector["Nombre"].ToString();
            Departamento departamento = new Departamento(id, nombre);
            departamentos.Add(departamento);
        }
        lector.Close();
        conexion.Close();
        return departamentos;
    }

    public void Editar(Departamento departamento, int Id)
    {
        string query = "update Departamentos set nombre = @nombre where id = @id";

        using SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR);
        using SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@nombre", departamento.Nombre);
        comando.Parameters.AddWithValue("@id", Id);

        conexion.Open();
        comando.ExecuteNonQuery();
        conexion.Close();
    }

    public void Eliminar(int Id)
    {
        string query = "delete from Departamentos where id = @id";

        using (SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR))
        {
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", Id);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
  
}
