using CanvasGame.Domain;
using System;


namespace CanvasGame
{
    public class Player
    {
        private readonly ICommandParser _parser;
        private readonly ICanvas _canvas;
        public Player(ICommandParser parser, ICanvas canvas)
        {
            _parser = parser;
            _canvas = canvas;
        }

        public void Start()
        {
            Console.WriteLine("Welcom to Canvas Game!");
            printHelpInfo();
            Console.WriteLine("==================================");
            Console.WriteLine("Let's create a canvas first!");
            Console.WriteLine("Enter Command: ");
            var input = Console.ReadLine();
            while (input != "Q" && input != "q")
            {
                try
                {
                    var command = _parser.Parse(input);
                    command.Execute(_canvas);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                Console.WriteLine("Enter Command: ");
                input = Console.ReadLine();
            }

        }

        private void printHelpInfo()
        {
            Console.WriteLine("HELP");
            Console.WriteLine("COMMAND        DESCRIPTION");
            Console.WriteLine("C w h          Create a new canvas of width w and height h");
            Console.WriteLine("L x1 y1 x2 y2  Create a new line from (x1,y1) to (x2,y2)");
            Console.WriteLine("R x1 y1 x2 y2  Create a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2, y2)");
            Console.WriteLine("B x y c        Fill the entire area connected to (x,y) with 'colour' c");
            Console.WriteLine("Q              Quit the player");
        }

    }
}
