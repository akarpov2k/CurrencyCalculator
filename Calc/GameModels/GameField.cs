using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calc.GameModels
{
    public class GameField
    {
        public GameCell[][] Field;
        public bool IsWin()
        {
            return Field.All( f => f.All( item => item.IsOpen ) );
        }
    }
    
        public class GameCell
    {
        public int? Value { get; init; }
        public bool IsOpen { get; set; } = false;        
    }
    
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
