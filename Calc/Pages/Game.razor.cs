using Calc.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Timers;

using Microsoft.JSInterop;
using System.Diagnostics;

namespace Calc.Pages
{
    public partial class Game
    {
        protected GameField GameField { get; set; }
        protected Timer TunrTimer { get; set; }
        protected Timer LoseTimer { get; set; }
        protected Stopwatch GameWatch { get; set; }

        protected Coord FirstCard { get; set; }
        protected Coord SecondCard { get; set; }

        protected byte ClickCount { get; set; } = 0;

        protected string WinColor = "green";
        protected string SelectColor = "yellow";
        protected string NonColor = "white";
        protected uint GameMoveCount = 0;
        protected bool GameEnd = false;
        protected string EndText;

        protected TimeSpan TimeLeft { get; set; }

        protected void Init(int fieldSize)
        {
            GameField = GameCellGenerator.Generate( fieldSize );
            TunrTimer = new Timer( 900 );
            TimeLeft = new TimeSpan(0,5,0);
            LoseTimer = new Timer( 1000 );
            LoseTimer.Elapsed += TimeDecrement;
            LoseTimer.Enabled = true;
            TunrTimer.Elapsed += TurnOverCard;
            TunrTimer.Enabled = false;
            GameWatch = Stopwatch.StartNew();
            GameMoveCount = 0;
        }
        protected void HideCards()
        {
            JS.InvokeVoidAsync( "showSelectCell", new object[] { FirstCard.GetCellPos(), GameField.Field[FirstCard.X][FirstCard.Y].Value, NonColor, true } );
            JS.InvokeVoidAsync( "showSelectCell", new object[] { SecondCard.GetCellPos(), GameField.Field[SecondCard.X][SecondCard.Y].Value, NonColor, true } );
            GameField.Field[FirstCard.X][FirstCard.Y].IsOpen = false;
            GameField.Field[SecondCard.X][SecondCard.Y].IsOpen = false;
        }
        protected void EraseCards()
        {            
            FirstCard = SecondCard = null;
            ClickCount = 0;
        }

        private void LoseGame()
        {
            GameEnd = true;
            EndText = "Вы програли.";
            GameWatch.Stop();            
            ButtonText = "Начать заново";
            displaySettings = "none";
            GameField = null;
            isWin = false;
        }
        private void TurnOverCard( Object source, ElapsedEventArgs e )
        {
            if( FirstCard != null && SecondCard != null )
            {
                HideCards();
                EraseCards();
            }
            InvokeAsync( StateHasChanged );
        }

        private void TimeDecrement(Object source, ElapsedEventArgs e )
        {
            if( TimeLeft.TotalSeconds > 0 )
            {
                TimeLeft = TimeLeft - new TimeSpan( 0, 0, 1 );
            }
            else
            {
                LoseGame();
                LoseTimer.Enabled = false;
            }
            InvokeAsync( StateHasChanged );
        }
    }

    public class Coord
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
