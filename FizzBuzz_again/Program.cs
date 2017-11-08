using System;

namespace FizzBuzz_again {

    class MainClass {

        public static void Main(string[] args) {

            while (true) {
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


        public static void FizzList() { // mainMenu option 1

            Console.WriteLine("Enter FizzX and FizzY to begin!");
            Console.WriteLine("List FizzBuzz results for [FizzX] through [Fizzy]");
            Console.WriteLine("");

            Int32 FizzX;
            Int32 FizzY;

            Console.Write("FizzX: ");
            string FizzX_raw = Console.ReadLine(); // Get the value to begin counting at from the user.
            bool xCheck = Int32.TryParse(FizzX_raw, out FizzX); // check that the value of FizzX_raw is a valid int, and not "wieners".

            if (xCheck) { // FizzX is a valid int.
                Console.WriteLine("FizzY: "); 
                string FizzY_raw = Console.ReadLine(); // get the value to count up to.
                bool yCheck = Int32.TryParse(FizzY_raw, out FizzY); // check FizzY_raw the same way. 

                if (yCheck) { // FizzY is valid.

                    if (FizzX < 0 || FizzY < 0) { // check for negatives. add this functionality later.
                        Console.WriteLine("Negative numbers not supported yet..."); //TODO negatives.
                        Console.WriteLine("");
                        Console.WriteLine("");
                        FizzList();
                    }

                    if (FizzY == FizzX) { // some people are wankers so be sure to check for cheeky shite like this...

                        Console.Clear();
                        Console.WriteLine("I know what you did."); // ...and say something cheeky back.
                        Console.WriteLine("");
                        Console.WriteLine("");
                        FizzList();

                    } else if (FizzX > FizzY) { // maybe you did this by mistake? Maybe you're trying to break things.
                        Console.Clear();
                        FizzBuzz(FizzY, FizzX); // Show you, I will. Just pass 'em in backwards.
                    } else {
                        Console.Clear();
                        FizzBuzz(FizzX, FizzY); // and finally, if the user actually followed the rules...
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

            string FizzX_raw = Console.ReadLine(); 
            bool xCheck = Int32.TryParse(FizzX_raw, out int FizzX); // check that the value of FizzX_raw is a valid int.

            if (xCheck) {
                Console.Clear();
                FizzBuzz(FizzX, Int32.MaxValue, GameTime: true);

            } else {
                FizzX_raw.ToLower(); // case insensitive check

                if (FizzX_raw == "help") { 
                    
                    //TODO: print controls: space = pass, F = Fizz!, B = Buzz, and X for FizzBuzz.

                } else { // typing anything other than a parseable int or the string "help" just resets the function.
                    Console.Clear();
                    FizzPlay();
                }

            } 
        }

        public static void FizzBuzz(int FizzX, int FizzY, bool GameTime = false) { // takes X, Y, and an optional parameter for FizzPlay.

            /* we can now safely assume:
             * FizzX && FizzY are proper ints,
             * FizzX is smaller than FizzY,
             * Neither FizzX nor FizzY are negative 
             * -- (we'll add this functionality later)
             * making the actual FizzBuzz bit 
             * rather trivial.
             */

            int x = FizzX;
            int y = FizzY;
            string userInput = null; // typeface consistency is important kids
            bool CorrectGuess;

            for (int i = x; i <= y; i++) {

                if (GameTime) { // check if game functionality should run, or just list results.

                    Console.WriteLine("Press your answer for: {0} [f = Fizz, b = Buzz, x = FizzBuzz] ", i);
                    ConsoleKeyInfo GameKey = Console.ReadKey(); // have user press a key

                    switch (GameKey.Key) {
                            
                        case ConsoleKey.X:
                            userInput = "fizzbuzz";
                            break;
                        case ConsoleKey.F:
                            userInput = "fizz";
                            break;
                        case ConsoleKey.B:
                            userInput = "buzz";
                            break;
                        default:
                            userInput = "pass";
                            break;
                    }
                }

                if (i != 0 && i % 3 == 0 && i % 5 == 0) { // "i" is divisible by both 3 and 5.

                    if (GameTime) {
                        switch (userInput) { 
                            case "fizzbuzz": // guessed correctly
                                CorrectGuess = true;
                                break;
                            default:
                                CorrectGuess = false;
                                break;
                        }

                        switch (CorrectGuess) { // this could arguably be a separate function CorrectGuess(), but this way is easier for now. Potential area for future optimization.
                            case true:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("{0} FizzBuzz!", i);
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

                    } else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("FizzBuzz!");
                        Console.ResetColor();
                    }
                }
                else if (i % 3 == 0 && i % 5 != 0) { // "i" is divisible by 3, but not 5.

                    if (GameTime) {
                        switch (userInput) {
                            case "fizz": // guessed correctly
                                CorrectGuess = true;
                                break;
                            default:
                                CorrectGuess = false;
                                break;
                        }

                        switch (CorrectGuess) {
                            case true:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("{0} Fizz!", i);
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
                    } else {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Fizz!");
                        Console.ResetColor();
                    }
                }
                else if (i % 3 != 0 && i % 5 == 0) { // "i" is divisible by 5, but not 3.

                    if (GameTime) {
                        switch (userInput) {
                            case "buzz": // guessed correctly
                                CorrectGuess = true;
                                break;
                            default:
                                CorrectGuess = false;
                                break;
                        }

                        switch (CorrectGuess) {
                            case true:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("{0} Buzz!", i);
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
                    } else {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Buzz!");
                        Console.ResetColor();
                    }
                }
                else { // just print 

                    if (GameTime) {
                        switch (userInput) {
                            case "pass": // guessed correctly
                                CorrectGuess = true;
                                break;

                            default:
                                CorrectGuess = false;
                                break;
                        }

                        switch (CorrectGuess) {
                            case true:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("{0}", i);
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

                    } else {
                        Console.WriteLine(i);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey(); // just waits for the user to press something.
            Console.Clear();
        }
    }
} // Thanks for playing! :)