using System;
using OOP_Laba2_Lib;
namespace OOP_Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strochka1 = "садок вишневий коло хати,";
            string strochka2 = "хрущi над вишнями гудуть,";
            string strochka3 = "плугатарi з плугами йдуть,";
            string strochka4 = "спiвають iдучи дiвчата,";

            Line line1 = new Line(strochka1.ToCharArray(), strochka1.Length);  
            Line line2 = new Line(strochka2.ToCharArray(), strochka2.Length);
            Line line3 = new Line(strochka3.ToCharArray(), strochka3.Length);
            Line line4 = new Line(strochka4.ToCharArray(), strochka4.Length);

            Text text = new Text(line1);
            text.AddToText(line2);
            text.AddToText(line3);
            text.AddToText(line4);

            char[][] chars = text.GetText();

            Console.WriteLine("Current text");
            text.OutputText(chars, text.GetNumberOfStr());

            Console.WriteLine("'1' - to add a string, \n'2' - to delete a string, " +
                "\n'3' - to delete strings that contains a word, " +
                "\n'4' - to clear a text, \n'5' - to get a length of the longest string, " +
                "\n'6' - to make first letters to uppercase, \n'7' - to see this message");
            for (int n = 0; n < 7; n++)
            {
                Console.Write("input a num: ");
                string inputed = Console.ReadLine();
                if (CorrectConvert(inputed))
                {
                    int choice = int.Parse(inputed);
                    switch (choice)
                    {
                        case 1:
                            string strochka5 = "а матерi вечерять ждуть.";
                            Line line5 = new Line(strochka5.ToCharArray(), strochka5.Length);
                            text.AddToText(line5);
                            chars = text.GetText();
                            Console.WriteLine("Current text");
                            text.OutputText(chars, text.GetNumberOfStr());
                            break;
                        case 2:
                            Console.WriteLine("please, enter an index: ");
                            int index = int.Parse(Console.ReadLine());
                            text.DeleteLine(index);
                            chars = text.GetText();
                            Console.WriteLine("Current text");
                            text.OutputText(chars, text.GetNumberOfStr());
                            break;
                        case 3:
                            Console.WriteLine("please, enter a substring");
                            string str = Console.ReadLine();
                            text.DeleteStringWhichContainsWord(str.ToCharArray(), str.Length);
                            chars = text.GetText();
                            Console.WriteLine("Current text");
                            text.OutputText(chars, text.GetNumberOfStr());
                            break;
                        case 4:
                            text.Erase();
                            chars = text.GetText();
                            Console.WriteLine("Current text");
                            text.OutputText(chars, text.GetNumberOfStr());
                            break;
                        case 5:
                            int length = text.TheBigestLength();
                            Console.WriteLine($"the biggest length is: {length}");
                            break;
                        case 6:
                            text.UpperCase();
                            chars = text.GetText();
                            Console.WriteLine("Current text");
                            text.OutputText(chars, text.GetNumberOfStr());
                            break;
                        case 7:
                            Console.WriteLine("'1' - to add a string, \n'2' - to delete a string, " +
                    "\n'3' - to delete strings that contains a word, " +
                    "\n'4' - to clear a text, \n'5' - to get a length of the longest string, " +
                    "\n'6' - to make first letters to uppercase, \n'7' - to see this message");
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                }
            }
        }
        public static bool CorrectConvert(string input)
        {
            int result;
            bool isCorrect = int.TryParse(input, out result);
            if (!isCorrect)
            {
                Console.WriteLine("error4ik");
            }
            return isCorrect;
        }
    }
}