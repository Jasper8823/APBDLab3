namespace ConsoleApp1;

public interface IHazardNotifier
{
    public void Hazard(string sNumber)
    {
        Console.WriteLine("Warning container isn't stable "+sNumber);
    }
}