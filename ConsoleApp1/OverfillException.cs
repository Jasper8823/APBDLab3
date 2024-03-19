namespace ConsoleApp1;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }
    public OverfillException(string s)
    {
        Console.WriteLine("Container is overloaded");
    }
}