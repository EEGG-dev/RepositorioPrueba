using AppConsola;

public static class LogicaEmpleados
{
    public static void RegistrarEmpleado(RepositorioEmpleado repositorioEmpleado, RepositorioDepartamento repositorioDepartamento)
    {
        Console.WriteLine("----Registro de Empleado----");

        Console.Write("Ingrese el ID del empleado: ");
        string id = Console.ReadLine();

        Console.Write("Ingrese el nombre del empleado: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el cargo del empleado: ");
        string cargo = Console.ReadLine();

        Console.Write("Ingrese la edad del empleado: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Departamentos disponibles: ");
        LogicaDepartamento.MostrarDepartamentos(repositorioDepartamento);

        Console.Write("Ingrese el ID del departamento al que pertenece el empleado: ");
        string depIdText = Console.ReadLine();

        int depId;
        if (!string.IsNullOrWhiteSpace(depIdText) && int.TryParse(depIdText, out depId))
        {
            Departamento departamento = repositorioDepartamento.Consultar().Find(d => d.Id == depId);
            if(departamento != null)      
            {
                Empleado empleado = new Empleado(id, nombre, cargo, edad, depId);
                repositorioEmpleado.Agregar(empleado);
                System.Console.WriteLine("Empleado guardado exitosamente...");
            }
            else
            {
                Console.WriteLine("El ID del departamento especificado no es valido.");
            }
        }
    }

    public static void MostrarEmpleados(RepositorioEmpleado repositorioEmpleado)
    {
        Console.WriteLine("---- Lista de empleados ----");
        List<Empleado> empleados = repositorioEmpleado.Consultar();

         foreach (Empleado empleado in empleados)
        {
            Console.WriteLine($"ID: {empleado.Id} | Nombre: {empleado.Nombre} | Cargo: {empleado.Cargo} | Edad: {empleado.Edad} | Departamento ID: {empleado.DepartamentoId}");
        }
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

    public static void EditarEmpleado(RepositorioEmpleado repositorioEmpleado, RepositorioDepartamento repositorioDepartamento)
    {
        Console.WriteLine("---- Edicion de Empleados ----");

        Console.Write("Ingrese el ID del empleado que desea editar: ");
        string id = Console.ReadLine();

        Empleado empleado = repositorioEmpleado.Consultar().Find(d => d.Id == id);
        if (empleado != null)
        {
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el cargo del empleado: ");
            string cargo = Console.ReadLine();

            Console.Write("Ingrese la edad del empleado: ");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Departamentos disponibles: ");
            LogicaDepartamento.MostrarDepartamentos(repositorioDepartamento);

            Console.Write("Ingrese el ID del departamento al que pertenece el empleado (o presione ENTER para mantener el actual): ");
            string depIdText = Console.ReadLine();

            int depId;
            if(!string.IsNullOrWhiteSpace(depIdText) && int.TryParse(depIdText,out depId))
            {
                Departamento departamento = repositorioDepartamento.Consultar().Find(d => d.Id == depId);
                if (departamento != null)
                {
                    Empleado empleado1 = new Empleado(id, nombre, cargo, edad, depId);
                    repositorioEmpleado.Editar(empleado1, id, depId);
                    Console.WriteLine("Empleado guardado exitosamente...");
                }
                else
                {
                    Console.WriteLine("El ID de departamento especificado no es valido.");
                }
            }
            else
            {
                Console.WriteLine("Empleado guardado con el departamento actual");
            }
        }
        else
        {
            Console.WriteLine("No se encontro un empleado con el ID especificado.");
        }
    }
}