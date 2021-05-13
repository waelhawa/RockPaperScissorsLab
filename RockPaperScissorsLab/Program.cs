using System;
using System.Text;

namespace RockPaperScissorsLab
{
    class Program
    {
        const string message1 = "Input your name: ";
        const string message2 = "Would you like to play against Rock player or Random player?: ";
        const string message3 = "Would you like to continue? (Y/N): ";
        const string message4 = "Welcome to Rock Paper Scissors";
        const string message5 = "1- Rock Player\n2- Random Player\nEntry: ";
        const string message6 = "Rock, Paper, Scissors? (R/P/S): ";
        const string error1 = "Name can't be empty";
        const string error2 = "Name can only be letters";
        const string error3 = "Please use numbers only";
        const string error4 = "Please choose 1 or 2";
        const string error5 = "Please choose y or n";
        const string error6 = "Something went wrong.";
        const string error7 = "Please choose R, P, or S";
        const string error8 = "Selection can't be blank";
        const string error9 = "Selection can't be numbers";
        const string pattern = "rps";
        static void Main(string[] args)
        {
            bool looper = true;
            int playAgainst = 0;
            string text = "";
            Console.WriteLine(message4);
            Player player1 = new RPSApp(MultipleWords(UserEntry(message1, error1, error2)));
            Player player2 = null;
            Console.WriteLine($"Hello {player1.Name}");
            Console.WriteLine(message2);
            while (looper)
            {
                playAgainst = IntegerEntry(message5, error3);
                if (playAgainst < 3 || playAgainst > 0)
                {
                    looper = false;
                }
                else
                {
                    Console.WriteLine(error4);
                }
            }

            switch (playAgainst)
            {
                case 1:
                    player2 = new RockPlayer();
                    looper = true;
                    break;
                case 2:
                    player2 = new RandomPlayer();
                    looper = true;
                    break;
                default:
                    Console.WriteLine(error6);
                    break;
            }


        while (looper)
            {
                player1.Hand = UserSelection();
                if (playAgainst == 2)
                {
                    player2.Hand = player2.GenerateRPS();
                }

                Console.WriteLine($"{player1.Name}: {player1.Hand}\n{player2.Name}: {player2.Hand}\n{RPSRules(player1, player2)}");

                looper = Verification(message3, error5);
            }

            Console.WriteLine("Goodbye!");
        }

        public static bool Verification(string phrase, string error)
        {
            string text;
            while (true)
            {
                Console.Write(phrase);
                text = Console.ReadLine().Trim().ToLower();

                switch (text)
                {
                    case "y":
                    case "yes":
                        return true;


                    case "n":
                    case "no":
                        return false;


                    default:
                        Console.WriteLine(error);
                        break;
                }
            }
        } //end Verification

        public static string UserEntry(string message, string blankError, string notLetterError)
        {
            string text;
            bool checker;
            while (true)
            {
                checker = true;
                Console.Write(message);
                text = Console.ReadLine().Trim().ToLower();
                checker = Validation(text, blankError, notLetterError);
                if (checker)
                {
                    return text;
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            }
        } //end UserEntry

        public static string Indent(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
        } //end Indent

        public static string MultipleWords(string text)
        {
            string[] words;
            char[] delimiters = { ' ', '.', ':', '-' };
            StringBuilder newText = new StringBuilder();
            words = text.Split(delimiters);
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    newText.Append(Indent(word));
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString().ToLower() != newText[i].ToString().ToLower())
                {
                    newText.Insert(i, text[i]);
                }
            }
            return newText.ToString().Trim();
        } //end MultipleWords

        public static bool Validation(string text, string blankError, string notLetterError)
        {
            if (!String.IsNullOrEmpty(text) || !String.IsNullOrWhiteSpace(text))
            {
                foreach (char letter in text.ToCharArray())
                {
                    if (Char.IsLetter(letter) || Char.IsWhiteSpace(letter))
                    {

                    }
                    else
                    {
                        Console.WriteLine(notLetterError);
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine(blankError);
                return false;
            }
            return true;
        } //end Validation

        public static int IntegerEntry(string phrase, string error)
        {
            string text;
            int integerNumber;
            while (true)
            {
                Console.Write(phrase);
                text = Console.ReadLine().Trim().ToLower();
                if (int.TryParse(text, out integerNumber))
                {
                    return integerNumber;
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
        } //end IntegerEntry

        public static string RPSRules(Player p1, Player p2)
        {
            if (p1.Hand == p2.Hand)
            {
                return "Draw!";
            }
            else if ((p1.Hand == RPS.rock && p2.Hand == RPS.scissors) || (p1.Hand == RPS.scissors && p2.Hand == RPS.paper) || (p1.Hand == RPS.paper && p2.Hand == RPS.rock))
            {
                return $"{p1.Name} wins!";
            }
            else
            {
                return $"{p2.Name} wins!";
            }
            
        } //end RPSRules

        public static RPS UserSelection ()
        {
            string text = "";
            bool looper = true;
            while (looper)
            {
                text = UserEntry(message6, error8, error9);
                if (text.Length == 1)
                {
                    if (pattern.Contains(text))
                    {
                        looper = false;
                    }
                    else
                    {
                        Console.WriteLine(error7);
                    }

                }
                else
                {
                    Console.WriteLine(error7);
                }
            }

            switch (text)
            {
                case "r":
                    return RPS.rock;
                case "p":
                    return RPS.paper;
                case "s":
                    return RPS.scissors;
                default:
                    Console.WriteLine(error6);
                    return 0;
            }
        } //end UserSelection

    }
}
