using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Monpoke
{
    class Game
    {
        public StringBuilder output;
        public Team currentTeam;
        public Team nextTeam;

        public bool valid = true;

        public bool battle = false;

        public bool gameOver = false;

        public Dictionary<String, Team> teams = new Dictionary<string, Team>();
        public enum Create
        {
            TEAM_ID = 1,
            MONPOKE_ID = 2,
            HP = 3,
            AP = 4
        };
        public enum Choose
        {
            MONPOKE_ID = 1
        };

        // create <team-id> <monpoke-id> <hp> <attack>
        // attack
        // ichooseyou <monpoke-id>
        public Game (StringBuilder sb)
        {
            output = sb;
        }

        public void ParseInput(String input)
        {
            String split = " ";

            String[] inputArgs = Regex.Split(input, split);
            String command = inputArgs[0];
            switch (command)
            {
                case "CREATE":
                    commandCreate(inputArgs[(int)Create.TEAM_ID],
                        inputArgs[(int)Create.MONPOKE_ID],
                        inputArgs[(int)Create.HP],
                        inputArgs[(int)Create.AP]);
                    break;
                case "ICHOOSEYOU":
                    commandChoose(inputArgs[(int)Choose.MONPOKE_ID]);
                    battle = true;
                    break;
                case "ATTACK":
                    commandAttack();
                    break;
            }

        }

        private void commandAttack()
        {
            validateAttack();
            if (valid)
            {
                gameOver = currentTeam.Attack(nextTeam);
            }
            
        }

        private void validateAttack()
        {
            if (!battle || currentTeam.MonpokeActive == null || nextTeam.MonpokeActive == null)
            {
                valid = false;
            }
        }

        private void commandChoose(string monpokeID)
        {
            validateGame();
            if (valid)
            {
                Monpoke monpoke = currentTeam.MonpokeList.FirstOrDefault(monpoke => string.Equals(monpoke.Name, monpokeID, StringComparison.OrdinalIgnoreCase));
                if (monpoke != null)
                {
                    currentTeam.MonpokeActive = monpoke;
                    output.AppendLine($"{monpoke.Name} has entered the battle!");
                }
                else
                {
                    valid = false;
                }
            }
        }

        public void validateGame()
        {
            if (teams.Count != 2) valid = false;
        }

        private void commandCreate(string teamID, string monpokeID, string HP, string AP)
        {
            int hitPoints = int.Parse(HP);
            int attackPower = int.Parse(AP);

            validateCreate();
            validateTeam(teamID);
            validateMonpoke(hitPoints, attackPower);
            
            if (valid)
            {
                createValidatedTeam(teamID);
                createValidatedMonpoke(teams.GetValueOrDefault(teamID), monpokeID, hitPoints, attackPower);
            }

        }

        private void validateCreate()
        {
            if (battle)
            {
                valid = false;
            }
        }

        private void createValidatedTeam(String teamID)
        {
            switch (teams.Count)
            {
                case 0:
                    Team firstTeam = new Team(teamID, this);
                    teams.Add(teamID, firstTeam);
                    currentTeam = firstTeam;
                    break;
                case 1:
                    if (!teams.ContainsKey(teamID))
                    {
                        Team secondTeam = new Team(teamID, this);
                        teams.Add(teamID, secondTeam);
                        nextTeam = secondTeam;
                    }
                    break;
                default:
                    break;
            }
        }
        private void createValidatedMonpoke(Team team, string ID, int HP, int AP)
        {
            team.AddMonpoke(new Monpoke(ID, AP, HP));
            output.AppendLine($"{ID} has been assigned to team {team.Name}!");
        }

        private void validateMonpoke(int HP, int AP)
        {
            if (HP <= 0 || AP <= 0)
            {
                valid = false;
            }
        }

        private void validateTeam(string teamID)
        {
            if (teams.Count == 2 && !teams.ContainsKey(teamID))
            {
                valid = false;
            }
        }

        public void TakeTurn()
        {
            Team temp = currentTeam;
            currentTeam = nextTeam;
            nextTeam = temp;
        }

    }
}
