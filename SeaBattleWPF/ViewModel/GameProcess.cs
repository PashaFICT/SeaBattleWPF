using SeaBattleWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaBattleWPF.Model;
using SeaBattleWPF.BotStrategys;
using System.Windows;
using System.Threading;

namespace SeaBattleWPF.ViewModel
{
    public class GameProcess
    {
        IBuildGame _buildGame;
        Validation valid = new Validation();
        Random _random = new Random();
        BotStrategy _botStrategy = new RandomShot();
        public GameProcess()
        {
            _buildGame = new BuildGame();
        }
        public Game StartGame(Game game)
        {
            AddRandomShip(game.PlayerFirst, game);
            AddRandomShip(game.PlayerSecond, game);

            return game;
        }
        public Game Init()
        {
            List<Ship> ships = new List<Ship>();
            List<Ship> ships1 = new List<Ship>();
            Player player1 = new Player(_buildGame.BuildField(), false, ships);
            Player player2 = new Player(_buildGame.BuildField(), false, ships1);

            for (int i = 0; i < ConfigGame.CountOfOne; i++)
            {
                player1.Ships.Add(_buildGame.BuildShipOfOne());
                player2.Ships.Add(_buildGame.BuildShipOfOne());
            }
            for (int i = 0; i < ConfigGame.CountOfTwo; i++)
            {
                player1.Ships.Add(_buildGame.BuildShipOfTwo());
                player2.Ships.Add(_buildGame.BuildShipOfTwo());

            }
            for (int i = 0; i < ConfigGame.CountOfThree; i++)
            {
                player1.Ships.Add(_buildGame.BuildShipOfThree());
                player2.Ships.Add(_buildGame.BuildShipOfThree());
            }
            for (int i = 0; i < ConfigGame.CountOfFour; i++)
            {
                player1.Ships.Add(_buildGame.BuildShipOfFour());
                player2.Ships.Add(_buildGame.BuildShipOfFour());
            }
            Game game = new Game(player1, player2, NextStep.PlayerFirst);
            player2.AddNumeric();
            player1.AddNumeric();
            return game;
        }
         public void AddShip(Game game, int numberInConsole, Player player, int loc, int isVertical, bool isRandom = false)
         {
             var ship = player.Ships.FirstOrDefault(p => p.NumberInConsole == numberInConsole);
             if (ship != null && valid.ValidationAddShip(player, loc, isVertical, ship))
             {
                 for (int i = 0; i < player.Field.FieldArray.Count; i++)
                 {
                     if (loc == player.Field.FieldArray[i].number)
                     {
                         int m = 0;
                         int p = 1;
                         player.ShipsInField.Add(ship);
                         foreach (var shippCell in ship.Cells)
                         {

                             if (isVertical == 1)
                             {
                                     shippCell.number = i + p;
                                     player.Field.FieldArray[i + p] = shippCell;
                                if (ConfigGame.isSecret && game.PlayerSecond.GuidPlayerId == player.GuidPlayerId)
                                {
                                    shippCell.View = ConfigGame.CellEmpty;
                                    shippCell.Empty = false;
                                }
                                else
                                {
                                    shippCell.View = ConfigGame.CellShip;
                                    shippCell.Empty = false;
                                }
                                  
                             }
                             else
                             {
                                     shippCell.number = i + m;
                                     player.Field.FieldArray[i + m] = shippCell;
                                     shippCell.View = ConfigGame.CellShip;
                                     shippCell.Empty = false;
                             }
                              m++;
                             p += 10;
                         }
                     }
                 }
                 if (!isRandom)
                 {
                     player.WriteShip();
                 }
             }
             else if (!isRandom)
             {

                 throw new InputInvalidParametrException("this location not access");
             }
         }

        public void AddRandomShip(Player player, Game game)
        {
            while (player.ShipsInField.Count != player.Ships.Count)
            {
                int numberInConsole = _random.Next(1, 11);
                bool isContinue = false;
                foreach (var item in player.ShipsInField)
                {
                    if (item.NumberInConsole == numberInConsole)
                    {
                        isContinue = true;
                        break;
                    }
                }

                if (isContinue)
                {
                    continue;
                }
                int location = new int();
                location = _random.Next(0, 100);
                AddShip(game, numberInConsole, player, location, _random.Next(0, 2), true);
            }
            player.WriteShip();
        }

        public Game Move(Game game, Cell cell)
        {
            string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
            if (game.NextStep == NextStep.PlayerFirst)
            {
                Move(game, cell.number);
            }
            else
            {
                if (game.PrevLocation == 0)
                {
                    _botStrategy = new RandomShot();

                    game.PrevLocation = _botStrategy.Shot(0);
                    Move(game, game.PrevLocation);
                }
                else
                {
                    _botStrategy = new ShotTheTarget();
                    game.PrevLocation = _botStrategy.Shot(game.PrevLocation);
                    Move(game, game.PrevLocation);
                }
            }

            if (game.NextStep == NextStep.PlayerSecond)
            {
                Move(game, cell);
            }
            return game;
        }

        public Game Move(Game game, int loc)
        {
            string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
            var player = game.NextStep == NextStep.PlayerSecond ? game.PlayerFirst : game.PlayerSecond;
                for (int i = 0; i < 100; i++)
                {
                    if (i == loc)
                    {
                        player.Field.FieldArray[i].IsShot = true;
                        var ship = player.LocationIsShip(player, i);
                        if (ship == null)
                        {
                            if (game.NextStep == NextStep.PlayerFirst)
                            {
                                game.NextStep = NextStep.PlayerSecond;
                            }
                            else
                            {
                                game.NextStep = NextStep.PlayerFirst;
                            }
                            player.Field.FieldArray[i].View = ConfigGame.CellShot;
                        }
                        else if (ship.IsLive && ship.IsWarning)
                        {
                            player.Field.FieldArray[i].View = ConfigGame.CellWarning;
                        }
                        else if (!ship.IsLive)
                        {
                            player.Field.FieldArray[i].View = ConfigGame.CellWarning; ;
                        }
                    }
                }
            var currentPlayer = game.NextStep == NextStep.PlayerSecond ? game.PlayerSecond : game.PlayerFirst;
            currentPlayer.IsWin = player.ShipsInField.All(p => !p.IsLive);
            return game;
        }

    }
}
