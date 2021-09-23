using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;

namespace Calc.Pages
{
    public partial class Calculate
    {
        public struct Currency
        {
            public string Name { get; set; }
            public double Value { get; set; }
            public string ImagePath { get; set; }
        }
        #region private fields

        private double selectedFirstRate;
        private double selectedSecondRate;
        private double firstValue = 0;
        private double secondValue = 0;
        private string firstCurrName;
        private string secondCurrName;
        private int accuracy = 2;
        private Timer timer;
        #endregion

        #region protected properties
        protected List<Currency> Currencies;
        protected double FirstCurrency
        {
            get
            {
                return selectedFirstRate;
            }
            set
            {
                selectedFirstRate = value;
                SecondValue = Math.Round( FirstValue * selectedSecondRate / selectedFirstRate, Accuracy );
            }
        }
        protected double SecondCurrency
        {
            get
            {
                return selectedSecondRate;
            }
            set
            {
                selectedSecondRate = value;
                FirstValue = Math.Round( SecondValue * selectedFirstRate / selectedSecondRate, Accuracy );
            }
        }
        protected bool IsLoading = true;
        protected string LastTimeUpdate { get; set; }
        protected double FirstValue { get { return firstValue; } set {
                firstValue = value; 
                secondValue = Math.Round( firstValue * selectedSecondRate / selectedFirstRate, Accuracy );
            } 
        }
        protected double SecondValue
        {
            get { return secondValue; }
            set {
                secondValue = value;
                firstValue = Math.Round( secondValue * selectedFirstRate / selectedSecondRate,Accuracy);
            }
        }

        protected int Accuracy { get { return accuracy; } set {
                accuracy = value;
                FirstValue = FirstValue;
            } }

        protected TimeSpan TimeLeft { get; set; }

        protected string FirstCurrencyName { get { return firstCurrName; } set
            {
                firstCurrName = value;
                selectedFirstRate = Currencies.FirstOrDefault( item => item.Name == value ).Value;
            }
        }
        protected string SecondCurrencyName { get { return secondCurrName; }
            set {
                secondCurrName = value;
                selectedSecondRate = Currencies.FirstOrDefault( item => item.Name == value ).Value; 
            } }
       

        #endregion

        #region methods
        protected async Task LoadCurrency()
        {
            var obj = await Rates.Import();
            GetCurrencyField( obj );            
            LastTimeUpdate = DateTime.Now.ToString( "dd.MM.yyyy dddd" );
        }

        private void GetCurrencyField( API_Obj obj )
        {
            if( Currencies == null )
            {
                Currencies = new List<Currency>();
            }
            var props = typeof( ConversionRate ).GetProperties();
            foreach( var prop in props )
            {
                Currencies.Add( new Currency
                {
                    Name = prop.Name,
                    Value = (double)prop.GetValue( obj.conversion_rates, null ),
                    ImagePath = "flags/" + prop.Name + ".png"
                } );
            }
        }

        private void RefreshTime()
        {
            TimeLeft = DateTime.UtcNow.Date.AddDays( 1 ).AddSeconds(2) - DateTime.UtcNow;
        }

        private void DecrementTime( Object source, ElapsedEventArgs e )
        {
            if (TimeLeft.TotalSeconds > -1 )
            {
                TimeLeft = TimeLeft - new TimeSpan(0,0,1);
            }
            else
            {
                RefreshTime();
            }
            InvokeAsync( StateHasChanged );
        }

        protected void SetTimer()
        {
            timer = new Timer( 1000 );
            timer.Elapsed += DecrementTime;
            RefreshTime();
            timer.Enabled = true;
        }

        protected string GetImgPath(string name )
        {
            return Currencies.FirstOrDefault( item => item.Name == name ).ImagePath;
        }

        #endregion
    }


    #region rates api
    class Rates
    {
        public static async Task<API_Obj> Import()
        {
            String URLString = "https://v6.exchangerate-api.com/v6/d98708e6592be8b6fbb4ae4e/latest/USD";
            try
            {
                using( var webClient = new HttpClient() )
                {
                    var json = await webClient.GetStringAsync( URLString );
                    var obj = JsonConvert.DeserializeObject<API_Obj>( json );
                    return obj;
                }

            }
            catch( Exception e )
            {
                Console.WriteLine( e.Message );
                return null;
            }
        }
    }

    public class API_Obj
    {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_zone { get; set; }
        public string time_last_update_utc { get; set; }
        public string time_next_update { get; set; }
        public ConversionRate conversion_rates { get; set; }
    }

    public class ConversionRate
    {
        public double AED { get; set; }
        public double ARS { get; set; }
        public double AUD { get; set; }
        public double BGN { get; set; }
        public double BRL { get; set; }
        public double BSD { get; set; }
        public double CAD { get; set; }
        public double CHF { get; set; }
        public double CLP { get; set; }
        public double CNY { get; set; }
        public double COP { get; set; }
        public double CZK { get; set; }
        public double DKK { get; set; }
        public double DOP { get; set; }
        public double EGP { get; set; }
        public double EUR { get; set; }
        public double FJD { get; set; }
        public double GBP { get; set; }
        public double GTQ { get; set; }
        public double HKD { get; set; }
        public double HRK { get; set; }
        public double HUF { get; set; }
        public double IDR { get; set; }
        public double ILS { get; set; }
        public double INR { get; set; }
        public double ISK { get; set; }
        public double JPY { get; set; }
        public double KRW { get; set; }
        public double KZT { get; set; }
        public double MXN { get; set; }
        public double MYR { get; set; }
        public double NOK { get; set; }
        public double NZD { get; set; }
        public double PAB { get; set; }
        public double PEN { get; set; }
        public double PHP { get; set; }
        public double PKR { get; set; }
        public double PLN { get; set; }
        public double PYG { get; set; }
        public double RON { get; set; }
        public double RUB { get; set; }
        public double SAR { get; set; }
        public double SEK { get; set; }
        public double SGD { get; set; }
        public double THB { get; set; }
        public double TRY { get; set; }
        public double TWD { get; set; }
        public double UAH { get; set; }
        public double USD { get; set; }
        public double UYU { get; set; }
        public double ZAR { get; set; }
    }
    #endregion
}
