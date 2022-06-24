using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

//Видалити зі словника елементи з однаковими значеннями.
//Записати результат у JSON файл.

namespace Laba_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary initialisating
            Console.WriteLine("Укажите количество значений в словаре: ");
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> myDic = new Dictionary<int, int>();
            Random random = new Random(n);
            List<int> m = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int a = random.Next(10);
                m.Add(a);
            }
            for (int i = 0; i < n; i++)
            {
                myDic.Add(i, m[i]);
                Console.WriteLine($"Элемент {i} --> {myDic[i]}");
            }


            // Deleting all duplicates
            /*List<int> list = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (myDic[i] == myDic[j])
                    {

                        bool b = true;
                        foreach (int a in list)
                        {
                            if (a == j)
                            {
                                b = false;
                                break;
                            }
                        }
                        if (b)
                        {
                            list.Add(j);
                        }
                    }
                }
            }

            foreach (int i in list)
            {
                myDic.Remove(i);
            }*/
            var results = myDic.GroupBy(x => x.Value).Select(x => x.First()).ToList();
            //Print the dictionary
            Console.WriteLine(" Итоговое содержание словаря без повторов:");
            foreach (var i in results)
            {
                Console.WriteLine($"\tIndex {i.Key} ---> {i.Value}");
            }
            Console.WriteLine();
            string json = JsonConvert.SerializeObject(results);
            string filepath = @"C:\Университет\II семестр\ОП 2\Проекты\Laba_3\Laba 3.2\Data.json";

            File.WriteAllText(filepath, json);
            if (File.Exists(filepath))
            {
                Console.WriteLine("Json saved succesful.");
            }
        }
    }
}
