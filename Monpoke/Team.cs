using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monpoke
{
    class Team
    {
        public string Name { get; set; }
        public List<Monpoke> MonpokeList { get; set; }
        public Monpoke MonpokeActive { get; set; }

        public Game game;

        public Team(string name, Game g)
        {
            Name = name;
            MonpokeList = new List<Monpoke>();
            game = g;
        }

        public void AddMonpoke(Monpoke monpoke)
        {
            MonpokeList.Add(monpoke);
        }
        public bool Attack(Team opponent)
        {
            bool gameOver = false;

            opponent.MonpokeActive.HP -= this.MonpokeActive.AP;
            game.output.AppendLine($"{this.MonpokeActive.Name} attacked {opponent.MonpokeActive.Name} for {this.MonpokeActive.AP} damage!");
            
            if (opponent.MonpokeActive.HP <= 0)
            {
                game.output.AppendLine($"{opponent.MonpokeActive.Name} has been defeated!");
                DefeatMonpoke(opponent);
                gameOver = opponent.Defeated();
            }

            return gameOver;
        }
        public void DefeatMonpoke(Team opponent)
        {
            opponent.MonpokeList.Remove(opponent.MonpokeActive);
            opponent.MonpokeActive = null;
        }

        public bool Defeated()
        {
            return !MonpokeList.Any();
        }
    }
}
