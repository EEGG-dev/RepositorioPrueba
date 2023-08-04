public class Departamentos()
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Departamentos(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}
