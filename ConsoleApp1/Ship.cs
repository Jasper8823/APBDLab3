﻿namespace ConsoleApp1;

public class Ship
{
    public List<Container> containers;
    public int maxNumCon { get; set;}
    public double maxSpeed{ get; set;}
    public double maxWeight{ get; set;}
    public double curWeight { get; set;}
    public void addContainer(Container cont)
    {
        if (curWeight + cont.Weight + cont.Mass < maxWeight)
        {
            containers.Add(cont);
            curWeight += cont.Weight + cont.Mass;
        }
        else
        {
            Console.WriteLine("Max weight will be exceeded if you add this container");
        }
    }
    
    public void addContainerList(List<Container> conts)
    {
        double Sum = 0;
        foreach (Container cont in conts)
        {
            Sum += cont.Weight + cont.Mass;
        }
        if (curWeight + Sum < maxWeight)
        {
            foreach (Container cont in conts)
            {
                containers.Add(cont);
            }
            curWeight += Sum;
        }
        else
        {
            Console.WriteLine("Max weight will be exceeded if you add this containers");
        }
    }
}