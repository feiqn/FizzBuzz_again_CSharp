using System;

namespace FizzBuzz_again {

    class MainClass {

        public static void Main(string[] args) {

            while (true) { // Repeat indefinitely. 
                Console.WriteLine("FizzBuzz... again! >:|");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Enter \"1\" to list FizzBuzz answers.");
                Console.WriteLine("Enter \"2\" to play FizzBuzz yourself!");
                Console.WriteLine("");

                string mainMenu = Console.ReadLine();
                if (mainMenu == "1") {
                    Console.Clear();
                    FizzList();
                }
                else if (mainMenu == "2") {
                    Console.Clear();
                    FizzPlay();
                }

                Console.Clear(); // reset and start over
            } 
        }

        public static void GuessChecker(string UserInput, string Sender, int i) { // Only used by FizzPlay.

            bool CorrectGuess = false;

            switch (Sender) { // To Differentiate here, Sender is always lowercase, UserInput is always CamelCase.
                case "fizz":
                    if (UserInput == "Fizz") {
                        CorrectGuess = true;
                    } else {
                        CorrectGuess = false;
                    }
                    break;
                case "buzz":
                    if (UserInput == "Buzz") {
                        CorrectGuess = true;
                    }
                    else {
                        CorrectGuess = false;
                    }
                    break;
                case "fizzbuzz":
                    if (UserInput == "FizzBuzz") {
                        CorrectGuess = true;
                    }
                    else {
                        CorrectGuess = false;
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", i);
                    Console.ResetColor();
                    return;
            }

            switch (CorrectGuess) { 
                case true:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} {1}", i, UserInput);
                    Console.ResetColor();
                    break;

                case false:
                    Console.Write("Oh no!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", i);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey(); // just waits for the user to press something.
                    return;
            }
        }

        public static void FizzList() { // mainMenu option 1

            Console.WriteLine("Enter where to start, and where to end!");
            Console.WriteLine("Lists FizzBuzz results for [FizzX] through [FizzY]:");
            Console.WriteLine("");

            Int32 FizzX;
            Int32 FizzY;

            Console.Write("FizzX: ");
            string FizzX_raw = Console.ReadLine(); // Get the value to begin counting at from the user.
            bool xCheck = Int32.TryParse(FizzX_raw, out FizzX); // Check that the value of FizzX_raw is a valid Int32, and not "wieners".

            if (xCheck) { // FizzX is a valid int.
                Console.WriteLine("FizzY: "); 
                string FizzY_raw = Console.ReadLine(); // Get the value to count up to.
                bool yCheck = Int32.TryParse(FizzY_raw, out FizzY); // Check the value of FizzY_raw the same way. 

                if (yCheck) { // FizzY is valid.

                    if (FizzY == FizzX) { // Edge case awareness day.

                        Console.Clear();
                        Console.WriteLine("Please input unique numbers."); 
                        Console.WriteLine("");
                        Console.WriteLine("");
                        FizzList();

                    } else if (FizzX > FizzY) { // Make sure numbers get passed in from smallest to largest.
                        Console.Clear();
                        FizzBuzz(FizzY, FizzX);
                    } else {
                        Console.Clear();
                        FizzBuzz(FizzX, FizzY); // And finally, if all is well, we should end up here.
                    }
                } else {
                    Console.WriteLine("Error at FizzY_raw");
                    Console.WriteLine("");
                    FizzList();
                }
            } else {
                Console.WriteLine("Error at FizzX_raw");
                Console.WriteLine("");
                FizzList();
            }
        }

        public static void FizzPlay() { // mainMenu option 2

            Console.WriteLine("Get ready to test your FizzBuzz skills!");
            Console.WriteLine();
            Console.WriteLine("What number would you like to begin on?");
            Console.WriteLine("Enter \"help\" for instructions on how to play!");
            Console.WriteLine();

            string FizzX_raw = Console.ReadLine(); 
            bool xCheck = Int32.TryParse(FizzX_raw, out int FizzX); // Check that the value of FizzX_raw is a valid Int32.

            if (xCheck) {
                Console.Clear();
                FizzBuzz(FizzX, Int32.MaxValue, GameTime: true);

            } else {
                FizzX_raw.ToLower(); // Cast string to all lower case so it's easier to check against.

                if (FizzX_raw == "help") { 

                    Console.WriteLine("The rules are simple!");
                    Console.WriteLine("Press \"f\" if the number is divisible by 3");
                    Console.WriteLine("Press \"b\" if the number is divisible by 5");
                    Console.WriteLine("Press \"x\" if the number is divisible by BOTH 3 and 5");
                    Console.WriteLine("Press the space bar to pass if none of the above are true.");
                    Console.ReadLine();
                    Console.Clear();
                    FizzPlay();

                } else { // Typing anything other than a parseable Int32 or the string "help" just resets the function.
                    Console.Clear();
                    FizzPlay();
                }

            } 
        }

        public static void FizzBuzz(int FizzX, int FizzY, bool GameTime = false) { // Takes X, Y, and an optional parameter for FizzPlay.

            /* We can now safely assume:
             * FizzX && FizzY are proper ints,
             * FizzX is smaller than FizzY,
             * making the actual FizzBuzz bit 
             * rather trivial.
             */

            int x = FizzX;
            int y = FizzY;
            string UserInput = null; 

            for (int i = x; i <= y; i++) {

                if (GameTime) { // Check if game functionality should run, or just list results.

                    Console.WriteLine("Press your answer for: {0} ... [space = Pass, f = Fizz, b = Buzz, x = FizzBuzz] ", i);
                    ConsoleKeyInfo GameKey = Console.ReadKey(); // Record key input.

                    switch (GameKey.Key) {
                            
                        case ConsoleKey.X:
                            UserInput = "FizzBuzz";
                            break;
                        case ConsoleKey.F:
                            UserInput = "Fizz";
                            break;
                        case ConsoleKey.B:
                            UserInput = "Buzz";
                            break;
                        default:
                            UserInput = "pass";
                            break;
                    }
                }

                /*
                 * There are fundamentally better ways to actually impliment FizzBuzz in terms of performance and readability.
                 * I may come back some day and fundamentally rebuild this section. The only difficult at this stage is intigation
                 * with FizzPlay(), which still isn't hard, just tedious. 
                 */

                if (i != 0 && i % 3 == 0 && i % 5 == 0) { // "i" is divisible by both 3 and 5. "fizzbuzz"

                    if (GameTime) {
                        GuessChecker(UserInput, "fizzbuzz", i);
                    } else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("FizzBuzz!");
                        Console.ResetColor();
                    }
                }
                else if (i % 3 == 0 && i % 5 != 0) { // "i" is divisible by 3, but not 5. "fizz"

                    if (GameTime) {
                        GuessChecker(UserInput, "fizz", i);
                    } else {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Fizz!");
                        Console.ResetColor();
                    }
                }
                else if (i % 3 != 0 && i % 5 == 0) { // "i" is divisible by 5, but not 3. "buzz"

                    if (GameTime) {
                        GuessChecker(UserInput, "buzz", i);
                    } else {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Buzz!");
                        Console.ResetColor();
                    }
                }
                else { // Just print.

                    if (GameTime) {
                        GuessChecker(UserInput, "pass", i); // Ultimately 
                    } else {
                        Console.WriteLine(i);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
} // Thanks for playing! :)