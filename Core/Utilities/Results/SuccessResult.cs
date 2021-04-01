using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }

        //Mesaj gönderilmek istenmezse de çalışması için aşağıdaki şekilde yazdık.
        public SuccessResult() : base(true)
        {

        }
    }
}
