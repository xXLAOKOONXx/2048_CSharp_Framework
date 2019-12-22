using System;
using _2048Game.Objects;
using NUnit.Framework;

namespace UnitTest2048DLL
{
    public class GameStateTests

    {
        [Test]
        public void PerformMoveOnly_Right_Merge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2 },
                    {2,2 }
                };
            var end_arr = new int[,]
                {
                    {0,4 },
                    {0,4 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.right);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }
        [Test]
        public void PerformMoveOnly_Right_ComplexMerge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2,4 },
                    {2,2,2 },
                    {0,2,0 }
                };
            var end_arr = new int[,]
                {
                    {0,4,4 },
                    {0,2,4 },
                    {0,0,2 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.right);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }
        [Test]
        public void PerformMoveOnly_Left_Merge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2 },
                    {2,2 }
                };
            var end_arr = new int[,]
                {
                    {4,0 },
                    {4,0 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.left);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }
        [Test]
        public void PerformMoveOnly_Left_ComplexMerge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2,4 },
                    {2,2,2 },
                    {0,2,0 }
                };
            var end_arr = new int[,]
                {
                    {4,4,0 },
                    {4,2,0 },
                    {2,0,0 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.left);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }
        [Test]
        public void PerformMoveOnly_Top_Merge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2 },
                    {2,2 }
                };
            var end_arr = new int[,]
                {
                    {4,4 },
                    {0,0 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.top);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }
        [Test]
        public void PerformMoveOnly_Top_ComplexMerge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2,0 },
                    {2,2,2 },
                    {4,2,0 }
                };
            var end_arr = new int[,]
                {
                    {4,4,2 },
                    {4,2,0 },
                    {0,0,0 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.top);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }
        [Test]
        public void PerformMoveOnly_Bot_Merge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2 },
                    {2,2 }
                };
            var end_arr = new int[,]
                {
                    {0,0 },
                    {4,4 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.bot);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }
        [Test]
        public void PerformMoveOnly_Bot_ComplexMerge()
        {

            //Arrange
            var start_arr = new int[,]
                {
                    {2,2,0 },
                    {2,2,2 },
                    {4,2,0 }
                };
            var end_arr = new int[,]
                {
                    {0,0,0 },
                    {4,2,0 },
                    {4,4,2 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.bot);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

        }

        [Test]
        public void Spawn()
        {
            //Arrange
            var start_arr = new int[,]
                {
                    {2,2,0 },
                    {2,2,2 },
                    {4,2,0 }
                };
            var end_arr = new int[,]
                {
                    {0,0,0 },
                    {4,2,0 },
                    {4,4,2 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMove(_2048Game.Enums.Moves.bot);

            var res = state.GetView();
            int rnds = 0;

            for (int x = 0; x < end_arr.GetLength(0); x++)
            {
                for (int y = 0; y < end_arr.GetLength(1); y++)
                {
                    if (end_arr[x, y] != res[x, y])
                    {
                        if (end_arr[x, y] != 0)
                        {
                            Assert.Fail("a non 0 difference accured.");
                        }
                        rnds++;
                    }
                }
            }

            if (rnds > 1)
            {
                Assert.Fail("More than 1 random number got created");
            }
        }

        [Test]
        public void CheckCounting()
        {


            //Arrange
            var start_arr = new int[,]
                {
                    {2,2,0 },
                    {2,2,2 },
                    {4,2,0 }
                };
            var end_arr = new int[,]
                {
                    {0,0,0 },
                    {4,2,0 },
                    {4,4,2 }
                };
            var state = new Game(start_arr);
            //Act
            state.PerformMoveOnly(_2048Game.Enums.Moves.bot);

            //Assert
            // Assert.AreEqual(end_arr, state.GetView());
            Assert.IsTrue(ArraysAreEqual(end_arr, state.GetView()));

            state.PerformMoveOnly(_2048Game.Enums.Moves.bot);

            if (state.CountMerges() != 3)
            {
                Assert.Fail("Merges not counted correctly");
            }
            if (state.TopNumber() != 8)
            {
                Assert.Fail("TopNumber not correct");
            }

        }
        [Test]
        public void CreateGame()
        {
            var state = new Game(4,4);

            var checkArr = new int[,]
            {
                {0,0,0,0 },
                {0,0,0,0 },
                {0,0,0,0 },
                {0,0,0,0 }
            };

            if (!ArraysAreEqual(state.GetView(), checkArr))
            {
                Assert.Fail("Game Creation not successful");
            }
        }

        [Test]
        public void GameEnd()
        {
            var startArr = new int[,]
            {
                {2,4,2,4 },
                {4,2,4,2 },
                {2,4,2,4 },
                {4,2,4,2 }
            };

            var state = new Game(startArr);

            try
            {
                state.PerformMove(_2048Game.Enums.Moves.bot);
            }catch(NoEmptyFieldException ex)
            {
                return;
            }
            Assert.Fail("NoEmptyFieldException not thrown");
        }

        
        private bool ArraysAreEqual(int[,] arr1, int[,] arr2)
        {
            if (arr1.GetLength(0) == arr2.GetLength(0) && arr1.GetLength(1) == arr2.GetLength(1))
            {
                for (int x = 0; x < arr1.GetLength(0); x++)
                {
                    for (int y = 0; y < arr1.GetLength(1); y++)
                    {
                        if (arr1[x, y] != arr2[x, y])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            return false;
        }
    }
}
