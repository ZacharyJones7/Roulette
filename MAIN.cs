using System;
using System.Linq;
namespace RouletteGame
{
    //TO DO: winAnimation and checkMonies methods
    public class Chances
    {
      public int cornerNumber;
      public string dozen;
      public string evenOrOdd;
      public string lowOrHigh;
      public string column;
      public int number;
      public string redOrBlack;
      public int street;
      public int rangeOfStreet;
      public int splitNumber1;
      public int splitNumber2 = 0;
        // Above are the instantiations of the values needed for each game to run 
      public int winnings = 0;
      public int bet = 0;
      public bool win = false;
      public int[] red = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
      public int[] black = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
      public int[] green = { 0, 37 };
      public int[] column1 = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
      public int[] column2 = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
      public int[] column3 = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
      public int[] userCorner = new int[4];
        //These are the arrays needed for each game. Originally they were inserted into each method, but I moved them because that cuts out hundereds
        // of not needed lines of code. 
        //This will be implemented by inheretance 
    }
    public class WheelRoll
    {
        public static int Roll() //I don't like how thi is laid out. I'm going to fix this one day. Maybe. 
        {
            int[] red = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            int[] black = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            int[] green = { 0, 37 };
            int[] wheel = new int[38];
            Random rand = new Random();
            int roll = rand.Next(wheel.Length);
            if (green.Contains(roll))
            {
                if (roll == 37)
                {
                    roll = 00;
                }
            }
            return roll;
        }
    }
    public class Roulette : WheelRoll
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            bool Start;
            string doOver;
            while (Start = true && User.monies > 0)
            {
                Console.WriteLine();
                Console.WriteLine("So glad you came into the Ripoffski Casino. Select your game.");
                Console.WriteLine("1: Number Bet \n2: Evens or Odds \n3: Reds or Blacks \n4: Lows or Highs \n5: Dozens \n6: Columns \n7: Street \n8: 6 Numbers \n9: Split \n10: Corner");
                Console.Write("Pick a number! \n ");
                int gameChoice = Int32.Parse(Console.ReadLine());
                if (gameChoice > 10)
                {
                    Console.WriteLine("That's not a thing. ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (gameChoice == 1)
                {
                    Number number = new Number();
                    number.NumbersBet(Roll());
                }
                if (gameChoice == 2)
                {
                    EvenOrOdd evenorodd = new EvenOrOdd();
                    evenorodd.EvenOrOddBet(Roll());
                }
                if (gameChoice == 3)
                {
                    RedOrBlack redorblack = new RedOrBlack();
                    redorblack.RedOrBlackBet(Roll());
                }
                if (gameChoice == 4)
                {
                    LowsHighs loworhigh = new LowsHighs();
                    loworhigh.LowOrHighBet(Roll());
                }
                if (gameChoice == 5)
                {
                    Dozens dozens = new Dozens();
                    dozens.DozensBet(Roll());
                }
                if (gameChoice == 6)
                {
                    Columns columns = new Columns();
                    columns.ColumnBet(Roll());
                }
                if (gameChoice == 7)
                {
                    Street street = new Street();
                    street.StreetBet(Roll());
                }
                if (gameChoice == 8)
                {
                    SixNumbers sixNumbers = new SixNumbers();
                    sixNumbers.SixNumberBet(Roll());
                }
                if (gameChoice == 9)
                {
                    Split split = new Split();
                    split.SplitBet(Roll());
                }
                if (gameChoice == 10)
                {
                    Corner corner = new Corner();
                    corner.CornerBet(Roll());
                }
                if (User.monies == 0)
                {
                    Console.WriteLine("Hahahahahaahaha, you lost all your money! Go away!");
                    Start = false;
                }
                if (User.monies > 0)
                {
                    Console.Write(" Wanna try that again? (yes/no): ");
                    doOver = Console.ReadLine();
                    if (doOver == "yes")
                    {
                        Start = true;
                        Random random = new Random();
                        int phrase = random.Next(1);
                        if (phrase == 1)
                        {
                            Console.WriteLine("You need professional help. Please. Your house is in foreclosure.");
                            Console.Clear(); 
                        }
                    }
                    else if (doOver == "no")
                    {
                        Start = false;
                        Console.WriteLine("Fine, you don't have much money anyway. Scardycat.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
  
    }
    public class Corner : Chances
    {
        public int CornerBet(int roll)
        {

            Console.Write("You are making a corner bet. Select the number that will be located at the bottom left corner of your square: ");
            cornerNumber = Int32.Parse(Console.ReadLine());
            if (column1.Contains(cornerNumber) || column2.Contains(cornerNumber))
            {
                userCorner[0] = cornerNumber;
                userCorner[1] = cornerNumber + 1;
                userCorner[2] = cornerNumber + 3;
                userCorner[3] = cornerNumber + 4;
            }

            if (column3.Contains(cornerNumber))
            {
                userCorner[0] = cornerNumber;
                userCorner[1] = cornerNumber - 1;
                userCorner[2] = cornerNumber + 3;
                userCorner[3] = cornerNumber + 2;
            }

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            //checkMonies(!bet>User.monies);
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;
                if (red.Contains(roll))
                {
                    foreach (int i in userCorner)
                    {
                        if (roll == i)
                        {
                            win = true;
                            break;
                        }
                        if (roll != i)
                        {
                            win = false;
                        }
                    }
                    if (win == true)
                    {
                        winnings = 8 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        //winAnimation();
                        Console.WriteLine("YOU WIN");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White; 
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (win == false)
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (black.Contains(roll))
                {
                    foreach (int i in userCorner)
                    {
                        if (roll == i)
                        {
                            win = true;
                            break;
                        }
                        if (roll != i)
                        {
                            win = false;
                        }
                    }
                    if (win == true)
                    {
                        winnings = 8 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (win == false)
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (roll == 0 || roll == 00)
                {
                    Console.WriteLine($"The roll was {roll} green.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class Dozens : Chances
    {

        public int DozensBet(int roll)
        {
            Console.Write("You are making a dozens bet. The board has been split into 3 (1-12), (13-24), and (25-36). To select a specific dozen numbers please enter first, second, or third as they relate to how the board has been divided: ");
            dozen = Console.ReadLine();
            dozen.ToLower();

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;
                if (red.Contains(roll))
                {
                    if (roll <= 12 && roll >= 1 && dozen == "first")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll <= 12 && roll >= 1 && dozen != "first")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (roll >= 13 && roll <= 24 && dozen == "second")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll >= 13 && roll <= 24 && dozen != "second")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (roll >= 25 && roll <= 36 && dozen == "third")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll >= 25 && roll <= 36 && dozen != "third")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (black.Contains(roll))
                {
                    if (roll <= 12 && roll >= 1 && dozen == "first")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll <= 12 && roll >= 1 && dozen != "first")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (roll >= 13 && roll <= 24 && dozen == "second")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll >= 13 && roll <= 24 && dozen != "second")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (roll >= 25 && roll <= 36 && dozen == "third")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll >= 25 && roll <= 36 && dozen != "third")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (roll == 0 || roll == 00)
                {
                    Console.WriteLine($"The roll was {roll} green.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class EvenOrOdd : Chances
    {
        public int EvenOrOddBet(int roll)
        {
            Console.Write("Evens or odds? :  ");
            evenOrOdd = Console.ReadLine();
            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;

                if (red.Contains(roll))
                {
                    Console.WriteLine($"The roll was {roll} red.");
                }
                if (black.Contains(roll))
                {
                    Console.WriteLine($"The roll was {roll} black.");
                }
                if (green.Contains(roll))
                {
                    if (roll == 00)
                    {
                        Console.WriteLine($"The roll was {roll} green.");
                    }
                    else
                    {
                        Console.WriteLine($"The roll was {roll} green.");
                    }
                }
                if (roll % 2 == 0 && evenOrOdd == "even")
                {
                    winnings = bet * 2;
                    User.monies = winnings + User.monies;
                    Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                }
                else if (roll % 2 == 1 && evenOrOdd == "odd")
                {
                    winnings = bet * 2;
                    User.monies = winnings + User.monies;
                    Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                }
                else
                {
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class LowsHighs : Chances
    {
        public int LowOrHighBet(int roll)
        {
            Console.Write("Would you like to bet on lows (1-18) or highs (19-36)? Please enter low/high: ");
            lowOrHigh = Console.ReadLine();

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                if (red.Contains(roll))
                {
                    User.monies = User.monies - bet;
                    if (roll <= 18 && roll >= 1 && lowOrHigh == "low")
                    {
                        winnings = 2 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll <= 18 && roll >= 1 && lowOrHigh != "low")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (roll >= 19 && lowOrHigh == "high")
                    {
                        winnings = 2 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll >= 19 && lowOrHigh != "high")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (roll == 0 || roll == 00)
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (black.Contains(roll))
                {
                    User.monies = User.monies - bet;
                    if (roll <= 18 && roll >= 1 && lowOrHigh == "low")
                    {
                        winnings = 2 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll <= 18 && roll >= 1 && lowOrHigh != "low")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (roll >= 19 && lowOrHigh == "high")
                    {
                        winnings = 2 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll >= 19 && lowOrHigh != "high")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (green.Contains(roll))
                {
                    if (roll == 0 || roll == 00)
                    {
                        Console.WriteLine($"The roll was {roll} green.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
            }
            return User.monies;
        }
    }
    public class Columns : Chances
    {
        public int ColumnBet(int roll)
        {
            Console.Write("Street bet time. The board has been split into 12 streets. enter the first number of the street: ");
            column = Console.ReadLine();
            column.ToLower();

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You don't have that much cash, quit playin' around or we'll have to throw you out!");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;
                if (red.Contains(roll))
                {
                    if (column1.Contains(roll) && column == "first")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (column1.Contains(roll) && column != "first")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (column2.Contains(roll) && column == "second")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (column2.Contains(roll) && column != "second")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (column3.Contains(roll) && column == "third")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (column2.Contains(roll) && column != "third")
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (black.Contains(roll))
                {
                    if (column1.Contains(roll) && column == "first")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (column1.Contains(roll) && column != "first")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (column2.Contains(roll) && column == "second")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (column2.Contains(roll) && column != "second")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                    if (column3.Contains(roll) && column == "third")
                    {
                        winnings = 3 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (column3.Contains(roll) && column != "third")
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (roll == 0 || roll == 00)
                {
                    Console.WriteLine($"The roll was {roll} green.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class Number : Chances
    {
        public int NumbersBet(int roll)
        {
            Console.Write("Please enter the number you would like to bet on up to 36: ");
            number = Int32.Parse(Console.ReadLine());
            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new Exception("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;

                if (red.Contains(roll))
                {
                    Console.WriteLine($"The roll was {roll} red.");
                }
                if (black.Contains(roll))
                {
                    Console.WriteLine($"The roll was {roll} black.");
                }
                if (green.Contains(roll))
                {
                    if (roll == 00)
                    {
                        Console.WriteLine($"The roll was {roll} green.");
                    }
                    else
                    {
                        Console.WriteLine($"The roll was {roll} green.");
                    }
                }
                if (roll == number)
                {
                    winnings = 35 * bet;
                    User.monies = winnings + User.monies;
                    Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                }
                if (roll != number)
                {
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class RedOrBlack : Chances
    {
        public int RedOrBlackBet(int roll)
        {
            Console.Write("Would you like to bet on red or black: ");
            redOrBlack = Console.ReadLine();
            redOrBlack.ToLower();

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;

                if (red.Contains(roll) && redOrBlack == "red")
                {
                    winnings = 2 * bet;
                    User.monies = winnings + User.monies;
                    Console.WriteLine($"The roll was {roll} red.");
                    Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                }
                if (red.Contains(roll) && redOrBlack != "red")
                {
                    Console.WriteLine($"The roll was {roll} red.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
                if (black.Contains(roll) && redOrBlack == "black")
                {
                    winnings = 2 * bet;
                    User.monies = winnings + User.monies;
                    Console.WriteLine($"The roll was {roll} black.");
                    Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                }
                if (black.Contains(roll) && redOrBlack != "black")
                {
                    Console.WriteLine($"The roll was {roll} black.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
                if (roll == 0 || roll == 00)
                {
                    Console.WriteLine($"The roll was {roll} green.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class SixNumbers : Chances
    {
        public int SixNumberBet(int roll)
        {
            Console.Write("You are making a six number bet. The board has been split into 6 rows. To select a specific two rows of numbers please enter the lowest number in the street you wish to choose: ");
            street = Int32.Parse(Console.ReadLine());
            rangeOfStreet = street + 5;

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;
                if (red.Contains(roll))
                {
                    if (roll <= rangeOfStreet && roll >= 1)
                    {
                        winnings = 6 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll > rangeOfStreet)
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (black.Contains(roll))
                {
                    if (roll <= rangeOfStreet && roll >= 1)
                    {
                        winnings = 6 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll > rangeOfStreet)
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (roll == 0 || roll == 00)
                {
                    Console.WriteLine($"The roll was {roll} green.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class Split : Chances
    {
        public int SplitBet(int roll)
        {
            Console.Write("You are making a split bet. Select your first number: ");
            splitNumber1 = Int32.Parse(Console.ReadLine());
            if (column1.Contains(splitNumber1))
            {
                if (splitNumber1 == 1)
                {
                    Console.Write("Please enter the number you wish to split with (2, or 4): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
                if (splitNumber1 == 34)
                {
                    Console.Write("Please enter the number you wish to split with (31, or 35): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
                if (splitNumber1 != 1 && splitNumber1 != 34)
                {
                    Console.Write($"Please enter the number you wish to split with ({splitNumber1 - 3}, {splitNumber1 + 1}, or {splitNumber1 + 3}): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
            }
            if (column2.Contains(splitNumber1))
            {
                if (splitNumber1 == 2)
                {
                    Console.Write("Please enter the number you wish to split with (1, 3, or 5): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
                if (splitNumber1 == 35)
                {
                    Console.Write("Please enter the number you wish to split with (32, 34, 36): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
                if (splitNumber1 != 2 && splitNumber1 != 35)
                {
                    Console.Write($"Please enter the number you wish to split with ({splitNumber1 - 3}, {splitNumber1 - 1}, {splitNumber1 + 1}, or {splitNumber1 + 3}): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
            }
            if (column3.Contains(splitNumber1))
            {
                if (splitNumber1 == 3)
                {
                    Console.Write("Please enter the number you wish to split with (2, or 6): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
                if (splitNumber1 == 36)
                {
                    Console.Write("Please enter the number you wish to split with (33, or 35): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
                if (splitNumber1 != 3 && splitNumber1 != 36)
                {
                    Console.Write($"Please enter the number you wish to split with ({splitNumber1 - 3}, {splitNumber1 - 1}, or {splitNumber1 + 3}): ");
                    splitNumber2 = Int32.Parse(Console.ReadLine());
                }
            }

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;
                if (red.Contains(roll))
                {
                    if (roll == splitNumber1 || roll == splitNumber2)
                    {
                        winnings = 17 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll != splitNumber1 || roll != splitNumber2)
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (black.Contains(roll))
                {
                    if (roll == splitNumber1 || roll == splitNumber2)
                    {
                        winnings = 17 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll != splitNumber1 || roll != splitNumber2)
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (roll == 0 || roll == 00)
                {
                    Console.WriteLine($"The roll was {roll} green.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public class Street : Chances
    {
        public int StreetBet(int roll)
        {
            Console.Write("You are making a street bet. The board has been split into 12 rows. To select a specific row of numbers please enter the lowest number in the street you wish to choose: ");
            street = Int32.Parse(Console.ReadLine());
            rangeOfStreet = street + 2;

            Console.Write($"You have ${User.monies}. How much are you puttin' down? : ");
            bet = Int32.Parse(Console.ReadLine());
            if (bet > User.monies)
            {
                throw new System.IndexOutOfRangeException("You have no more monies.");
            }
            if (bet <= User.monies)
            {
                User.monies = User.monies - bet;
                if (red.Contains(roll))
                {
                    if (roll <= rangeOfStreet && roll >= 1)
                    {
                        winnings = 11 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll > rangeOfStreet)
                    {
                        Console.WriteLine($"The roll was {roll} red.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (black.Contains(roll))
                {
                    if (roll <= rangeOfStreet && roll >= 1)
                    {
                        winnings = 11 * bet;
                        User.monies = winnings + User.monies;
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You won ${winnings}. You now have ${User.monies}.");
                    }
                    if (roll > rangeOfStreet)
                    {
                        Console.WriteLine($"The roll was {roll} black.");
                        Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                    }
                }
                if (roll == 0 || roll == 00)
                {
                    Console.WriteLine($"The roll was {roll} green.");
                    Console.WriteLine($"You lost ${bet}. You now have ${User.monies}.");
                }
            }
            return User.monies;
        }
    }
    public static class User
    {
        public static int monies = 100;
    }
}



//I realized too late that the assignment wasn't asking for a game, but the logic is in here. I referenced an old student's code to get an Idea of how to start, and I decided that many of their loops
//were a good way of going about this. However, I cut out maybe a few hundred lines of code that really didn't need to be in here. 
//