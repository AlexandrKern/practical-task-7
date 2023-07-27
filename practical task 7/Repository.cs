using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace practical_task_7
{
    class Repository
    {
        private int i;//переменная для работы с массивами
        private string path; //путь к Файлу
        private Worker[] workers;//Массив для Хранения сотрудников
        public Repository()
        {
            path = @"Сотрудники.txt";
            workers = new Worker[1];
            i = 0;
        }
        /// <summary>
        /// Определяет размер массива
        /// </summary>
        private void ArraySize()
        {
            workers = new Worker[File.ReadAllLines(path).Length];
        }
        /// <summary>
        /// Шаблон печати
        /// </summary>
        private void WorkersPrint(Worker[] workers, int b)
        {
            i = b;
            Console.WriteLine($"{workers[i].ID}" +
                               $"{workers[i].DateTime,31}" +
                               $"{workers[i].FullName,28}" +
                               $"{workers[i].Age,5}" +
                               $"{workers[i].Height,10}" +
                               $"{workers[i].DateOfBirth,13}" +
                               $"{workers[i].PlaceOfBirth,19}");
        }
        /// <summary>
        /// Заголовки полей
        /// </summary>
        private void HeadLines()
        {
            Console.WriteLine($"{"id Сотрудника"}{" Дата и время",15} {"Ф. И. О.",13} {"Возраст",27}" +
                             $" {"Рост",5} {"Дата рождения",14} {"Место рождения",15}");
        }
        /// <summary>
        /// Заполнение файла
        /// </summary>
        public void Filling()
        {
            if (workers.Length == 0)
                workers = new Worker[1];
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                char key = '1';
                do
                {
                    Console.Write("Id Сотрудника: "); workers[0].ID = $"{Console.ReadLine()}\t";
                    DateTime dateTime = DateTime.Now;
                    Console.WriteLine("Дата и время добавления записи: " + dateTime); workers[0].DateTime = dateTime;
                    Console.Write("Ф.И.О.: "); workers[0].FullName = $"{Console.ReadLine()}\t";
                    Console.Write("Возраст: "); workers[0].Age = $"{Console.ReadLine()}\t";
                    Console.Write("Рост: "); workers[0].Height = $"{Console.ReadLine()}\t";
                    Console.Write("Дата рождения: "); workers[0].DateOfBirth = $"{Console.ReadLine()}\t";
                    Console.Write("Место рождения: "); workers[0].PlaceOfBirth = $"{Console.ReadLine()}\t";
                    sw.WriteLine($"{workers[0].ID}" +
                        $"{workers[0].DateTime}\t" +
                        $"{workers[0].FullName}" +
                        $"{workers[0].Age}" +
                        $"{workers[0].Height}" +
                        $"{workers[0].DateOfBirth}" +
                        $"{workers[0].PlaceOfBirth}");
                    Console.WriteLine("Продожить 1 - да/2 - нет");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == '1');
            }
        }
        /// <summary>
        /// Ищет сотрудника по указанному Id
        /// </summary>
        /// <returns></returns>
        public Worker GetWorkerById()
        {
            Worker worker = new Worker();
            workers = GetAllWorkers();
            if (workers.Length == 0)
                return worker;
            Console.Write("Введите Id: ");
            string id = Console.ReadLine();
            bool flag = true;
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].ID == id)
                {
                    HeadLines();
                    WorkersPrint(workers, i);
                    worker.ID = workers[i].ID;
                    worker.DateTime = workers[i].DateTime;
                    worker.FullName = workers[i].FullName;
                    worker.Age = workers[i].Age;
                    worker.Height = workers[i].Height;
                    worker.DateOfBirth = workers[i].DateOfBirth;
                    worker.PlaceOfBirth = workers[i].PlaceOfBirth;
                    flag = false;
                }
            }
            if (flag)
                Console.WriteLine("Сотрудника с таким id не существует");
            return worker;
        }
        /// <summary>
        /// Считывает текст из файла в массив
        /// </summary>
        /// <returns></returns>
        private Worker[] GetAllWorkers()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                ArraySize();
                int i = 0;
                string line;
                while (true)
                {
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("Не найдено ни одного сотрудника\n");
                        return workers;
                    }
                    string[] data = line.Split('\t');
                    workers[i].ID = data[0];
                    workers[i].DateTime = DateTime.Parse(data[1]);
                    workers[i].FullName = data[2];
                    workers[i].Age = data[3];
                    workers[i].Height = data[4];
                    workers[i].DateOfBirth = data[5];
                    workers[i].PlaceOfBirth = data[6];
                    i++;
                    if (i == File.ReadAllLines(path).Length)
                        return workers;
                }
            }
        }
        /// <summary>
        /// Вывод все сотрудников на консоль 
        /// </summary>
        /// <returns></returns>
        public Worker[] Print()
        {
            workers = GetAllWorkers();
            if (workers.Length == 0)
            {
                workers = new Worker[1];
                return workers;
            }
            HeadLines();
            i = 0;
            while (true)
            {
                WorkersPrint(workers, i);
                i++;
                if (i == File.ReadAllLines(path).Length)
                    return workers;
            }
        }
        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <returns></returns>
        public void DeleteWorker()
        {
            workers = GetAllWorkers();
            if (workers.Length == 0)
                return;
            Worker[] workersnew = new Worker[File.ReadAllLines(path).Length - 1];
            Worker worker = GetWorkerById();
            string a = worker.ID;
            if (a == null)
                return;
            Console.WriteLine("Подтвердить удаление 1 - да/2 - нет");
            string delete = Console.ReadLine();
            int count = 0;
            if (delete == "1")
            {
                for (int i = 0; a != workers[i].ID; i++)
                {
                    workersnew[i] = workers[i];
                    count++;
                }
                for (int i = count; i < workersnew.Length; i++)
                    workersnew[i] = workers[i + 1];
                File.Delete(path);
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    for (int i = 0; i < workersnew.Length; i++)
                    {
                        sw.WriteLine($"{workersnew[i].ID}\t" +
                        $"{workersnew[i].DateTime}\t" +
                        $"{workersnew[i].FullName}\t" +
                        $"{workersnew[i].Age}\t" +
                        $"{workersnew[i].Height}\t" +
                        $"{workersnew[i].DateOfBirth}\t" +
                        $"{workersnew[i].PlaceOfBirth}\t");
                    }
                }
            }
            if (delete == "2")
                return;
        }
        /// <summary>
        /// Загрузка записей в выбранном диапазоне дат
        /// </summary>
        public void GetWorkersBetweenTwoDates()
        {
            workers = GetAllWorkers();
            if (workers.Length == 0)
                return;
            Console.Write("C: ");
            DateTime from = DateTime.Parse(Console.ReadLine());
            Console.Write("По: ");
            DateTime to = DateTime.Parse(Console.ReadLine());
            bool a = true;
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DateTime >= from && workers[i].DateTime <= to)
                {
                    if (a) HeadLines();
                    WorkersPrint(workers, i);
                    a = false;
                }
            }
            if (a) Console.WriteLine("Не найдено ни одного сотрудника\n");
        }
    }
}
