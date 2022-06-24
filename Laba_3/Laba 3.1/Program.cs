using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    ///Реалізувати клас, що моделює роботу N-містної автостоянки. 
    ///Машина під'їжджає до певного місця і їде вниз, поки не зустрінеться вільне місце. 
    ///Клас повинен підтримувати методи, які обслуговують приїзд і від'їзд машини.

namespace Laba_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking p = new Parking(10);
            Car car = new Car();

            p.Show();
            car.GoToParking(p);
            p.Show();
            car.GoOut(p);
            p.Show();
        }
        class Parking
        {
            private List<bool> places = new List<bool>();
            public int n = 0;

            public Parking(int n)
            {
                this.n = n;
                Random r = new Random(n);
                for (int i = 0; i < n; i++)
                {
                    places.Add(Convert.ToBoolean(r.Next(2)));
                }
            }
            public void Show()
            {
                Console.WriteLine($" The parking have {n} places:");
                for (int i = 0; i < n; i++)
                {
                    if (places[i] == false)
                    {
                        Console.WriteLine($"\tThe place No {i + 1} is FREE now.");
                    }
                    else
                    {
                        Console.WriteLine($"\tThe place No {i + 1} is BUSY now.");
                    }
                }
            }
            public void TakePlace(int i)
            {
                places[i] = true;
            }
            public void Leave(int i)
            {
                places[i] = false;
            }
            public bool CheckPlace(int i)
            {
                if (places[i] == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class Car
        { 
            private int place_decision = -1;
            
            public void GoToParking(Parking p)
            {
                Console.WriteLine("[Car is entering to the parking]");
                for (int i = 0; i < p.n; i++)
                {
                    if (p.CheckPlace(i))
                    {
                        Console.WriteLine($"Oh, the place No {i + 1} is busy, what about the next place?");
                    }
                    else
                    {
                        place_decision = i;
                        break;
                    }
                }
                Console.WriteLine($"OK! The place No {place_decision + 1} is FREE, " +
                                  $"so I`ll park here.\nMy parking place is No {place_decision + 1}.");
                p.TakePlace(place_decision);
            }
            public void GoOut(Parking p)
            {
                Console.WriteLine($"I`m going away from the parking...");
                p.Leave(place_decision);
                place_decision = -1;
                Console.WriteLine("I am left from the parking.");
            }
        }
    }
}
