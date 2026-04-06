using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical5
{
    internal class Car : IComparable
    {
        String regNr, model, colour, status;
        int year;
        double price;
        
        public Car(string regNr, string model, int year, string colour, double price, string status)
        {
            this.regNr = regNr.ToUpper();
            this.model = model;
            this.colour = colour;
            this.status = status.ToLower();
            this.year = year;
            this.price = price;
        }
        public Car(string regNr, string model, int year,string colour, double price)
        {
            this.regNr = regNr;
            this.model = model;
            this.colour = colour;
            this.year= year;
            this.price= price;
            this.status = "available";
        }
        public String GetRegNr()
        {
            return regNr;
        }
        public String GetModel()
        {
            return model;
        }
        public String GetColour()
        {
            return colour;
        }
        public double GetPrice()
        {
            return price;
        }
        public int GetYear()
        {
            return year;
        }
        public String GetStatus()
        {
            return status;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public void SetStatus(String status)
        {
            this.status = status;
        }
        public bool IsCheap()
        {
            if (price < 50000.0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void DisplayCar()
        {
            Console.WriteLine("Reg Nr {0}; Price {1:C}",regNr,price);
        }
        public void DisplayDetailCar()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4:C}, {5}", regNr, model, year, colour, price, status);
        }
        int IComparable.CompareTo(Object obj)
        {
            Car temp = (Car)obj;
            return this.price.CompareTo(temp.price);
        }

            
    }
}
