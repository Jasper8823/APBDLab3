namespace ConsoleApp1;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; set; }

    public bool setProduct(Products p)
    {
        Console.WriteLine(p.MinTemperature+" "+Temperature);
        if (p.MinTemperature > Temperature)
        {
            Console.WriteLine("Temperature is too low for this product");
            return false;
        }else
        {
            type = p.Type;
            return true;
        }
    }
    public override void createSerNumber(int i)
    {
        SerNumber = "KON-R-" + i;
    }

    public override void getInfo()
    {
        Console.WriteLine();
        Console.WriteLine("Container serial number: "+SerNumber+" | cargo mass:"+Mass+" | height:"+Height);
        Console.WriteLine("   container weight: "+Weight+" | depth:"+Depth+" | maximal payload:"+MaxPayload);
        Console.WriteLine("   content of the container: "+type+" | container temperature: "+Temperature);
        Console.WriteLine();
    }
}