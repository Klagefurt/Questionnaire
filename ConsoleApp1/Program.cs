namespace questionnaire
{
    internal class Program
    {
        static string[] GetQuestions()
        {
            string[] questions = new string[] {
                "Сколько будет два плюс два умноженное на два?",
                "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
                "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
                "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
                "Пять свечей горело, две потухли. Сколько свечей осталось?",
                "Сколько было чудес света?",
                "Сколько километров до луны?"
            };
            return questions;
        }
        static int[] GetAnswers()
        {
            int[] answers = new int[] { 6, 9, 25, 60, 2, 7, 384400 };
            return answers;
        }
        static string GetScores(int countCorrectAnswers, int countQuestions)
        {
            //математическое округление до целого
            int correctProcent = (int)Math.Round((double)countCorrectAnswers * 100 / countQuestions);

            Console.WriteLine($"Процент правильных ответов: {correctProcent}");

            if (correctProcent < 15) return "кретин";
            else if (correctProcent < 30) return "идиот";
            else if (correctProcent < 45) return "дурак";
            else if (correctProcent < 65) return "нормальный";
            else if (correctProcent < 85) return "талант";
            else return "гений";

        }
        private static void Main(string[] args)
        {

            string[] questions = GetQuestions();
            int[] answers = GetAnswers();

            int countQuestions = GetQuestions().Count();

            Console.WriteLine("Как Вас зовут?");
            string userName = Console.ReadLine();

            while (true)
            {
                System.Random rnd = new System.Random();
                var numbers = Enumerable.Range(0, countQuestions).OrderBy(r => rnd.Next()).ToArray();
                int countCorrectAnswers = 0;

                for (int i = 0; i < countQuestions; i++)
                {
                    int currentRandomNumber = numbers[i];

                    int userAnswer1;
                    Console.WriteLine("Вопрос N: " + (i + 1));
                    Console.WriteLine(GetQuestions()[currentRandomNumber]);

                    while (!int.TryParse(Console.ReadLine(), out userAnswer1))
                    {
                        Console.WriteLine("Вы ввели не цифру, попробуйте еще раз");
                    }

                    if (userAnswer1 == GetAnswers()[currentRandomNumber]) { countCorrectAnswers++; }
                }

                Console.WriteLine("Количество правильных ответов: " + countCorrectAnswers);

                string result = GetScores(countCorrectAnswers, countQuestions);
                Console.WriteLine(userName + ", Ваш диагноз: " + result);

                Console.WriteLine("\nХотите пройти тест еще раз? Лучший результат попадет в итоговую таблицу (да, нет)");
                string userAnswer2;
                while (true)
                {
                    userAnswer2 = Console.ReadLine();
                    bool answer = userAnswer2.Equals("да") || userAnswer2.Equals("нет");
                    if (!answer)
                    {
                        Console.WriteLine("Вы ошиблись при вводе, попробуйте снова");
                    }
                    else
                        break;
                }
                if (userAnswer2.Equals("нет"))
                {
                    break;
                }
            }

        }
    }
}