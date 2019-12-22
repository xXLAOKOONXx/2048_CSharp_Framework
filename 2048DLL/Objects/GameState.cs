using _2048Game.Enums;
using _2048Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game.Objects
{
    public class Game : IGame
    {
        private int topNumber = 0;
        private int countMerges = 0;

        public int TopNumber()
        {
                return topNumber;
        }
        public int CountMerges()
        {
                return countMerges;
        }
        public Game(int[,] arr)
        {
            gameTable = arr;
        }

        private int[,] gameTable;

        public Game(int x_dimension, int y_dimension)
        {
            gameTable = new int[x_dimension,y_dimension];

            RandomSpawnNumber();
        }

        public int[,] GetView()
        {
            var targetarr = new int[gameTable.GetLength(0), gameTable.GetLength(1)];

            for(int x = 0; x < gameTable.GetLength(0); x++)
            {
                for (int y = 0; y < gameTable.GetLength(1); y++)
                {
                    targetarr[x, y] = gameTable[x, y];
                }
            }

            return targetarr;
        }

        public void PerformMove(Moves move)
        {
            this.PerformMoveOnly(move);

            this.SpawnRandomNumber();
        }

        public void PerformMoveOnly(Moves move)
        {
            switch (move)
            {
                case Moves.top:
                    this.PerformeTopMove();
                    break;
                case Moves.right:
                    this.PerformeRightMove();
                    break;
                case Moves.bot:
                    this.PerformeBotMove();
                    break;
                case Moves.left:
                    this.PerformeLeftMove();
                    break; 
            }
        }

        private void PerformeLeftMove()
        {
            for (int x = 0; x < this.gameTable.GetLength(0); x++)
            {
                var list = new List<int>();
                bool combinedentry = false;
                for (int y = 0; y < this.gameTable.GetLength(1); y++)
                {
                    if (gameTable[x, y] == 0)
                    {
                        continue;
                    }
                    if (!combinedentry && (list.LastOrDefault() == gameTable[x, y]))
                    {
                        list[list.Count - 1] = list[list.Count - 1] * 2;
                        MergePerformed(list[list.Count - 1]);
                        combinedentry = true;
                        continue;
                    }
                    list.Add(gameTable[x, y]);
                    combinedentry = false;
                }
                for (int y = 0; y < this.gameTable.GetLength(1); y++)
                {
                    if(y < list.Count())
                    {
                        gameTable[x,y] = list[y];
                        continue;
                    }
                    gameTable[x, y] = 0;
                }
            }
        }
        private void PerformeBotMove()
        {
            for (int y = 0; y < this.gameTable.GetLength(1); y++)
            {
                var list = new List<int>();
                bool combinedentry = false;
                for (int x = this.gameTable.GetLength(0) - 1; x >= 0; x--)
                {
                    if (gameTable[x, y] == 0)
                    {
                        continue;
                    }
                    if (!combinedentry && (list.LastOrDefault() == gameTable[x, y]))
                    {
                        list[list.Count - 1] = list[list.Count - 1] * 2;
                        MergePerformed(list[list.Count - 1]);
                        combinedentry = true;
                        continue;
                    }
                    list.Add(gameTable[x, y]);
                    combinedentry = false;
                }
                for (int x = this.gameTable.GetLength(0) - 1; x >= 0; x--)
                {
                    var l_x = this.gameTable.GetLength(0) - 1 - x;
                    if (l_x < list.Count())
                    {
                        gameTable[x, y] = list[l_x];
                        continue;
                    }
                    gameTable[x, y] = 0;
                }
            }

        }

        private void MergePerformed(int mergedNumber)
        {
            if (mergedNumber > this.topNumber)
            {
                this.topNumber = mergedNumber;
            }
            this.countMerges++;
        }
        private void PerformeRightMove()
        {
            for (int x = 0; x < this.gameTable.GetLength(0); x++)
            {
                var list = new List<int>();
                bool combinedentry = false;
                for (int y = this.gameTable.GetLength(1)-1; y >=0; y--)
                {
                    if (gameTable[x, y] == 0)
                    {
                        continue;
                    }
                    if (!combinedentry && (list.LastOrDefault() == gameTable[x, y]))
                    {
                        list[list.Count - 1] = list[list.Count - 1] * 2;
                        MergePerformed(list[list.Count - 1]);
                        combinedentry = true;
                        continue;
                    }
                    list.Add(gameTable[x, y]);
                    combinedentry = false;
                }
                for (int y = this.gameTable.GetLength(1) - 1; y >= 0; y--)
                {
                    var l_y = this.gameTable.GetLength(1) - 1 - y;
                    if (l_y < list.Count())
                    {
                        gameTable[x, y] = list[l_y];
                        continue;
                    }
                    gameTable[x, y] = 0;
                }
            }
        }
        private void PerformeTopMove()
        {
            for (int y = 0; y < this.gameTable.GetLength(1); y++)
            {
                var list = new List<int>();
                bool combinedentry = false;
                for (int x = 0; x < this.gameTable.GetLength(0); x++)
                {
                    if (gameTable[x, y] == 0)
                    {
                        continue;
                    }
                    if (!combinedentry && (list.LastOrDefault() == gameTable[x, y]))
                    {
                        list[list.Count - 1] = list[list.Count - 1] * 2;
                        MergePerformed(list[list.Count - 1]);
                        combinedentry = true;
                        continue;
                    }
                    list.Add(gameTable[x, y]);
                    combinedentry = false;
                }
                for (int x = 0; x < this.gameTable.GetLength(0); x++)
                {
                    if (x < list.Count())
                    {
                        gameTable[x, y] = list[x];
                        continue;
                    }
                    gameTable[x, y] = 0;
                }
            }
        }

        private List<Tuple<int,int>> EmptyFields()
        {
            var returnValue = new List<Tuple<int, int>>();

            for (int x = 0; x < gameTable.GetLength(0); x++)
            {
                for (int y = 0; y < gameTable.GetLength(1); y++)
                {
                    if(gameTable[x,y] == 0)
                    {
                        returnValue.Add(new Tuple<int, int>(x, y));
                    }
                }
            }

            return returnValue;
        }

        private void SpawnRandomNumber()
        {
            var emptyFiels = this.EmptyFields();

            if (emptyFiels.Count < 1)
            {
                throw new NoEmptyFieldException();
            }

            var rnd = new Random();
            var itemNo = rnd.Next(emptyFiels.Count);

            gameTable[emptyFiels[itemNo].Item1, emptyFiels[itemNo].Item2] = RandomSpawnNumber();
        }

        private int RandomSpawnNumber()
        {
            return 2;
        }
    }
}
