

using System.Data.SqlClient;
using AppConsola;

public class RepositorioEmpleado
{
    public void Agregar(Empleado empleado)
    {
        string query = "insert into Empleados (Id, Nombre, Cargo, Edad, DepartamentoId) values (@id, @nombre, @cargo, @departamentoId, @edad)";
        using SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR);
        using SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@id", empleado.Id);
        comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
        comando.Parameters.AddWithValue("@cargo", empleado.Cargo);
        comando.Parameters.AddWithValue("@departamentoId", empleado.DepartamentoId);
        comando.Parameters.AddWithValue("@edad", empleado.Edad);
        conexion.Open();
        comando.ExecuteNonQuery();
        conexion.Close();
    }

    public List<Empleado> Consultar()
    {
        List<Empleado> empleados = new List<Empleado>();
        string query = "select * from Empleados";
        using SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR);
        using SqlCommand comando = new SqlCommand(query, conexion);
        conexion.Open();
        SqlDataReader lector = comando.ExecuteReader();
        while(lector.Read())
        {
            string Id = lector.GetInt32(0).ToString();
            string Nombre = lector.GetString(1);
            string Cargo = lector.GetString(2);
            int Edad = lector.GetInt32(3);
            string DepartamentoId = lector.GetInt32(4).ToString();
            Empleado empleado = new Empleado(Id, Nombre, Cargo, Edad, DepartamentoId);
            empleados.Add(empleado);
        }        
        lector.Close(); 
        conexion.Close();
        return empleados;
    }

    public void Editar(Empleado empleado, string Id)
    {
        string query = "update Empleados set Nombre=@nombre, Cargo=@cargo, Edad=@edad, DepartamentoId=@departamentoid where id = @id";
        using SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR);
        using SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
        comando.Parameters.AddWithValue("@Cargo", empleado.Cargo);
        comando.Parameters.AddWithValue("@Edad", empleado.Edad);
        comando.Parameters.AddWithValue("@DepartamentoId",empleado.DepartamentoId );
        comando.Parameters.AddWithValue("@id", Id);

        conexion.Open();
        comando.ExecuteNonQuery();
        conexion.Close();

    }

    public void Delete(string Id)
    {
        string query = "delete from Empleados where id = @id";
        SqlConnection conexion = new SqlConnection(CadenaConexion.VALOR);
        SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@id", Id);

        conexion.Open();
        comando.ExecuteNonQuery();
        conexion.Close(); 
    }
}


