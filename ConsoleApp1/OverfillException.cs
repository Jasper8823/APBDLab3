namespace ConsoleApp1;

public class OverfillException : Exception
{
    public OverfillException()
    {
        Console.WriteLine("Conteiner is overloaded");
    }
}