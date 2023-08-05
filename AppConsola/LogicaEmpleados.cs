using AppConsola;
public static class LogicaEmpleados
{
    public static void RegistrarEmpleado(RepositorioEmpleado repositorioEmpleado)
    {
        System.Console.WriteLine("----Registro de Empleado----");

        System.Console.Write("Ingrese el ID del empleado: ");
        string id = Console.ReadLine();

        System.Console.Write("Ingrese el nombre del empleado: ");
        string nombre = Console.ReadLine();

        System.Console.Write("Ingrese el cargo del empleado: ");
        string cargo = Console.ReadLine();

        System.Console.Write("Ingrese la edad del empleado: ");
        int edad = int.Parse(Console.ReadLine());

        System.Console.Write("Ingrese el Id del departamento: ");
        string depId = Console.ReadLine();

        Empleado empleado= new Empleado(id, nombre, cargo, edad, depId);
        repositorioEmpleado.Agregar(empleado);
          

        System.Console.WriteLine("Empleado guardado exitosamente...");
        Console.ReadKey();
        
    }

    public static void EliminarEmpleado(RepositorioEmpleado repositorioEmpleado)
    {
        System.Console.WriteLine("----Eliminacion de Empleado----");
        System.Console.WriteLine("Ingrese el Id del empleado: ");
        string Id = Console.ReadLine();

        repositorioEmpleado.Delete(Id);
        System.Console.WriteLine("Empleado eliminado exitosamente...");
        Console.ReadKey();
    }
}