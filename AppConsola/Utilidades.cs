public static class Utilidades
{
    public static int ObtenerEntero(string message)
    {
        bool numeroValido;
        int salida;
        do
        {
            Console.Write(message);
            string numText = Console.ReadLine();
            numeroValido = int.TryParse(numText, out salida);
        } while(numeroValido == false);
        return salida;
    }
}