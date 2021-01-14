using SeaBattleWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaBattleWPF.Model;
using SeaBattleWPF.BotStrategys;
using System.Windows;

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
            AddRandomShip(game.PlayerFirst);
            AddRandomShip(game.PlayerSecond);

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
           // player1.WriteShip();
            player2.AddNumeric();
            player1.AddNumeric();
            return game;
        }
        //public void AddShip(int numberInConsole, Player player, int loc, int isVertical, bool isRandom = false)
        //{
        //    var ship = player.Ships.FirstOrDefault(p => p.NumberInConsole == numberInConsole);
        //    if (ship != null && valid.ValidationAddShip(player, loc, isVertical, ship))
        //    {
                //for (int i = 0; i < player.Field.FieldArray.Length; i++)
                //{
                //for (int k = 0; k < player.Field.FieldArray.Count; k++)
                //{
                //    if (loc.X == k)//&& loc.Y == i)
                //    {
                //        int m = 0;
                //        player.ShipsInField.Add(ship);
                //        foreach (var shippCell in ship.Cells)
                //        {

                //            if (isVertical == 1)
                //            {
                //                //shippCell.Location = new Location(k + m, i);
                //                //player.Field.FieldArray[k + m][i] = shippCell;
                //                // shippCell.View = "1";
                //            }
                //            else
                //            {
                //                shippCell.Location = new Location(k, i + m);
                //                player.Field.FieldArray[k][i + m] = shippCell;
                //                // shippCell.View = "1";
                //            }
                //            // m++;
                //        }
                //    }
                //}
                //}
                //int i = 1;
                //int p = 1;
                //foreach (var shippCell in ship.Cells)
                //{
                //    shippCell.number = i + p;
                //    player.Field.FieldArray[i + p] = shippCell;
                //    shippCell.View = ConfigGame.CellShip;
                //    i++;
                //    p++;
                //}
        //        if (!isRandom)
        //        {
        //            player.WriteShip();
        //        }
        //    }
        //    else if (!isRandom)
        //    {

        //        throw new InputInvalidParametrException("this location not access");
        //    }
        //}
         public void AddShip(int numberInConsole, Player player, int loc, int isVertical, bool isRandom = false)
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
                                  shippCell.View = ConfigGame.CellShip;
                             }
                             else
                             {
                                     shippCell.number = i + m;
                                     player.Field.FieldArray[i + m] = shippCell;
                                 shippCell.View = ConfigGame.CellShip;
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



        public void AddRandomShip(Player player)
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
                // Location location = new Location(_random.Next(0, 10), _random.Next(0, 10));

                int location = new int();
                location = _random.Next(0, 100);
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
            if (game.NextStep == NextStep.PlayerFirst)
            {
                _botStrategy = new PlayerConsoleShot();
                game.PrevLocation = 0;
                Move(game, _botStrategy.Shot(0));
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


            return game;
        }

        public Game Move(Game game, int loc)
        {
            string step = game.NextStep == NextStep.PlayerFirst ? $"Player" : "Bot";
           // string message = $"Moved {step}: ";
            var player = game.NextStep == NextStep.PlayerSecond ? game.PlayerFirst : game.PlayerSecond;
            //for (int i = 0; i < player.Field.FieldArray.Length; i++)
            //{
                for (int i = 0; i < 100; i++)//int k = 0; k < player.Field.FieldArray[i].Length; k++)
                {
                    if (i == loc)//loc.X == k && loc.Y == i)
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
            
            //}

            var currentPlayer = game.NextStep == NextStep.PlayerSecond ? game.PlayerSecond : game.PlayerFirst;
            //int n = 0;
            //foreach (Ship ship in player.ShipsInField)
            //{
            //    if (ship.IsLive)
            //    {
            //        n++;
            //    }

            //}
            //if (n == 0)
            //{
            //    currentPlayer.IsWin = true;
            //}
            currentPlayer.IsWin = player.ShipsInField.All(p => !p.IsLive);
            return game;
        }

    }
}
