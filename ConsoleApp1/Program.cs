using System.Xml;
using ConsoleApp1;

    List<Container> containers = new List<Container>();
List<Ship> ships = new List<Ship>();
List<Products> products = new List<Products>();
int choice=0,choice2=0;
String[] ins = new string[6];
while (choice!=12)
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
    Console.WriteLine("11. Create ship");
    Console.WriteLine("12. Exit");
    choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:{
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
                    LiquidContainer container1 = new LiquidContainer();
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
                    Console.WriteLine("What temperature will be in container");
                    double o = double.Parse(Console.ReadLine());
                    container2.Temperature = o;
                    Console.WriteLine("How do you want to add product");
                    while (choice2 != 1 && choice2 != 2)
                    {
                        Console.WriteLine("1. Add from existing products");
                        Console.WriteLine("2. Create new one");
                        choice2 = int.Parse(Console.ReadLine());
                    }

                    bool t1;
                    if (choice2 == 1&&products.Count>0)
                    {
                        for (int i = 0; i < products.Count; i++)
                        {
                            Console.WriteLine(i+1+" "+products[i]);
                        }
                        choice2 = int.Parse(Console.ReadLine());
                        t1=container2.setProduct(products[choice2]);
                    }
                    else
                    {
                        Products p = new Products();
                        Console.WriteLine("Insert name");
                        String line1;
                        double temper;
                        line1 = Console.ReadLine();
                        p.Type = line1;
                        Console.WriteLine("Insert minimal temperature");
                        temper = double.Parse(Console.ReadLine());
                        p.MinTemperature = temper;
                        products.Add(p);
                        t1=container2.setProduct(p);
                    }

                    if (t1)
                    {
                        container2.MaxPayload = double.Parse(ins[4]);
                        containers.Add(container2);
                    }else
                    {
                        Console.WriteLine("Creation failed");
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            break;
        }
        case 2:
            for(int i=0;i<containers.Count;i++){
                Console.WriteLine(i+1+". Container"+containers[i].SerNumber+" transports"+containers[i].type
                                  +" current weight:"+(containers[i].Weight+containers[i].Mass));
            }
            choice2 = int.Parse(Console.ReadLine());
            if (choice2 - 1 < 0 || choice2 - 1 > containers.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            double value;
            Console.WriteLine("How much do you want to load");
            value = double.Parse(Console.ReadLine());
            containers[choice2-1].takeCargo(value);
            break;
        case 3:
            for(int i=0;i<containers.Count;i++){
                Console.WriteLine(i+1+". Container: "+containers[i].SerNumber+" transports: "+containers[i].type
                                  +" current weight:"+(containers[i].Weight+containers[i].Mass));
            }
            choice2 = int.Parse(Console.ReadLine());
            if (choice2 - 1 < 0 || choice2 - 1 > containers.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            for(int i=0;i<ships.Count;i++){
                Console.WriteLine(i+1+". Ship max weight: "+ships[i].maxWeight+" current weight: "+ships[i].curWeight);
            }

            int value1;
            value1 = int.Parse(Console.ReadLine());
            if (value1 - 1 < 0 || value1 - 1 > ships.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            ships[value1-1].addContainer(containers[choice2-1]);
            break;
        case 4:
            List<Container> temp = new List<Container>();
            List<int> used = new List<int>();
            String line="YES";
            while (line.Equals("YES"))
            {
                Console.WriteLine("Do you want to add new container to the list? (YES/NO)");
                line = Console.ReadLine();
                if (line.Equals("YES"))
                {
                    for (int i = 0; i < containers.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". Container: " + containers[i].SerNumber + " transports: " +
                                          containers[i].type+" current weight:"+(containers[i].Weight+containers[i].Mass));
                    }

                    choice2 = int.Parse(Console.ReadLine());
                    if (choice2 - 1 < 0 || choice2 - 1 > containers.Count)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        if (used.Contains(choice2-1))
                        {
                            Console.WriteLine("This container is already in the list");    
                        }
                        else
                        {
                            temp.Add(containers[choice2-1]);
                            used.Add(choice2-1);
                        }
                    }
                }
            }
            for(int i=0;i<ships.Count;i++){
                Console.WriteLine(i+1+". Ship max weight: "+ships[i].maxWeight+" current weight: "+ships[i].curWeight);
            }
            value1 = int.Parse(Console.ReadLine());
            if (value1 - 1 < 0 || value1 - 1 > ships.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            ships[value1-1].addContainerList(temp);
            break;
        case 5:
            for(int i=0;i<ships.Count;i++){
                Console.WriteLine(i+1+". Ship max weight: "+ships[i].maxWeight+" current weight: "+ships[i].curWeight);
            }
            value1 = int.Parse(Console.ReadLine());
            if (value1 - 1 < 0 || value1 - 1 > ships.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            temp = ships[value1 - 1].containers;
            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(i + 1 + ". Container: " + temp[i].SerNumber + " transports: " +
                                  temp[i].type+" current weight:"+(containers[i].Weight+containers[i].Mass));
            }
            choice2 = int.Parse(Console.ReadLine());
            if (choice2 - 1 < 0 || choice2 - 1 > temp.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            ships[value1-1].removeContainer(choice2-1);
            break;
        case 6:
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine(i + 1 + ". Container: " + containers[i].SerNumber + " transports: " +
                                  containers[i].type+" current weight:"+(containers[i].Weight+containers[i].Mass));
            }

            choice2 = int.Parse(Console.ReadLine());
            if (choice2 - 1 < 0 || choice2 - 1 > containers.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            containers[choice2-1].doEmpty();
            break;
        case 7:
            Console.WriteLine("Write serial number of the container");
            line = Console.ReadLine();
            bool t = false;
            int value2=0;
            for (int i = 0; i < containers.Count; i++)
            {
                if (containers[i].SerNumber.Equals(line))
                {
                    t = true;
                    value2 = i;
                }
            }

            if(t)
            {
                Console.WriteLine("Container found");
                for(int i=0;i<ships.Count;i++){
                    Console.WriteLine(i+1+". Ship max weight: "+ships[i].maxWeight+" current weight: "+ships[i].curWeight);
                }
                value1 = int.Parse(Console.ReadLine());
                if (value1 - 1 < 0 || value1 - 1 > ships.Count)
                {
                    Console.WriteLine("Error");
                    break;
                }
                Console.WriteLine("Which one do you want to replace");
                temp = ships[value1 - 1].containers;
                for (int i = 0; i < temp.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". Container: " + temp[i].SerNumber + " transports: " +
                                      temp[i].type+" current weight:"+(containers[i].Weight+containers[i].Mass));
                }
                choice2 = int.Parse(Console.ReadLine());
                if (choice2 - 1 < 0 || choice2 - 1 > temp.Count)
                {
                    Console.WriteLine("Error");
                    break;
                }
                ships[value1-1].removeContainer(choice2-1);
                ships[value1-1].addContainer(containers[value2]);
            }
            else
            {
                Console.WriteLine("No container found");
            }
            break;
        case 8:
            Console.WriteLine("Choose first ship");
            for(int i=0;i<ships.Count;i++){
                Console.WriteLine(i+1+". Ship max weight: "+ships[i].maxWeight+" current weight: "+ships[i].curWeight);
            }
            value1 = int.Parse(Console.ReadLine());
            if (value1 - 1 < 0 || value1 - 1 > ships.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            int value3;
            Console.WriteLine("Choose second ship");
            for(int i=0;i<ships.Count;i++){
                Console.WriteLine(i+1+". Ship max weight: "+ships[i].maxWeight+" current weight: "+ships[i].curWeight);
            }
            value3 = int.Parse(Console.ReadLine());
            if (value3 - 1 < 0 || value3 - 1 > ships.Count)
            {
                Console.WriteLine("Error");
                break;
            }

            if (value1 == value3)
            {
                Console.WriteLine("You cannot transfer to the same ship");
                break;
            }
            Console.WriteLine("Which one do you want to replace");
            temp = ships[value1 - 1].containers;
            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(i + 1 + ". Container: " + temp[i].SerNumber + " transports: " +
                                  temp[i].type+" current weight:"+(containers[i].Weight+containers[i].Mass));
            }
            choice2 = int.Parse(Console.ReadLine());
            if (choice2 - 1 < 0 || choice2 - 1 > temp.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            ships[value3-1].addContainer(ships[value1-1].containers[choice2-1]);
            ships[value1-1].removeContainer(value1-1);
            break;
        case 9:
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine(i + 1 + ". Container: " + containers[i].SerNumber + " transports: " +
                                  containers[i].type+" current weight:"+(containers[i].Weight+containers[i].Mass));
            }

            choice2 = int.Parse(Console.ReadLine());
            if (choice2 - 1 < 0 || choice2 - 1 > containers.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            containers[choice2-1].getInfo();
            break;
        case 10:
            for(int i=0;i<ships.Count;i++){
                Console.WriteLine(i+1+". Ship max weight: "+ships[i].maxWeight+" current weight: "+ships[i].curWeight);
            }
            value1 = int.Parse(Console.ReadLine());
            if (value1 - 1 < 0 || value1 - 1 > ships.Count)
            {
                Console.WriteLine("Error");
                break;
            }
            ships[value1 - 1].getInfo();
            break;
        case 11:
            Ship ship = new Ship();
            ship.containers = new List<Container>();
            Console.WriteLine("Insert max number of containers");
            value1 = int.Parse(Console.ReadLine());
            ship.maxNumCon = value1;
            Console.WriteLine("Insert max weight");
            value = double.Parse(Console.ReadLine());
            ship.maxWeight = value;
            Console.WriteLine("Insert max speed");
            value = double.Parse(Console.ReadLine());
            ship.maxSpeed = value;
            ships.Add(ship);
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
    if (!type.Equals("R"))
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
