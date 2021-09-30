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
            Field = GameCellGenerator.Generate( 16 );
        }
        protected GameField Field { get; set; }
       
    }
}
