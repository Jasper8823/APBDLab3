namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    public double Atmospheres { get; set; }

    public override void doEmpty()
    {
        Mass *=0.05;
    }

    public override void createSerNumber(int i)
    {
        SerNumber = "KON-G-" + i;
    }
}