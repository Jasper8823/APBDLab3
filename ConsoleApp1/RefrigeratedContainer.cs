namespace ConsoleApp1;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; set; }

    public void setProduct(Products p)
    {
        if (p.MinTemperature > Temperature)
        {
            Console.WriteLine("Temperature is too low for this product");
        }
        else
        {
            type = p.Type;
        }
    }
    public override void createSerNumber(int i)
    {
        SerNumber = "KON-R-" + i;
    }
}