namespace UI;

public class MainMenu {

    public void Start(){
        Console.WriteLine("\nWelcome to Wordle!");
        bool exit = false;
        while(!exit){
            ColorWrite.wc("\n=====================[Main Menu]====================", ConsoleColor.DarkCyan);
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[1] Start a new game");
            ColorWrite.wc("\n\t        Enter [x] to [Exit]", ConsoleColor.DarkRed);
            Console.WriteLine("===================================================");

            string? input = Console.ReadLine();

            switch(input){
                case "1":
                    Wordle w = new Wordle();
                    w.Start();
                    break;

                case "x":
                    exit = true;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:
                    Console.WriteLine("\nPlease enter a command I can understand!");
                    break;


            }
        }
    }
}