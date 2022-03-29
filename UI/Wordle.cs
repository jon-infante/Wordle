namespace UI;

public class Wordle{

    public void Start(){
        bool exit = false;
        string word = GetWord();
        //Populating dictionary of all the letters in word for easy lookup
        Dictionary<char, int> wordDict = new Dictionary<char, int>();
        int placement = 0;
        foreach(char c in word){
            wordDict[c] = placement;
            placement++;
        }        

        //Populate alphabet dictionary
        Dictionary<char, int> alphabetChart = new Dictionary<char,int>();
        const string letters = "abcdefghijklmnopqrstuvwxyz";
        foreach(char l in letters){
            alphabetChart[l] = 0;
        }
        //Create empty rows
        List<string> allRows = new List<string>(){
            "", "", "", "", "", ""
        };

        int count = 0;               
        while (!exit){
            while(count<6){
                //Assigning each row
                string row1 = allRows[0];
                string row2 = allRows[1];
                string row3 = allRows[2];
                string row4 = allRows[3];
                string row5 = allRows[4];
                string row6 = allRows[5];
                //UI
                ColorWrite.wc("\n=======================[Wordle]======================", ConsoleColor.DarkCyan);
                Console.WriteLine("\t           Guess a word!\n");
                WriteRow(row1, word, wordDict);
                WriteRow(row2, word, wordDict);
                WriteRow(row3, word, wordDict);
                WriteRow(row4, word, wordDict);
                WriteRow(row5, word, wordDict);
                WriteRow(row6, word, wordDict);
                Console.WriteLine("");
                WriteAlphabet('a', 'z', alphabetChart);
                Console.WriteLine("\n===================================================\n");
                //User input
                reEnter:
                string? input = Console.ReadLine();
                if(input?.Length != 5){
                    Console.WriteLine("\nPlease enter a word that has exactly 5 letters!");
                    goto reEnter;
                }
                input = input.ToLower();
                //If we find don't find a letter matching in the word, we gray out a the letter
                foreach(char c in input){
                    if (!wordDict.ContainsKey(c)){
                        alphabetChart[c] = 1;
                    }
                }
                //Assigns the row with the user's input
                allRows[count] = input;
                count++;
                //The user has guessed the correct word
                if(input == word){
                    exit = true;
                    Console.WriteLine("");
                    Console.WriteLine($"Congratulations! You guess the word in {count} guesses!");
                    break;
                }
            }
            //All guessed have been made
            if (count>5){
                Console.WriteLine("");
                Console.WriteLine($"Out of guesses! The word was {word}");
                exit = true;
                }
            exit = true;
        }
    }

    //Gets random word for the game
    public string GetWord(){
        List<string> words = new List<string>(){
            "bacon", "trick", "cream", "about", "piano", "house", "alone", "above", "mouse", "cried", "media",
            "radio", "voice", "value", "ocean", "alive", "image", "olive", "quiet", "video", "cause", "sauce",
            "juice", "noise", "abuse", "opera", "naive", "azure", "other", "faith", "clown", "towel", "shelf", 
            "shine", "eager", "earth", "solid", "space", "label", "vague", "clean", "eagle", "fault", "frost",
            "medic", "movie", "siren", "syrup", "turbo", "story", "great"
        };
        Random rnd = new Random();
        int ranNum = rnd.Next(words.Count());

        string selectedWord = words[ranNum];

        return selectedWord;
    }

    public void WriteRow(string row, string word, Dictionary<char, int> wordDict){
        //If we have an empty row that hasn't been guessed yet
        if(row == ""){
            Console.WriteLine("\t        [ ] [ ] [ ] [ ] [ ]");
        }
        else{
            Console.WriteLine("");
            Console.Write("\t      ");
            for (int i = 0; i < 5; i++){
                //If the letter matches exactly in the right position
                char letterKeyInWord = wordDict.FirstOrDefault(x => x.Value == i).Key;
                if(row[i] == letterKeyInWord){
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("   ");
                    Console.Write(Char.ToUpper(row[i]));
                }
                //If the letter is somewhere in the word
                else if(wordDict.ContainsKey(row[i])){
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("   ");
                    Console.Write(Char.ToUpper(row[i]));
                }
                //No letter found in the word
                else{
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("   ");
                    Console.Write(Char.ToUpper(row[i]));
                }
             }
             Console.WriteLine("");
             Console.ResetColor();    
            }
        }
    
    public void WriteAlphabet(char start, char stop, Dictionary<char, int> alphaDict){
        //int cast converts char to numeric value
        int startingNum = (int)start;
        int endingNum = (int)stop + 1;
        char charToWrite = start;
        while(startingNum < endingNum){
            //If the character hasn't been guessed yet
            if (alphaDict[charToWrite] == 0){
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{Char.ToUpper(charToWrite)} ");
            }
            else{
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{Char.ToUpper(charToWrite)} ");
            }
            Console.ResetColor();  
            startingNum = (int)(charToWrite) + 1;
            charToWrite = (char)(startingNum);
        }
    }
}
