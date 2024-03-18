using ConsoleApp1;

List<Container> containers = new List<Container>();
List<Ship> ships = new List<Ship>();
List<Products> products = new List<Products>();
int choice=0,choice2=0;
String[] ins = new string[6];
while (choice!=11)
{
    Console.WriteLine("1. Create a container");
    Console.WriteLine("2. Load cargo into a given container");
    Console.WriteLine("3. Load a container onto a ship");
    Console.WriteLine("4. Load a list of containers onto a ship");
    Console.WriteLine("5. Remove a container from the ship");
    Console.WriteLine("6. Unload a container");
    Console.WriteLine("7. Replace a container on the ship with a given number with another container");
    Console.WriteLine("8. Transfer container to another ship");
    Console.WriteLine("9. Print information about a given container");
    Console.WriteLine("10. Print information about a given ship and its cargo");
    Console.WriteLine("11. Exit");
    choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.WriteLine("Which type of container");
            Console.WriteLine("1. Gas");
            Console.WriteLine("2. Liquid");
            Console.WriteLine("3. Refrigerated");
            choice2 = int.Parse(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    GasContainer container = new GasContainer();
                    ins = createContainer("G");
                    container.Height = double.Parse(ins[0]);
                    container.Weight = double.Parse(ins[1]);
                    container.Depth = double.Parse(ins[2]);
                    container.createSerNumber(containers.Count+1);
                    container.type = ins[3];
                    container.MaxPayload = double.Parse(ins[4]);
                    container.Atmospheres = double.Parse(ins[5]);
                    containers.Add(container);
                    break;
                case 2:
                    LiquidConainer container1 = new LiquidConainer();
                    ins = createContainer("L");
                    container1.Height = double.Parse(ins[0]);
                    container1.Weight = double.Parse(ins[1]);
                    container1.Depth = double.Parse(ins[2]);
                    container1.createSerNumber(containers.Count+1);
                    container1.type = ins[3];
                    container1.MaxPayload = double.Parse(ins[4]);
                    if (ins[5].Equals("t"))
                    {
                        container1.isHazard = true;
                    }
                    else
                    {
                        container1.isHazard = false;
                    }
                    containers.Add(container1);
                    break;
                case 3:
                    RefrigeratedContainer container2 = new RefrigeratedContainer();
                    ins = createContainer("R");
                    container2.Height = double.Parse(ins[0]);
                    container2.Weight = double.Parse(ins[1]);
                    container2.Depth = double.Parse(ins[2]);
                    container2.createSerNumber(containers.Count+1);
                    Console.WriteLine("How do you want to add prodact");
                    while (choice2 != 1 && choice2 != 2)
                    {
                        Console.WriteLine("1. Add from existing products");
                        Console.WriteLine("2. Create new one");
                        choice2 = int.Parse(Console.ReadLine());
                    }

                    if (choice2 == 1)
                    {
                        for (int i = 0; i < products.Count; i++)
                        {
                            Console.WriteLine(i+1+" "+products[i]);
                        }
                        choice2 = int.Parse(Console.ReadLine());
                        container2.setProduct(products[choice2]);
                    }
                    container2.MaxPayload = double.Parse(ins[4]);
                    containers.Add(container2);
                    break;
                default:
                    Console.WriteLine("Eror");
                    break;
            }
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
            break;
        case 7:
            break;
        case 8:
            break;
        case 9:
            break;
        case 10:
            break;
    }
}


String[] createContainer(String type)
{
    String[] inserts = new string[6];
    String line;
    int choice2;
    Console.WriteLine("Insert height");
    line = Console.ReadLine();
    inserts[0] = line;
    Console.WriteLine("Insert weight");
    line = Console.ReadLine();
    inserts[1] = line;
    Console.WriteLine("Insert depth");
    line = Console.ReadLine();
    inserts[2] = line;
    if (type.Equals("R"))
    {
        Console.WriteLine("Do you want to");
        Console.WriteLine("1. Add from existing products");
        Console.WriteLine("2. Create new one");
        choice2 = int.Parse(Console.ReadLine());
        while (choice2 != 1 && choice2 != 2)
        {
            Console.WriteLine("1. Add from existing products");
            Console.WriteLine("2. Create new one");
            choice2 = int.Parse(Console.ReadLine());
        }

    }
    else
    {
        Console.WriteLine("Insert type");
        line = Console.ReadLine();
        inserts[3] = line;
    }
    Console.WriteLine("Insert max payload");
    line = Console.ReadLine();
    inserts[4] = line;
    if (type.Equals("G"))
    {
        Console.WriteLine("Insert atmospheres");
        line = Console.ReadLine();
        inserts[5] = line;
    }else if (type.Equals("L"))
    {
        Console.WriteLine("Is it hazard (YES/NO)");
        line = Console.ReadLine();
        if (line.Equals("YES"))
        {
            inserts[5] = "t";
        }
        else
        {
            inserts[5] = "f";
        }
    }
    return inserts;
}
