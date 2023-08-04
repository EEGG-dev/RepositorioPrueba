// See https://aka.ms/new-console-template for more information
using AppConsola;

Console.WriteLine("Vamos a hacer unos cambios");
Console.WriteLine("Hola soy Hernando NUñez");
Console.WriteLine("Hola soy Anderson SanJuan");

RepositorioDepartamento repositorioDepartamento = new RepositorioDepartamento();
Console.WriteLine("digite el departamento");
string nombre = Console.ReadLine();
repositorioDepartamento.agregar(nombre);

List<Departamento> departamentos = repositorioDepartamento.Consultar();

foreach (var departamento in departamentos)
{
    Console.WriteLine($"Id: {departamento.Id}, Nombre: {departamento.Nombre}");
}
Console.ReadKey();