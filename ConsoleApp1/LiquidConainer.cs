﻿namespace ConsoleApp1;

public class LiquidConainer : Container, IHazardNotifier
{
    public bool isHazard { get; set;}
    
    public override void takeCargo(double cargo)
    {
        if (MaxPayload > Mass + cargo)
        {
            if (isHazard)
            {
                if (MaxPayload / 0.5 < Mass + cargo)
                {
                    Console.WriteLine(
                        "You are trying to fill container more than expected, it can cause unexpected situations");
                    Console.WriteLine("Do you want to continue? (YES/NO)");
                    string userInput = Console.ReadLine();
                    if (userInput.Equals("YES"))
                    {
                        Mass += cargo;
                    }
                }
                else
                {
                    Mass += cargo;
                }
            }
            else
            {
                if (MaxPayload / 0.9 < Mass + cargo)
                {
                    Console.WriteLine(
                        "You are trying to fill container more than expected, it can cause unexpected situations");
                    Console.WriteLine("Do you want to continue? (YES/NO)");
                    string userInput = Console.ReadLine();
                    if (userInput.Equals("YES"))
                    {
                        Mass += cargo;
                    }
                }
                else
                {
                    Mass += cargo;
                }
            }
        }
        else throw new OverfillException();
    }
    public override void createSerNumber(int i)
    {
        SerNumber = "KON-L-" + i;
    }
}
