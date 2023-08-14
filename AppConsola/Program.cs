using System.Data.SqlClient;
using AppConsola;

RepositorioDepartamento repositorioDepartamento = new RepositorioDepartamento();
RepositorioEmpleado repositorioEmpleado = new RepositorioEmpleado();

while (true)
{
    Console.WriteLine("----MENÚ----");
    Console.WriteLine("1. Registrar Departamento");
    Console.WriteLine("2. Eliminar Departamento");
    Console.WriteLine("3. Editar Departamento");
    Console.WriteLine("4. Mostrar lista de Departamentos");
    Console.WriteLine("5. Registrar Empleado");
    Console.WriteLine("6. Eliminar Empleado");
    Console.WriteLine("7. Editar Empleado");
    Console.WriteLine("8. Mostrar lista de Empleados");
    Console.WriteLine("9. Salir");
    Console.WriteLine("-------------");

    System.Console.WriteLine("Seleccione una opcion: ");
    string opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            LogicaDepartamento.RegistrarDepartamento(repositorioDepartamento);
            break;
        case "2":
            LogicaDepartamento.EliminarDepartamento(repositorioDepartamento);
            break;
        case "3":
            LogicaDepartamento.EditarDepartamento(repositorioDepartamento);
            break;
        case "4":
            LogicaDepartamento.MostrarDepartamentos(repositorioDepartamento);
            break;
        case "5":
            LogicaEmpleados.RegistrarEmpleado(repositorioEmpleado, repositorioDepartamento);
            break;
        case "6":
            LogicaEmpleados.EliminarEmpleado(repositorioEmpleado);
            break;
        case "7":
            LogicaEmpleados.EditarEmpleado(repositorioEmpleado, repositorioDepartamento);
            break;
        case "8":
            LogicaEmpleados.MostrarEmpleados(repositorioEmpleado);
            break;
        case "9":
            System.Console.WriteLine("Hasta Luego!");
            break;
        default:
            System.Console.WriteLine("Opcion invalida. Intente nuevamente.");
            break;
    }
    System.Console.WriteLine();
}