using _2048Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game.Interfaces
{
    public interface IGame
    {
        void PerformMove(Moves move);

        int[,] GetView();

        int TopNumber();
        int CountMerges();
    }
}
