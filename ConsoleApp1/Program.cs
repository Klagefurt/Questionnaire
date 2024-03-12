namespace questionnaire
{
    internal class Program
    {
        static string CheckAnswer()
        {
            string userAnswer;
            while (true)
            {
                userAnswer = Console.ReadLine();
                bool answer = userAnswer.Equals("да") || userAnswer.Equals("нет");
                if (!answer)
                {
                    Console.WriteLine("Вы ошиблись при вводе, попробуйте снова");
                }
                else
                    break;
            }
            return userAnswer;
        }
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
            int countCorrectAnswers = 0;
            int bestCountCorrectAnswers = -1;

            string userAnswer;
            string userName;

            Console.WriteLine("Хотите загрузить результаты? (да, нет)");
            userAnswer = CheckAnswer();
            if (userAnswer.Equals("да")) 
                Table.ShowResults();

            Console.WriteLine("Хотите пройти тестирование? (да, нет)");
            userAnswer = CheckAnswer();
            if (userAnswer.Equals("да"))
            {
                Console.WriteLine("Как Вас зовут?");
                userName = Console.ReadLine();

                while (true)
                {
                    System.Random rnd = new System.Random();
                    var numbers = Enumerable.Range(0, countQuestions).OrderBy(r => rnd.Next()).ToArray();

                    for (int i = 0; i < countQuestions; i++)
                    {
                        int currentRandomNumber = numbers[i];

                        int userIntAnswer;
                        Console.WriteLine("Вопрос N: " + (i + 1));
                        Console.WriteLine(GetQuestions()[currentRandomNumber]);

                        while (!int.TryParse(Console.ReadLine(), out userIntAnswer))
                        {
                            Console.WriteLine("Вы ввели не цифру, попробуйте еще раз");
                        }

                        if (userIntAnswer == GetAnswers()[currentRandomNumber]) { countCorrectAnswers++; }
                    }

                    Console.WriteLine("Количество правильных ответов: " + countCorrectAnswers);

                    if (countCorrectAnswers > bestCountCorrectAnswers)
                    {
                        bestCountCorrectAnswers = countCorrectAnswers;
                    }

                    string result = GetScores(countCorrectAnswers, countQuestions);
                    Console.WriteLine(userName + ", Ваш диагноз: " + result);

                    Console.WriteLine("\nХотите пройти тест еще раз? Лучший результат попадет в итоговую таблицу (да, нет)");
                    userAnswer = CheckAnswer();

                    if (userAnswer.Equals("нет"))
                    {
                        DateTime dt = DateTime.Now;
                        string curDate = dt.ToShortDateString();
                        string userResult = GetScores(bestCountCorrectAnswers, countQuestions);
                        Table.AddData(userName, userResult, curDate);
                        break;
                    }
                }
            }
        }
    }
}