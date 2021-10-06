using Calc.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calc.Pages
{
    public partial class Game
    {
        protected void Init()
        {
            GameField = GameCellGenerator.Generate( 16 );
        }
        protected GameField GameField { get; set; }
       
    }

    public struct Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals( object obj )
        {
            return obj is Coord coord &&
                   X == coord.X &&
                   Y == coord.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( X, Y );
        }

        public string GetCellPos()
        {
            return $"cell_{X}_{Y}";
        }
    }
}
