using System.Text.RegularExpressions;

namespace UI;
/// <summary>
/// Able to write default and another color in one line. 
/// Uses regex to detect strings between chars '[' and ']'
/// </summary>
public static class ColorWrite {
    public static void wc(string message, ConsoleColor color){
        var pieces = Regex.Split(message, @"(\[[^\]]*\])");

        for(int i=0;i<pieces.Length;i++)
        {
            string piece = pieces[i];
            
            if (piece.StartsWith("[") && piece.EndsWith("]"))
            {
                Console.ForegroundColor = color;
                piece = piece.Substring(1,piece.Length-2);          
            }
            
            Console.Write(piece);
            Console.ResetColor();
        }
        
        Console.WriteLine();
    }
}