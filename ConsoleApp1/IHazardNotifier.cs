namespace ConsoleApp1;

public interface IHazardNotifier
{
    public void Hazard()
    {
        Console.WriteLine("Warning container isn't stable");
    }
}