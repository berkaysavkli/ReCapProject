using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }

        //Mesaj gönderilmek istenmezse de çalışması için aşağıdaki şekilde yazdık.
        public ErrorResult() : base(false)
        {

        }
    }
}
