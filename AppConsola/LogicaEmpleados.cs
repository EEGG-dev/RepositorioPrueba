using AppConsola;

public static class LogicaEmpleado
{
    public static void RegistrarEmpleados(RepositorioEmpleado repositorioEmpleado, RepositorioDepartamento repositorioDepartamento)
    {
        Console.WriteLine("---- Registro Empleado ----");

        Console.Write("Ingrese el ID del empleado: ");
        string id = Console.ReadLine();

        Empleado empleado = repositorioEmpleado.Consultar().Find(e => e.Id == id);
        if (empleado == null)
        {
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el cargo del empleado: ");
            string cargo = Console.ReadLine();

            Console.Write("Ingrese la edad del empleado: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Departamentos disponibles: ");
            LogicaDepartamento.MostrarDepartamentos(repositorioDepartamento);

            Console.Write("Ingrese el ID del departamento al que pertenece: ");
            string depIdText = Console.ReadLine();

            int depId;
            if (!string.IsNullOrWhiteSpace(depIdText) && int.TryParse(depIdText, out depId))
            {
                Departamento departamentoSeleccionado = repositorioDepartamento.Consultar().Find(d => d.Id == depId);
                if (departamentoSeleccionado != null)
                {
                    Empleado empleadoRegistrado = new Empleado(id, nombre, cargo, edad, depId);
                    repositorioEmpleado.Agregar(empleadoRegistrado);

                    Console.WriteLine("Empleado registrado exitosamente...");
                }
                else
                {
                    Console.WriteLine("El ID del departamento especificado no existe.");
                }
            }else
            {
                Console.WriteLine("El ID del departamento especificado no es valido.");
            }
        }
        else
        {
            Console.WriteLine("Ya existe un empleado con el ID especificado.");
        }
    }

    public static void MostrarEmpleado(RepositorioEmpleado repositorioEmpleado)
    {
        Console.WriteLine("---- Lista Empleados ----");
        List<Empleado> empleados = repositorioEmpleado.Consultar();

        foreach (Empleado empleado in empleados)
        {
            Console.WriteLine($"ID: {empleado.Id} | Nombre: {empleado.Nombre} | Cargo: {empleado.Cargo} | Edad: {empleado.Edad} | Departamento ID: {empleado.DepartamentoId}");
        }
    }

    public static void EditarEmpleado(RepositorioEmpleado repositorioEmpleado, RepositorioDepartamento repositorioDepartamento)
    {
        Console.WriteLine("---- Editar Empleado ----");

        Console.WriteLine("Ingrese el ID del empleado que desea editar: ");
        string id = Console.ReadLine();

        Empleado empleado = repositorioEmpleado.Consultar().Find(e => e.Id == id);
        if (empleado != null)
        {
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el cargo del empleado: ");
            string cargo = Console.ReadLine();

            Console.Write("Ingrese la edad del empleado: ");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Departamentos Disponibles: ");
            LogicaDepartamento.MostrarDepartamentos(repositorioDepartamento);

            Console.WriteLine("Ingrese el ID del departamento al que pertenece el empleado (o presione ENTER para mantener el actual): ");
            string depIdText = Console.ReadLine();

            int depId;
            if (!string.IsNullOrWhiteSpace(depIdText) && int.TryParse(depIdText, out depId))
            {
                Departamento departamentoSeleccionado = repositorioDepartamento.Consultar().Find(d => d.Id == depId);
                if (departamentoSeleccionado != null)
                {
                    Empleado empleado1 = new Empleado(id, nombre, cargo, edad, depId);
                    repositorioEmpleado.Editar(empleado1, id, depId);
                    Console.WriteLine("Empleado editado exitosamente...");
                }
                else
                {
                    Console.WriteLine("El ID del departamento especificado no es valido.");
                }
            }
            else
            {
                Console.WriteLine("Empleado guardado con el departamento actual.");
                List<Empleado> empleados = repositorioEmpleado.Consultar();
                Empleado empleadoActual = empleados.Find(e => e.Id == id);
                if (empleadoActual != null)
                {
                    Empleado empleado2 = new Empleado(id, nombre, cargo, edad, empleadoActual.DepartamentoId);
                    repositorioEmpleado.Editar(empleado2, id, empleadoActual.DepartamentoId);
                    Console.WriteLine("Empleado guardado exitosamente...");
                }
            }
        }
        else
        {
            Console.WriteLine("No se encontro un empleado con el ID especificado.");
        }
    }

    public static void EliminarEmpleado(RepositorioEmpleado repositorioEmpleado)
    {
        Console.WriteLine("---- Eliminacion Empleados ----");
        Console.WriteLine("Ingrese el ID del empleado que desea eliminar: ");
        string id = Console.ReadLine();

        repositorioEmpleado.Eliminar(id);
        Console.WriteLine("Empleado eliminado exitosamente...");
    }
}