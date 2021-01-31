using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHardExam
{
    class Program
    {
        public static int score = 0;
        public static string[] GetRandomAnswers(string[] answer)
        {
            Random random = new Random();
            string random_answer = new string[4];
            var numbers = String.Empty;
            for (int i=0; i < 4;)
            {
                var index = random.Next(0, 4);

                if (!numbers.Contains(index.ToString()))
                {
                    numbers += index.ToString();
                    random_answer[index] = answer[i];
                    i++;
                }
            }
            return random_answer;
        }

        public static void PrintScore()
        {
            Console.Clear();
            score *= 10;
            if (score > 0 && score < 30)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (score >= 30 && score < 60)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (score >= 60 && score < 80)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (score >= 80 && score < 100)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (score == 100)
                 Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Your score: {score}/100");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintQuestion(int question_count,string question)
        {
            Console.WriteLine($"{question_count}.{question}");
        }

        public static void PrintAnswer(int answer_count,string[] answer,int selected)
        {
            for (int j = 0; j < answer_count; j++)
            {
                if(j==selected)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{(char)(65 + j)}) {answer[j]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($"{(char)(65 + j)}) {answer[j]}");
                }
            }
        }

        public static void PrintCorrectAnswer(int question_count,string question,int answer_count,string[]answer,string correct_answer, int selected)
        {
            Console.Clear();
            PrintQuestion(question_count, question);
            for (int j = 0; j < answer_count; j++)
            {
                if (j == selected&& !answer[j].SequenceEqual(correct_answer))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{(char)(65 + j)}) {answer[j]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(answer[j].SequenceEqual(correct_answer))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{(char)(65 + j)}) {answer[j]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($"{(char)(65 + j)}) {answer[j]}");
                }
                if (j == selected && answer[j].SequenceEqual(correct_answer))
                    score++;
            }
        }

        public static int Controle(int question_count,string question,int answer_count,string[] answer)
        {
            int selected = 1;
            while (true)
            {
                Console.Clear();
                PrintQuestion(question_count, question);
                PrintAnswer(answer_count, answer, selected - 1);
                ConsoleKeyInfo KeyInfoPressed = Console.ReadKey();
                switch (KeyInfoPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected > 1)
                            selected--;
                        else
                            selected = answer_count;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selected < answer_count)
                            selected++;
                        else
                            selected = 1;
                        break;
                    case ConsoleKey.Enter:
                        return --selected;
                }
            }
        }

        public static void Welcome()
        {
            string welcome_message = "Welcome and GOOD LUCK";
            for (int i = 0;i<welcome_message.Length; i++)
            {
                Console.Write($"{welcome_message[i]}");
                System.Threading.Thread.Sleep(50);
            }
        }

        public static void Start()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Welcome();
            const int question_count = 10;
            const int answer_count = 4;
            string[] questions = new string[question_count];
            string[][] answer = new string[question_count][];
            for (int i = 0; i < question_count; i++)
            {
                answer[i] = new string[answer_count];
            }
            string[] correct_answer = new string[question_count];
            SetQuestionsandAnswers(questions, answer, correct_answer);
            for (int i = 0; i < question_count; i++)
            {
                answer[i] = GetRandomAnswers(answer[i]);
                int choice= Controle(i+1,questions[i],answer_count,answer[i]);
                PrintCorrectAnswer(i + 1, questions[i], answer_count, answer[i], correct_answer[i], choice);
                System.Threading.Thread.Sleep(1000);
            }
            PrintScore();
        }

        public static void SetCorrectAnswers(string[]correct_answer,string[][]answer)
        {
            for (int i = 0; i < 10; i++)
            {
                correct_answer[i] = answer[i][0];
            }
        }

        public static void SetQuestionsandAnswers(string[]questions,string[][]answer,string[]correct_answer)
        {
            questions[0] = "59 + 48 = ?";
            answer[0][0] = "107";
            answer[0][1] = "110";
            answer[0][2] = "105";
            answer[0][3] = "117";
            questions[1] = "38 * 53 = ?";
            answer[1][0] = "2014";
            answer[1][1] = "1203";
            answer[1][2] = "2114";
            answer[1][3] = "3014";
            questions[2] = "5 * x = 351";
            answer[2][0] = "70.2";
            answer[2][1] = "69.2";
            answer[2][2] = "65.5";
            answer[2][3] = "71.2";
            questions[3] = "((3x / 7) - 14y²)(14y² + (3x / 7))";
            answer[3][0] = "(9x² / 49) - 196y⁴";
            answer[3][1] = "(9x² / 49) + 12xy² - 196y⁴";
            answer[3][2] = "(9x² / 49) + 196y⁴";
            answer[3][3] = "(9x²/49) - 12xy² + 196y⁴";
            questions[4] = "(25 - √(101) ) / (1 - x) > 0";
            answer[4][0] = "(-∞; 5)";
            answer[4][1] = "(1; 5)";
            answer[4][2] = "(5; +∞)";
            answer[4][3] = "(-5; -1)";
            questions[5] = "(x - 5)² - 25";
            answer[5][0] = "x(x - 10)";
            answer[5][1] = "(x - 5)(x - 2)";
            answer[5][2] = "x(x - 25)";
            answer[5][3] = "(x - 5)(x + 5)";
            questions[6] = "log₂((2x + 1)/(3x - 1)) < 1";
            answer[6][0] = "(-∞; -0.5)U(0.75; ∞)";
            answer[6][1] = "(-0.5; ⅓)";
            answer[6][2] = "(-0.5; 2)";
            answer[6][3] = "(⅓; 2)";
            questions[7] = "(4/π)arctan(tan(7π/8))+tan2x=0.5cos(arccos(-0.5)+π/3)";
            answer[7][0] = "πk/2";
            answer[7][1] = "π/4+πk";
            answer[7][2] = "-π/4+πk";
            answer[7][3] = "π/8+πk";
            questions[8] = "0 + 0 = ?";
            answer[8][0] = "0";
            answer[8][1] = "Not This";
            answer[8][2] = "Not This";
            answer[8][3] = "Not This";
            questions[9] = "10+10-10*10";
            answer[9][0] = "-80";
            answer[9][1] = "0";
            answer[9][2] = "5";
            answer[9][3] = "25";
            SetCorrectAnswers(correct_answer, answer);
        }

        static void Main(string[] args)
        {
            Start();
        }
    }
}
