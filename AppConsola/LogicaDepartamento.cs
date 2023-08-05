
using AppConsola;
public static class LogicaDepartamento
{
    public static void RegistrarDepartamento(RepositorioDepartamento repositorioDepartamento)
    {
        Console.WriteLine("digite el departamento");
        string nombre = Console.ReadLine();
        repositorioDepartamento.agregar(nombre);
        Console.ReadKey();
    }

    public static void MostrarDepartamentos(RepositorioDepartamento repositorioDepartamento)
    {
        System.Console.WriteLine("----LISTA DE DEPARTAMENTOS----");
        List<Departamento> departamentos = repositorioDepartamento.Consultar();
        foreach (var departamento in departamentos)
        {
            Console.WriteLine($"Id: {departamento.Id}, Nombre: {departamento.Nombre}");
        }
    }

    public static void EditarDepartamento(RepositorioDepartamento repositorioDepartamento)
    {
        System.Console.WriteLine("---Edicion Departamento----");
        Console.WriteLine("Ingrese el ID del departamento que desea editar: ");
        int id = int.Parse(Console.ReadLine());

        Departamento departamento1 = repositorioDepartamento.Consultar().Find(c => c.Id == id);
        if (departamento1 != null)
        {
            System.Console.Write("Ingrese el nuevo nombre del departamento: ");
            string nombre1 = Console.ReadLine();

            departamento1.Nombre = nombre1;

            repositorioDepartamento.Editar(departamento1, id);

            System.Console.WriteLine("Departamento editado exitosamente...");

            Console.ReadKey();
        }
        else
        {
            System.Console.WriteLine("No se encontro un departamento con el id especificado");
            Console.ReadKey();
        }
    }

    public static void EliminarDepartamento(RepositorioDepartamento repositorioDepartamento)
    {
        System.Console.WriteLine("----ELIMINACION DE DEPARTAMENTO----");
        System.Console.WriteLine("Ingrese el ID del departamento que desea eliminar: ");
        int id = int.Parse(Console.ReadLine());

        repositorioDepartamento.Eliminar(id);
        System.Console.WriteLine("Departamento eliminado exitosamente");
    }
}