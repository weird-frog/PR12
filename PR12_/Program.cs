using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR12_
{
    class Program
    {
        const int numberOfLines = 350;
        static string[] arr = new string[numberOfLines];
        static void Main(string[] args)
        {
            GenerateText();
            Console.WriteLine("Нажмите любую клавишу, чтобы считать строки");
            Console.ReadKey();
            ReadTextAsync();
            Console.WriteLine("\nВведите вашу имя и фамилию:");
            StreamWriter sw = new StreamWriter("userinfo.txt");
            sw.WriteLine(Console.ReadLine());
            sw.Close();
            Console.WriteLine("Вывести считанный текст?\n0 - НЕТ\t1 - ДА");
            if (Console.ReadLine() == "1")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
            else Console.WriteLine("Ладно...");
            Console.ReadKey();
        }

        static async void ReadTextAsync()
        {
            await Task.Run(() => ReadText());
        }
        static void ReadText()
        {
            StreamReader sr = new StreamReader("someText.txt");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sr.ReadLine();
            }
            sr.Close();
        }

        static void GenerateText() //генерирует txt файл с рандомными символами
        {
            if (File.Exists("someText.txt")) //
            { 
                File.Delete("someText.txt"); 
            }
            var random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StreamWriter sw = new StreamWriter("someText.txt", true, Encoding.ASCII);
            string substr = "";
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < 500; j++) //в каждой строке будет 500 символов
                {
                    substr += chars[random.Next(0, 61)];
                }
                sw.WriteLine(substr);
                substr = "";
            }
            sw.Close();
        }
    }
}
