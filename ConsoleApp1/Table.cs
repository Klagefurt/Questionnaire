using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace questionnaire
{
    public static class Table
    {
        public static string path = @"c:\_C#\Results.txt";

        private static string spaces1 = new string(' ', 20);
        private static string spaces2 = new string(' ', 12);
        private static string spaces3 = new string('-', 24);
        private static string spaces4 = new string('-', 22);
        private static string spaces5 = new string('-', 17);

        private static string empty_spaces1 = new string(' ', 24);
        private static string empty_spaces2 = new string(' ', 22);
        private static string empty_spaces3 = new string(' ', 17);

        private static string first_line = "| " + "ФИО" + spaces1 + "| " + "Результат" + spaces2 + "| " + "Дата" + spaces2 + '|';
        private static string divider = '|' + spaces3 + '|' + spaces4 + '|' + spaces5 + '|';

        private static string newline = '|' + empty_spaces1 + '|' + empty_spaces2 + '|' + empty_spaces3 + '|';

        public static void ShowResults()
        {
            Console.WriteLine(first_line);
            Console.WriteLine(divider);

            StreamReader sr = new StreamReader(path);
            var line = sr.ReadLine();
            while (line != null)
            {
                var splittedLine = line.Split('#');
                var name = splittedLine[0];
                var result = splittedLine[1];
                var time = splittedLine[2];

                var newLine = new StringBuilder(newline);
                newLine.Insert(2, name);
                newLine.Remove(2 + name.Length, name.Length);
                newLine.Insert(27, result);
                newLine.Remove(27 +  result.Length, result.Length);
                newLine.Insert(50, time);
                newLine.Remove(50 + time.Length, time.Length);

                Console.WriteLine(newLine);
                line = sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine();
        }
        public static void AddData(string name, string result, string curDate)
        {
            string newData = name + "#" + result + "#" + curDate;

            TextWriter tw = new StreamWriter(path, true);
            tw.WriteLine(newData);
            tw.Close();
        }
    }
}
