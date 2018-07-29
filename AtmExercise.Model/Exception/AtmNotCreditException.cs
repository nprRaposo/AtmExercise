using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Model.Exception
{
    public class AtmNotCreditException : ApplicationException
    {
        public AtmNotCreditException(string message) : base(message) { }
    }
}
