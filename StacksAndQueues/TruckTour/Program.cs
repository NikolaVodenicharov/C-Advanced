using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Each array of the Queue will contain: int[0] - amount of petrol; int[1] - distance;
        var pumps = new Queue<int[]>();                      
        ReadFromConsoleAddToQueue(pumps);

        for (int pumpIndex = 0; pumpIndex < pumps.Count; pumpIndex++)
        // If we have 3 pumps, they will have index 0, 1 and 2.
        {
            var fuelInTruck = 0;
            bool isFuelEnough = true;
            for (int tripIndex = 0; tripIndex < pumps.Count - 1; tripIndex++)
            /* If we have 3 pumps we have to make 2 trips to stop to each petrol pump.
               Example: from indexPump 0 to indexPump 1. From indexPump 1 to indexPump 2. */
            {
                var pump = pumps.Dequeue();
                pumps.Enqueue(pump);
                fuelInTruck = CalculateFuelInTruck(fuelInTruck, pump);

                if (fuelInTruck < 0)
                {
                    /* We need to adjust pumpIndex. For example: if we made 2 trips, 
                       we are Dequeue and Enqueue 2 times, so pumpIndex must be corrected: 
                       + 1 from tripIndex and after that +1 from external For Loop*/
                    pumpIndex += tripIndex;  

                    isFuelEnough = false;
                    break;
                }
            }

            if (isFuelEnough)
            {
                Console.WriteLine(pumpIndex);
                break;
            }
        }
    }

    public static int CalculateFuelInTruck (int fuelInTruck, int[] arr)
    {
        // petrol = arr[0], distance = arr[1];
        fuelInTruck = fuelInTruck + (arr[0] - arr[1]);

        return fuelInTruck;
    }

    public static void ReadFromConsoleAddToQueue(Queue<int[]> pumps)
    {
        int numberOfInputLines = int.Parse(Console.ReadLine());

        // add each line
        for (int i = 0; i < numberOfInputLines; i++)
        {
            pumps.Enqueue(Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray());
        }
    }
}