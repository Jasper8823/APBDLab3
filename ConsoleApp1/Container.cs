using System.ComponentModel;

namespace ConsoleApp1;

public abstract class Container : OverfillException
{
    public double Mass { get; set;}
    public double Height{ get; set;}
    public double Weight { get; set;}
    public double Depth{ get; set;}
    public string SerNumber { get; set;}
    public string type { get; set; }
    public double MaxPayload { get; set;}

    public virtual void doEmpty()
    {
        Mass = 0;
    }

    public virtual void createSerNumber(int i){}
    
    public virtual void takeCargo(double cargo)
    {
        if (MaxPayload < Mass + cargo) throw new OverfillException();
        else {
            Mass += cargo;
        }
    }
}