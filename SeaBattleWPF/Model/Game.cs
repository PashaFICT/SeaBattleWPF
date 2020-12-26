using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF
{
    public class Game
    {
        IBuildGame buildGame = new BuildGame();
        public Player PlayerFirst;
        public Player PlayerSecond;
        public NextStep NextStep;
        public bool GameOn;
        public Location PrevLocation;
        public Game() { }
        public Game(Player player1, Player player2, NextStep nextStep)
        {
            PlayerFirst = player1;
            PlayerSecond = player2;
            NextStep = nextStep;
            GameOn = true;
        }
    }
}
