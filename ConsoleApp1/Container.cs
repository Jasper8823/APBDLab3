using System.ComponentModel;

namespace ConsoleApp1;

public abstract class Container : OverfillException
{
    public double Mass { get; set;}
    public double Height{ get; set;}
    public double Weight { get; set;}
    public double Depth{ get; set;}
    public string SerNumber { get; set;}
    public double MaxLodout { get; set;}

    protected Container(double m, double h, double w, double d, string sN, double mL)
    {
        Mass = m;
        Height = h;
        Weight = w;
        Depth = d;
        SerNumber = sN;
        MaxLodout = mL;
    }

    public void doEmpty()
    {
        Mass = 0;
    }

    public void takeCargo(double cargo)
    {
        if (MaxLodout < Mass + cargo) throw new OverfillException();
        else Mass += cargo;
    }
}