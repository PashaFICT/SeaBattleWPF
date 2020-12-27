using SeaBattleWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaBattleWPF.Model;
using SeaBattleWPF.BotStrategys;

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
            AddRandomShip(game.PlayerSecond);
            //game.PlayerFirst.FieldView(game.PlayerFirst);
            //game.PlayerSecond.FieldView(game.PlayerSecond, false, false);

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
           // player1.FieldView(player1);
            player1.WriteShip();
            player2.AddNumeric();
            return game;
        }
        public void AddShip(int numberInConsole, Player player, Location loc, int isVertical, bool isRandom = false)
        {
            var ship = player.Ships.FirstOrDefault(p => p.NumberInConsole == numberInConsole);
            if (ship != null && valid.ValidationAddShip(player, loc, isVertical, ship))
            {
                for (int i = 0; i < player.Field.FieldArray.Length; i++)
                {
                    for (int k = 0; k < player.Field.FieldArray[i].Length; k++)
                    {
                        if (loc.X == k && loc.Y == i)
                        {
                            int m = 0;
                            player.ShipsInField.Add(ship);
                            foreach (var shippCell in ship.Cells)
                            {

                                if (isVertical == 1)
                                {
                                    shippCell.Location = new Location(k + m, i);
                                    player.Field.FieldArray[k + m][i] = shippCell;
                                }
                                else
                                {
                                    shippCell.Location = new Location(k, i + m);
                                    player.Field.FieldArray[k][i + m] = shippCell;
                                }
                                m++;
                            }
                        }
                    }
                }
                if (!isRandom)
                {
              //   player.FieldView(player);
                    player.WriteShip();
                }
            }
            else if (!isRandom)
            {

                throw new InputInvalidParametrException("this location not access");
            }
        }

        public void AddRandomShip(Player player)
        {
            while (player.ShipsInField.Count != player.Ships.Count)
            {
                int numberInConsole = _random.Next(0, 11);
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
                Location location = new Location(_random.Next(0, 10), _random.Next(0, 10));

                AddShip(numberInConsole, player, location, _random.Next(0, 2), true);
            }

           // player.FieldView(player);
            player.WriteShip();
        }

        public Game DeleteShip(Guid ShipID, Guid PlayerID, Game game)
        {
            return game;
        }
        public Game Move(Game game)
        {
            string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
            string message = $"Move {step}: ";
           // messageAction(message);
            if (game.NextStep == NextStep.PlayerFirst)
            {
                _botStrategy = new PlayerConsoleShot();
                game.PrevLocation = null;
                Move(game, _botStrategy.Shot(null));
            }
            else
            {
                if (game.PrevLocation == null)
                {
                    _botStrategy = new RandomShot();

                    game.PrevLocation = _botStrategy.Shot(null);
                    Move(game, game.PrevLocation);
                }
                else
                {
                    _botStrategy = new ShotTheTarget();
                    game.PrevLocation = _botStrategy.Shot(game.PrevLocation);
                    Move(game, game.PrevLocation);
                }

               // messageAction($"Bot moved {game.PrevLocation.ToString()}");
            }


            return game;
        }

        public Game Move(Game game, Location loc)
        {
            string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
            string message = $"Moved {step}: ";
            var player = game.NextStep == NextStep.PlayerSecond ? game.PlayerFirst : game.PlayerSecond;
            for (int i = 0; i < player.Field.FieldArray.Length; i++)
            {
                for (int k = 0; k < player.Field.FieldArray[i].Length; k++)
                {
                    if (loc.X == k && loc.Y == i)
                    {
                        player.Field.FieldArray[k][i].IsShot = true;
                        var ship = player.LocationIsShip(player, i, k);
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
                            message += ("miss");
                        }
                        else if (ship.IsLive && ship.IsWarning)
                        {
                            message += ("warning ship");
                        }
                        else if (!ship.IsLive)
                        {
                            message += ("kill ship");
                        }
                    }
                }
            }

            var currentPlayer = game.NextStep == NextStep.PlayerSecond ? game.PlayerSecond : game.PlayerFirst;

            currentPlayer.IsWin = player.ShipsInField.All(p => !p.IsLive);

            //game.PlayerFirst.FieldView(game.PlayerFirst);
            //game.PlayerSecond.FieldView(game.PlayerSecond, false, false);
          //  messageAction(message);
            return game;
        }

    }
}
