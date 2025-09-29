using System;

class Program
{
    static void Main(string[] args)
    {
        int playerScore = 0;
        int computerScore = 0;
        int WinningScore = 3;

        Random rnd = new Random();

        Console.WriteLine("Velkommen til Rock-Paper-Scissors-Spock-Lizard!");
        Console.WriteLine("Første til " + WinningScore + " point vinder.\n");

        while (playerScore < WinningScore && computerScore < WinningScore)
        {
            Console.WriteLine("Vælg en form:");
            Console.WriteLine("0 - Rock");
            Console.WriteLine("1 - Paper");
            Console.WriteLine("2 - Scissors");
            Console.WriteLine("3 - Spock");
            Console.WriteLine("4 - Lizard");

            int playerChoice = Convert.ToInt32(Console.ReadLine());
            int computerChoice = rnd.Next(0, 5);

            Console.WriteLine("Du valgte: " + playerChoice);
            Console.WriteLine("Computeren valgte: " + computerChoice);
            
            if (playerChoice == computerChoice)
            {
                Console.WriteLine("Uafgjort!");
            }
            else if ((playerChoice == 0 && (computerChoice == 2 || computerChoice == 4)) ||
                     (playerChoice == 1 && (computerChoice == 0 || computerChoice == 3)) ||
                     (playerChoice == 2 && (computerChoice == 1 || computerChoice == 4)) ||
                     (playerChoice == 3 && (computerChoice == 0 || computerChoice == 2)) ||
                     (playerChoice == 4 && (computerChoice == 1 || computerChoice == 3)))
            {
                Console.WriteLine("Du vandt runden!");
                playerScore++;
            }
            else
            {
                Console.WriteLine("Computeren vandt runden!");
                computerScore++;
            }

            Console.WriteLine("Stillingen er: Du " + playerScore + " - " + computerScore + " Computer\n");
        }

        if (playerScore == WinningScore)
            Console.WriteLine("Tillykke! Du har vundet spillet!");
        else
            Console.WriteLine("Computeren vandt spillet!");
    }
}
