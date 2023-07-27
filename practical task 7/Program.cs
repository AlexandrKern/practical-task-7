using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            string a = "Не найдено ни одного сотрудника\n";
            Repository repository = new Repository();
            while (flag)
            {
                Console.WriteLine();
                Console.WriteLine("Введите '1' дополнить данные.");
                Console.WriteLine("Введите '2' вывести данные на экран.");
                Console.WriteLine("Введите '3' найти сотрудника по Id");
                Console.WriteLine("Введите '4' удалить сотрудника по Id");
                Console.WriteLine("Введите '5' загрузить записи в выбранном диапазоне дат");
                Console.WriteLine("Введите '6' закрыть программу");
                string key = Console.ReadLine();
                Console.Clear();
                switch (key)
                {
                    case "1":
                        repository.Filling();
                        break;
                    case "2":
                        if (File.Exists(@"Сотрудники.txt"))
                            repository.Print();
                        else Console.WriteLine(a);
                        break;
                    case "3":
                        if (File.Exists(@"Сотрудники.txt"))
                            repository.GetWorkerById();
                        else Console.WriteLine(a);
                        break;
                    case "4":
                        if (File.Exists(@"Сотрудники.txt"))
                            repository.DeleteWorker();
                        else Console.WriteLine(a);
                        break;
                    case "5":
                        if (File.Exists(@"Сотрудники.txt"))
                            repository.GetWorkersBetweenTwoDates();
                        else Console.WriteLine(a);
                        break;
                    case "6":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Убедитесь что вы нажали 1 /2 /3 /4 /5 или 6");
                        break;
                }
            }


        }
    }
}
