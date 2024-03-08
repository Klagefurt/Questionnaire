using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace questionnaire
{
    public static class Table
    {
        private static string spaces1 = new string('-', 25);
        private static string spaces2 = new string('-', 12);
        private static string empty_spaces1 = new string(' ', 25);
        private static string empty_spaces2 = new string(' ', 12);

        private static string divider = '+' + spaces1 + '+' + spaces2 + '+';
        private static string newline = '|' + empty_spaces1 + '|' + empty_spaces2 + '|';

        public static void CreateFirstRow(string path)
        {
            var first_line = new StringBuilder(divider);
            var line = new StringBuilder(newline);

            line.Insert(2, "ФИО");
            line.Remove(5, 3);
            line.Insert(28, "Результат");
            line.Remove(37, 9);

            File.WriteAllText(path, divider + Environment.NewLine);
            File.AppendAllText(path, line + Environment.NewLine);
            File.AppendAllText(path, divider + Environment.NewLine);
        }
        public static void AddRowToTable(string path, string name, string row)
        {
            int name_length = name.Length;
            int row_length = row.Length;

            var new_row = new StringBuilder(newline);
            new_row.Insert(2, name);
            new_row.Remove(2 + name_length, name_length);
            new_row.Insert(28, row);
            new_row.Remove(28 + row_length, row_length);

            File.AppendAllText(path, new_row + Environment.NewLine);
            File.AppendAllText(path, divider + Environment.NewLine);
        }
    }
}
