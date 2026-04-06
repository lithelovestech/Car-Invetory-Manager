using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Practical5
{
    internal class Program
    {
        const int SIZE = 10;
        static void Main(string[] args)
        {
            Car[] carList = new Car [SIZE];
            int nrCars= 0;

            ReadData(carList, ref nrCars);

            int choice;
            do
            {
                choice = DisplayOptions();

                switch (choice)
                {
                    case 1:
                        AddCar(carList, ref nrCars);
                        WriteData(carList, nrCars);
                        break;

                    case 2:
                        SortSelling(carList, nrCars);
                        break;

                    case 3:
                        DisplayAvailable(carList, nrCars);
                        break;

                    case 4:
                        DisplayCheap(carList, nrCars);
                        break;

                    case 5:
                        DisplayAll(carList, nrCars);
                        break;

                    case 6:
                        WriteLine("Exiting program. Goodbye!");
                        break;

                    default:
                        WriteLine("Invalid choice. Please try again.");
                        break;
                }

                WriteLine();

            } while (choice != 6);
        }
        public static int DisplayOptions()
        {
            int choice;
            do
            {
                WriteLine("Indicate your choice from the following options, 6 to quit.");
                WriteLine("1. Add a car to the list");
                WriteLine("2. Sort list on selling price, then display list");
                WriteLine("3. Display the registration numbers and prices for all available cars.");
                WriteLine("4. Display the regitration numbers and prices for all cars selling for less that R50 000");
                WriteLine("5. Display all the fields for all the cars.");
                WriteLine("6. Quit");
                Write("Choice: ");
                choice = int.Parse(ReadLine());
                WriteLine();

                if (choice < 1 || choice > 6)
                {
                    WriteLine("Invalid entry");
                }

            } while (choice < 1 || choice > 6);
          
                return choice;
        }
        public static void ReadData(Car[] carlist, ref int nrCars)
        {
            const char DELIM = ',';
            String inputLine;
            String[] cars;
            String rgNr;
            String carModel;
            int carYear;
            String carColour;
            double carPrice;
            String carStatus;
            StreamReader sr = new StreamReader("carData.txt");
            inputLine = sr.ReadLine();

            while(inputLine != null)
            {
                cars = inputLine.Split(DELIM);

                if (cars.Length == 6)
                {
                    rgNr = cars[0];
                    carModel = cars[1];
                    carYear = int.Parse(cars[2]);
                    carColour = cars[3];
                    carPrice = double.Parse(cars[4]);
                    carStatus = cars[5];

                    carlist[nrCars] = new Car(rgNr, carModel, carYear, carColour, carPrice, carStatus);
                    nrCars++;
                }

                inputLine = sr.ReadLine();

            }
            sr.Close();
        }
        public static void AddCar(Car[] carList, ref int nrCars)
        {
            if (nrCars >= carList.Length)
            {
                WriteLine("Unfourtunately, the list is full");
            }
            else
            {
                WriteLine("Enter RegNr: ");
                string name = ReadLine();
                WriteLine("Enter Model: ");
                string model = ReadLine();
                WriteLine("Enter Year: ");
                int year = int.Parse(ReadLine());
                WriteLine("Enter Coulour: ");
                string colour = ReadLine();
                WriteLine("Enter Price: ");
                double price = double.Parse(ReadLine());

                carList[nrCars] = new Car(name, model, year, colour, price);
                nrCars++;
            }
        }
        public static void SortSelling(Car[] carList, int nrCars)
        {
            if (nrCars == 0)
            {
                WriteLine("The car list is empty.");
                return;
            }

            Array.Sort(carList, 0, nrCars);
            WriteLine("List sorted on selling price:");

            for (int i =0;  i < nrCars; i++)
            {
                carList[i].DisplayDetailCar();
            }
        }
        public static void DisplayAvailable(Car[] carList, int nrCars)
        {
            if (nrCars == 0)
            {
                WriteLine("The car list is empty.");
                return;
            }
            WriteLine("List of all available cars: ");

            for (int i = 0; i < nrCars; i++)
            {
                if (carList[i].GetStatus() == "available") 
                {
                    carList[i].DisplayCar();
                }
            }

        }
        public static void DisplayCheap(Car[] carList, int nrCars)
        {
            if (nrCars == 0)
            {
              WriteLine("The car list is empty.");
              return;
            }

            WriteLine("List of all cars selling for less than R50 000:");

            for (int i = 0; i < nrCars; i++)
            {
                if (carList[i].IsCheap())
                {
                    carList[i].DisplayCar();
                }
            }
        }
        public static void DisplayAll(Car[] carList, int nrCars)
        {
            if (nrCars == 0)
            {
                WriteLine("The car list is empty.");
                return;
            }

            WriteLine("List of all cars:");

            for (int i = 0; i < nrCars; i++)
            {
                carList[i].DisplayDetailCar();
            }
        }
        public static void WriteData(Car[] carList, int nrCars)
        {
            StreamWriter sw = new StreamWriter("carData.txt");

            for (int i = 0; i < nrCars; i++)
            {

                sw.Write(carList[i].GetRegNr() + ",");
                sw.Write(carList[i].GetModel() + ",");
                sw.Write(carList[i].GetYear() + ",");
                sw.Write(carList[i].GetColour() + ",");
                sw.Write(carList[i].GetPrice() + ",");
                sw.WriteLine(carList[i].GetStatus());   
        
            }

            sw.Close();
            WriteLine("The car was added to the list.");
        }

    }
}
