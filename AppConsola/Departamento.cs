namespace AppConsola;

public class Departamento
{
    public string Id { get; set; }
    public string Nombre { get; set;}
    public string Cargo { get; set;}
    public int Edad { get; set;}
    public string DepartamentoId { get; set; }

    public Departamento(string id, string nombre, string cargo, int edad, string departamentoId)    
    {
        Id = id;
        Nombre = nombre;
        Cargo = cargo;
        Edad = edad;
        DepartamentoId = departamentoId;
    }


    }
