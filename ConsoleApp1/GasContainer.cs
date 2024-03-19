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
    public override void getInfo()
    {
        Console.WriteLine();
        Console.WriteLine("Container serial number: "+SerNumber+" | cargo mass:"+Mass+" | height:"+Height);
        Console.WriteLine("   container weight: "+Weight+" | depth:"+Depth+" | maximal payload:"+MaxPayload);
        Console.WriteLine("   content of the container: "+type+" | container atmospheres: "+Atmospheres);
        Console.WriteLine();
    }
}