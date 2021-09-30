using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calc.GameModels
{
    public class GameCellGenerator
    {
        public static GameField Generate( int size )
        {
            var cells = new GameCell[4][];
            var rand = new Random( DateTime.Now.Millisecond );
            for( int i = 0; i < cells.Length; i++ )
            {
                cells[i] = new GameCell[size / 4];
            }
            var numCount = size / 2;
            HashSet<int> cardValues = new();
            do
            {
                cardValues.Add( rand.Next( 1, 20 ) );
            }
            while( cardValues.Count < numCount );
            var values = new List<int>();
            foreach(var val in cardValues)
            {
                values.Add( val );
                values.Add( val );
            }
            rand = new();
            values = values.OrderBy( v => rand.Next() ).ToList();
            foreach(var row in cells )
            {
                for(int i = 0; i < row.Length; i++ )
                {
                    row[i] = new() { Value = values.Last() };
                    values.RemoveAt( values.Count - 1 );
                }
            }

            return new() { Field = cells };
        }
    }
}
