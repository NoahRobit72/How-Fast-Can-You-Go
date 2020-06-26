using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HowFastCanYouGo
{

    // **************************************************
    //
    // Title: "How Fast Can You Go Quiz"
    // Description: Timed quiz with data analysis
    // Application Type: Console
    // Author: Robitshek, Noah
    // Dated Created: 6/22/2020
    // Last Modified: 6/24/2020
    //
    // **************************************************

    class Program
    {
        static void Main(string[] args)
        { 
            string username;
            bool keepGoing;

            List<int> colorData = new List<int>();
            List<int> riddleData = new List<int>();
            List<int> mathData = new List<int>();
            List<int> alphabetData = new List<int>();

            username = Introduction();

            keepGoing = DoYouWantToKeepGoing();

            if (keepGoing == true)
            {
                WouldLikeExample();

                alphabetData = Alphabet();

                mathData = Math();

                riddleData = Riddle();

                colorData = Color();

                CongratsScreen(username);
                DataScreen(alphabetData, mathData, riddleData, colorData);

                ExitScreen();

            }
            else
            {
                ExitScreen();
            }
        }
        #region Data Screens
        private static void DataScreen(List<int> alphabetTimes,
                                       List<int> mathTimes, List<int> riddleTimes,
                                       List<int> colorTimes)
        {
            bool loop;
            string usp = "";
            DisplayScreenHeader("Data Screen");

            Console.WriteLine("Welcome to the Data Screen");
            Console.WriteLine();
            do
            {
                Console.Write("Would you like to see your results? [yes , no]: ");
                usp = Console.ReadLine().ToLower();
                if (usp == "yes")
                {
                    loop = false;
                    DataStats( alphabetTimes, mathTimes, riddleTimes, colorTimes);
                }
                else if (usp == "no")
                {
                    loop = false;
                    Console.WriteLine("Have a nice day!!");

                }
                else
                {
                    loop = true;
                    Console.WriteLine();
                    Console.WriteLine("Please answer the YES or NO question with a \"yes\" or \"no\" answer!");
                    Console.WriteLine();
                }
            } while (loop);

            DisplayContinuePrompt();
        }

        private static void DataStats(List<int> alphabetTimes,
                                       List<int> mathTimes, List<int> riddleTimes,
                                       List<int> colorTimes)
        {

            DisplayScreenHeader("Data Screen");

            Console.WriteLine("Below are your Statistics:");
            Console.WriteLine();
            Console.WriteLine("Example 1 (Alphabet) :");
            Console.WriteLine($"Question 1 took you: {alphabetTimes[0]} seconds after {alphabetTimes[1]} attempt(s)");
            Console.WriteLine();
            Console.WriteLine("Example 2 (Math) :");
            Console.WriteLine($"Question 1 took you {mathTimes[0]} seconds after {mathTimes[3]} attempt(s)");
            Console.WriteLine($"Question 2 took you {mathTimes[1]} seconds after {mathTimes[4]} attempt(s)");
            Console.WriteLine($"Question 3 took you {mathTimes[2]} seconds after {mathTimes[5]} attempt(s)");
            Console.WriteLine();
            Console.WriteLine("Example 3 (Riddles) :");
            Console.WriteLine($"Question 1 took you: {riddleTimes[0]} seconds after {riddleTimes[2]} attempt(s)");
            Console.WriteLine($"Question 2 took you: {riddleTimes[1]} seconds after {riddleTimes[3]} attempt(s)");
            Console.WriteLine();
            Console.WriteLine("Example 4 (Colors) :");
            Console.WriteLine($"Question 1 took you: {colorTimes[0]} seconds after {colorTimes[3]} attempt(s)");
            Console.WriteLine($"Question 2 took you: {colorTimes[1]} seconds after {colorTimes[4]} attempt(s)");
            Console.WriteLine($"Question 3 took you: {colorTimes[2]} seconds after {colorTimes[5]} attempt(s)");

            DisplayContinuePrompt();

            DisplayScreenHeader("Data Screen");
            Console.WriteLine("Below are your Statistics:");
            Console.WriteLine();
            //
            // LINQ code from Samual Sam at https://www.tutorialspoint.com
            //
            int totalSum = mathTimes[0] + mathTimes[1] + mathTimes[2] +
                riddleTimes[0] + riddleTimes[1] + colorTimes[0] +
                colorTimes[1] + colorTimes[2] + alphabetTimes[0];
            Console.WriteLine($"Total Time = {totalSum} seconds");
            Console.WriteLine();

            string totalAverage = (totalSum / 9).ToString("n3");
            Console.WriteLine($"Average Time per Question = {totalAverage} seconds");
            Console.WriteLine();

            string questionsPerSecond = (9 / (double)totalSum).ToString("n3");
            Console.WriteLine($"Average Questions per Time = {questionsPerSecond} questions/second");
        }
        #endregion
        #region Congrats Screens
        private static void CongratsScreen(string username)
        {
            DisplayScreenHeader("CONGRATS");

            Console.WriteLine("A select few in this world have the intellectual capacity to conquer such challenges.");
            Console.WriteLine();
            Console.WriteLine("You are among the few...");
            Console.WriteLine();
            Console.WriteLine(UppercaseFirst(username) + ", I knew you could do it!");
            Console.WriteLine();
            Console.WriteLine("Here is your certificate");
            Certificate();
            DisplayContinuePrompt();
        }

        private static void Certificate()
        {
            Console.WriteLine();
            Console.WriteLine("\t--------------------------------------");
            Console.WriteLine("\t|                                    |");
            Console.WriteLine("\t|         CONGRATULATIONS!!          |");
            Console.WriteLine("\t|                                    |");
            Console.WriteLine("\t--------------------------------------");
            Console.WriteLine();
        }
        #endregion
        #region Quiz Questions
        private static List<int> Color()
        {
            bool wrong = false;
            int countColor1 = 1;
            int countColor2 = 1;
            int countColor3 = 1;

            List<int> colorTimes = new List<int>();

            Stopwatch stopWatchColor1 = new Stopwatch();
            Stopwatch stopWatchColor2 = new Stopwatch();
            Stopwatch stopWatchColor3 = new Stopwatch();

            DisplayScreenHeader("Exercise 4)");

            do /// Color Problem #1
            {
                stopWatchColor1.Start();
                Console.Write("Example 1: What color is the word ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Green?  ");
                Console.ForegroundColor = ConsoleColor.White;
                string answer = Console.ReadLine().ToLower();

                if (answer == "blue")
                {

                    Correct();
                    stopWatchColor1.Stop();
                    wrong = false;
   
                }
                else
                {
                    wrong = true;
                    Wrong();
                    countColor1 += 1;
                }
            } while (wrong && countColor1 <= 3);

            if (countColor1 > 3)
            {
                stopWatchColor1.Stop();
                Console.WriteLine("You have exceded the limit...");
            }

            do /// Color Problem #2
            {
                stopWatchColor2.Start();
                Console.Write("Example 1: What color is word ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Purple?  ");
                Console.ForegroundColor = ConsoleColor.White;

                string answer = Console.ReadLine().ToLower();
                if (answer == "yellow")
                {
                    Correct();
                    stopWatchColor2.Stop();
                    wrong = false;
                }
                else
                {
                    wrong = true;
                    Wrong();
                    countColor2 += 1;
                }
            } while (wrong && countColor2 <= 3);

            if (countColor2 > 3)
            {
                stopWatchColor2.Stop();
                Console.WriteLine("You have exceded the limit...");
            }

            do /// Color Problem #3
            {
                stopWatchColor3.Start();
                Console.Write("Example 1: What color is word ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Gray?  ");
                Console.ForegroundColor = ConsoleColor.White;

                string answer = Console.ReadLine().ToLower();
                if (answer == "red")
                {
                    Correct();
                    stopWatchColor3.Stop();
                    wrong = false;
                }
                else
                {
                    wrong = true;
                    Wrong();
                    countColor3 += 1;
                }
            } while (wrong && countColor3 <= 3);

            if (countColor3 > 3)
            {
                stopWatchColor3.Stop();
                Console.WriteLine("You have exceded the limit...");
            }
            Console.WriteLine();
            Console.WriteLine("Hoorayyyyyy!!! You have finished!!!!!");

            TimeSpan ColorTimespan = stopWatchColor1.Elapsed;
            int timeColor1 = ColorTimespan.Seconds;

            ColorTimespan = stopWatchColor2.Elapsed;
            int timeColor2 = ColorTimespan.Seconds;

            ColorTimespan = stopWatchColor3.Elapsed;
            int timeColor3 = ColorTimespan.Seconds;

            Console.WriteLine($"Question 1 took you {timeColor1} seconds");
            Console.WriteLine($"Question 2 took you {timeColor2} seconds");
            Console.WriteLine($"Question 3 took you {timeColor3} seconds");

            DisplayContinuePrompt();

            colorTimes.Add(timeColor1);
            colorTimes.Add(timeColor2);
            colorTimes.Add(timeColor3);
            colorTimes.Add(countColor1);
            colorTimes.Add(countColor2);
            colorTimes.Add(countColor3);

            return colorTimes;
        }

        private static List<int> Riddle()
        {
            DisplayScreenHeader("Exercise 3)");
            List<int> riddleTimes = new List<int>();

            Stopwatch stopWatchRiddle1 = new Stopwatch();
            Stopwatch stopWatchRiddle2 = new Stopwatch();
       
            bool wrong = false;
            int countRiddle1 = 1;
            int countRiddle2 = 1;


            do /// Riddle Problem #1
            {
                Console.WriteLine("If a red house is made of red bricks;");
                Console.WriteLine("And a yellow house is made of yellow bricks");
                Console.Write("What is a green house made of?: ");
                stopWatchRiddle1.Start();
                string answer = Console.ReadLine().ToLower();
                if (answer == "glass")
                {
                    Correct();
                    stopWatchRiddle1.Stop();
                    wrong = false;
                }
                else
                {
                    wrong = true;
                    Wrong();
                    countRiddle1 += 1;
                }
            } while (wrong && countRiddle1 <= 3);

            if (countRiddle1 > 3)
            {
                stopWatchRiddle1.Stop();
                Console.WriteLine("You have exceded the limit...");
            }

            do /// Riddle Problem #2
            {
                Console.Write("Which word in the dictonary is spelled incorrectly?: ");
                stopWatchRiddle2.Start();
                string answer = Console.ReadLine().ToLower();
                if (answer == "incorrectly")
                {
                    Correct();
                    stopWatchRiddle2.Stop();
                    wrong = false;

                }
                else
                {
                    wrong = true;
                    Wrong();
                    countRiddle2 += 1;
                }
            } while (wrong && countRiddle2 <= 3);

            if (countRiddle2 > 3)
            {
                stopWatchRiddle2.Stop();
                Console.WriteLine("You have exceded the limit...");
            }




            TimeSpan RiddleTimespan = stopWatchRiddle1.Elapsed;
            int timeRiddle1 = RiddleTimespan.Seconds;

            RiddleTimespan = stopWatchRiddle2.Elapsed;
            int timeRiddle2 = RiddleTimespan.Seconds;

           

            Console.WriteLine($"Question 1 took you {timeRiddle1} seconds");
            Console.WriteLine($"Question 2 took you {timeRiddle2} seconds");


            DisplayContinuePrompt();

            riddleTimes.Add(timeRiddle1);
            riddleTimes.Add(timeRiddle2);
            riddleTimes.Add(countRiddle1);
            riddleTimes.Add(countRiddle2);

            return riddleTimes;
        }

        private static List<int> Math()
        {
            DisplayScreenHeader("Exercise 2)");

            List<int> mathTimes = new List<int>();

            Stopwatch stopWatchMath1 = new Stopwatch();
            Stopwatch stopWatchMath2 = new Stopwatch();
            Stopwatch stopWatchMath3 = new Stopwatch();

            bool wrong = false;
            int countMath1 = 1;
            int countMath2 = 1;
            int countMath3 = 1;
            do /// Math Problem #1
            {
                Console.Write("The answer to 4 x 8 =  ");
                stopWatchMath1.Start();
                string answer = Console.ReadLine().ToLower();
                if (answer == "32")
                {
                    Correct();
                    stopWatchMath1.Stop();
                    wrong = false;
                }
                else
                {
                    wrong = true;
                    Wrong();
                    countMath1 += 1;
                }
            } while (wrong && countMath1 <= 3);

            if (countMath1 > 3)
            {
                stopWatchMath1.Stop();
                Console.WriteLine("You have exceded the limit...");
            }

            do /// Math Problem #2
            {
                Console.Write("The answer to 11 x 11 =  ");
                stopWatchMath2.Start();
                string answer = Console.ReadLine().ToLower();
                if (answer == "121")
                {
                    Correct();
                    stopWatchMath2.Stop();
                    wrong = false;
                }
                else
                {
                    wrong = true;
                    Console.WriteLine();
                    Wrong();
                    Console.WriteLine();
                    countMath2 += 1;
                }
            } while (wrong && countMath2 <= 3);

            if (countMath2 > 3)
            {
                stopWatchMath2.Stop();
                Console.WriteLine("You have exceded the limit...");
            }

            do /// Math Problem #3
            {
                Console.Write("The answer to 21 x 7 =  ");
                stopWatchMath3.Start();
                string answer = Console.ReadLine().ToLower();
                if (answer == "147")
                {
                    Correct();
                    stopWatchMath3.Stop();
                    wrong = false;
                }
                else
                {
                    wrong = true;
                    Wrong();
                    countMath3 += 1;
                }
            } while (wrong && countMath3 <= 3);

            if (countMath3 > 3)
            {
                stopWatchMath3.Stop();
                Console.WriteLine("You have exceded the limit...");
            }

            TimeSpan MathTimespan = stopWatchMath1.Elapsed; 
            int timeMath1 = MathTimespan.Seconds;

            MathTimespan = stopWatchMath2.Elapsed;
            int timeMath2 = MathTimespan.Seconds;

            MathTimespan = stopWatchMath3.Elapsed;
            int timeMath3 = MathTimespan.Seconds;

            Console.WriteLine($"Question 1 took you {timeMath1} seconds");
            Console.WriteLine($"Question 2 took you {timeMath2} seconds");
            Console.WriteLine($"Question 2 took you {timeMath3} seconds");

            DisplayContinuePrompt();

            mathTimes.Add(timeMath1);
            mathTimes.Add(timeMath2);
            mathTimes.Add(timeMath3);
            mathTimes.Add(countMath1);
            mathTimes.Add(countMath2);
            mathTimes.Add(countMath3);



            return mathTimes;
        }

        private static List<int> Alphabet()
        {
            List<int> alphabetTimes = new List<int>();
            Stopwatch stopWatchAlphabet = new Stopwatch();
            bool wrong = false;
            int countalphabet = 1;
            DisplayScreenHeader("Exercise 1)");
            do
            {
                Console.Write("Type the alphabet: ");
                stopWatchAlphabet.Start();
                string answer = Console.ReadLine().ToLower();
                if (answer == "abcdefghijklmnopqrstuvwxyz") 
                {
                    Correct();
                    stopWatchAlphabet.Stop();
                    wrong = false;

                }
                else
                {
                    wrong = true;
                    Wrong();
                    countalphabet += 1;
                }

            } while (wrong && countalphabet <= 3);

            if (countalphabet > 3)
                Console.WriteLine("You have exceded the limit...");

            
            TimeSpan alphabetTimespan = stopWatchAlphabet.Elapsed; 
            int timeAlphabet = alphabetTimespan.Seconds;

            Console.WriteLine($"Your time was {timeAlphabet} seconds");

            DisplayContinuePrompt();

            alphabetTimes.Add(timeAlphabet);
            alphabetTimes.Add(countalphabet);
            return alphabetTimes;
        }
        #endregion
        #region Introduction Pages
        private static void WouldLikeExample()
        {
            string colorChoice = "";
            Console.Clear();
            Console.WriteLine("First we will start with an example and then we will enter the game...");
            Console.WriteLine();
            Console.WriteLine("EXAMPLE 1:");
            Console.WriteLine();
            do
            {
                Console.Write("What is kayak spelled backwards?: ");
                colorChoice = Console.ReadLine().ToLower();

                if (colorChoice == "kayak")
                {
                    Correct();
                    Console.WriteLine("Now we will start the game!!");
                    DisplayContinuePrompt();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("*************************");
                    Console.WriteLine("Incorrect");
                    Console.WriteLine("Please try again");
                    Console.WriteLine("*************************");
                }
            }
            while (colorChoice != "kayak");
        }

        private static string Introduction()
        { 
            Console.WriteLine("Welcome to \"How Fast Can You Go?\"");
            DisplayContinuePrompt();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\"How Fast Can You Go?\" is an interactive game that will test to see how fast you can react");
            Console.WriteLine();
            Console.WriteLine("The game is not hard but make sure you stay on your toes!!");
            Console.WriteLine();
            Console.Write("Please enter your name: ");
            string username = Console.ReadLine().ToLower();
            Console.WriteLine();

            return username;
        }

        private static bool DoYouWantToKeepGoing()
        {
            string usp;
            bool keepGoing = true;
            bool loop = false;

            do
            {
                Console.Write("Are you ready? [yes , no]: ");
                usp = Console.ReadLine().ToLower();
                if (usp == "yes")
                {
                    loop = false;
                    keepGoing = true;
                }
                else if (usp == "no")
                {
                    loop = false;
                    keepGoing = false;
                }
                else
                {
                    loop = true;
                    Console.WriteLine();
                    Console.WriteLine("Please answer the YES or NO question with a \"yes\" or \"no\" answer!");
                    Console.WriteLine();
                }

            } while (loop);

            return keepGoing;

            /// <summary>
            /// display screen header
            /// </summary>
            
        }
        #endregion
        #region UI
        private static void ExitScreen()
        {
            Console.Clear();
            Console.WriteLine("Thank you for coming and have a fantastic day!!");
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
        }

        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }
        //
        // Upcases the first letter of the word
        // Thank you Sam Allen from www.dotnetperls.com
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        #endregion
        #region Answers
        static void Correct()
        {
            Console.WriteLine();
            Console.WriteLine("Correct!!!!");
            Console.WriteLine();
        }
        static void Wrong()
        {
            Console.WriteLine();
            Console.WriteLine("*************************");
            Console.WriteLine("WRONG, Please try again");
            Console.WriteLine("*************************");
            Console.WriteLine();
        }
        #endregion
        
    }
}
