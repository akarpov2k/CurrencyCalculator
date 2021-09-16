using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calc.Pages
{
    public partial class Calculate
    {
        private double firstNum = 1;
        private double secondNum = 1;
        
        protected string FirstNum
        {
            get
            {
                return string.Format( "{0:0.000}", firstNum ).Replace( ',', '.' );                
            }
            set
            {
                firstNum = Double.Parse( value );
                secondNum = firstNum;
            }
        }

        protected string SecondNum {
            get
            {
                return string.Format( "{0:0.000}", secondNum ).Replace( ',', '.' );
            }
            set
            {
                secondNum = Double.Parse( value );
                firstNum = secondNum;
            }
        }

        protected void SetFirstValue(string value )
        {
            Console.WriteLine( value );
            FirstNum = value;
        }

    }

}
