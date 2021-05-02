using System;
using System.IO;
using System.Text;

namespace Monpoke
{
    public class Program
    {
        public static int Main(string[] args)
        {
            String fileContents;

            if (args == null || args.Length == 0)
            {
                // read from console
                fileContents = Console.In.ReadToEnd();
            }
            else
            {
                // read from arg[0]
                fileContents = File.ReadAllText(args[0]);
            }

            StringBuilder output = new StringBuilder();
            Game game = new Game(output);

            using (var reader = new StringReader(fileContents))
            {
                string line = reader.ReadLine();
                while (game.valid && !game.gameOver && line != null)
                {
                    if (game.battle)
                    {
                        game.TakeTurn();
                    }
                    game.ParseInput(line);
                    line = reader.ReadLine();
                }
            }
            
            if (game.valid && game.gameOver)
            {
                game.output.AppendLine($"{game.currentTeam.Name} is the winner!");
                Console.Write(game.output.ToString());
                return 0;
            }

            return 1;
        }
    }
}
