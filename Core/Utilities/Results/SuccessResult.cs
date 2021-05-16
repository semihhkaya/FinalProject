using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {   //2-CTOR  
        public SuccessResult(string message) : base(true, message) //Base burda Result class'ına gidiyor. 2 Parametreli olan methoduna
        {

        }

        public SuccessResult(): base(true)
        {

        }
    }
}
